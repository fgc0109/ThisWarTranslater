using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Palette_Project
{
    // rawData      // Data header
    // *(u32 *)pReadBuf = size << 8 | 0;
    //                      [i+3] [i+2] [i+1](size)  |  [0000 0000]
    // DiffFilt
    // *(u32 *)dstp     = size << 8 | 0x80 | diffBitSize/8;
    //                      [i+3] [i+2] [i+1](size)  |  [1000 00XX]
    // RL
    // *(u32 *)dstp     = size << 8 | 0x30;
    //                      [i+3] [i+2] [i+1](size)  |  [0011 0000]
    // LZ77
    // *(u32 *)dstp     = size << 8 | 0x10;
    //                      [i+3] [i+2] [i+1](size)  |  [0001 0000]
    // Huffman
    // *(u32 *)dstp     = size << 8 | 0x20 | huffBitSize;
    //                      [i+3] [i+2] [i+1](size)  |  [0010 XX00]
    enum Compress_Enum
    {
        LZ77 = 0x10,
        LZSS = 0x11,
        HUFF = 0x20,
        RLEC = 0x30,
        LZMA = 0x40,
        DIFF = 0x80,
        NONE = 0x00
    }

    class CompressMethod
    {
        public static MemoryStream DeCompress_LZ77(BinaryReader datareader)
        {
            //文件头   (32bit) 识别文件类型和解压大小
            //      Bit 0-3   Reserved
            //      Bit 4-7   Compressed type (must be 1 for LZ77)
            //      Bit 8-31  Size of decompressed data
            //
            //标志位   (8bit)  用来标识数据块是否压缩，每个标志位后有8个数据块
            //      Bit 0-7   Type Flags for next 8 Blocks, MSB first
            //
            //数据块   (16bit) 压缩文件数据块,对压缩数据是一个包含（与当前位置的偏移值，数据长度）的数组
            //      Block Type 0 - Uncompressed - Copy 1 Byte from Source to Dest
            //          Bit 0-7   One data byte to be copied to dest
            //      Block Type 1 - Compressed - Copy N+3 Bytes from Dest-Disp-1 to Dest
            //          Bit 0-3   Disp MSBs
            //          Bit 4-7   Number of bytes to copy (minus 3)
            //          Bit 8-15  Disp LSBs

            datareader.ReadByte();
            int size = datareader.ReadUInt16() | (datareader.ReadByte() << 16);
            MemoryStream dataoutput = new MemoryStream(size);

            while (dataoutput.Length < size)
            {
                int flagByte = datareader.ReadByte();
                for (int i = 0; i < 8; i++)
                {
                    if ((flagByte & (0x80 >> i)) != 0)
                    {
                        ushort block = datareader.ReadUInt16();
                        int count = ((block >> 4) & 0xF) + 3;
                        int disp = ((block & 0xF) << 8) | ((block >> 8) & 0xFF);

                        long outPos = dataoutput.Position;
                        long copyPos = dataoutput.Position - disp - 1;

                        for (int j = 0; j < count; j++)
                        {
                            dataoutput.Position = copyPos++;
                            byte b = (byte)dataoutput.ReadByte();

                            dataoutput.Position = outPos++;
                            dataoutput.WriteByte(b);
                        }
                    }
                    else
                    {
                        dataoutput.WriteByte(datareader.ReadByte());
                    }
                    if (dataoutput.Length >= size)
                    {
                        break;
                    }
                }
            }
            dataoutput.Position = 0;
            return dataoutput;
        }

        public static MemoryStream DeCompress_LZSS(BinaryReader datareader)
        {
            //文件头   (32bit) 识别文件类型和解压大小
            //      Bit 0 - 3   Reserved
            //      Bit 4 - 7   Compressed type (must be 1 for LZ77)
            //      Bit 8 - 31  Size of decompressed data. if 0, the next 4 bytes are decompressed length
            //
            //标志位   (8bit)  用来标识数据块是否压缩，每个标志位后有8个数据块
            //      Bit 0 - 7   Type Flags for next 8 Blocks, MSB first
            //
            //数据块           压缩文件数据块
            //      Block Type 0 - Uncompressed - Copy 1 Byte from Source to Dest
            //          Bit 0 - 7   One data byte to be copied to dest
            //      Block Type 1 - Compressed - Copy LEN Bytes from Dest-Disp - 1 to Dest
            //          If Reserved is 0: -Default
            //              Bit 0 - 3   Disp MSBs
            //              Bit 4 - 7   LEN - 3
            //              Bit 8 - 15  Disp LSBs
            //          If Reserved is 1: -Higher compression rates for files with (lots of) long repetitions
            //              Bit 4 - 7   Indicator
            //              If Indicator > 1:   AB CD ====> (A)(B CD)
            //                  Bit 0 - 3       Disp MSBs
            //                  Bit 4 - 7       LEN - 1
            //                  Bit 8 - 15      Disp LSBs
            //              If Indicator is 1:  AB CD EF GH ====> A(B CD E)(F GH)
            //                  Bit 0 - 3       unused
            //                  Bit 4 - 15      (LEN - 0x111) MSBs
            //                  Bit 16 - 19     (LEN - 0x111) LSBs
            //                  Bit 20 - 23     Disp MSBs
            //                  Bit 24 - 31     Disp LSBs
            //              If Indicator is 0:  AB CD EF ====> (AB C)(D EF)或者A(B C)(D EF)
            //                  Bit 0 - 3       unused
            //                  Bit 4 - 7       (LEN - 0x11) MSBs
            //                  Bit 8 - 11      (LEN - 0x11) LSBs
            //                  Bit 12 - 15     Disp MSBs
            //                  Bit 16 - 23     Disp LSBs
            datareader.ReadByte();
            int size = datareader.ReadUInt16() | (datareader.ReadByte() << 16);
            MemoryStream dataoutput = new MemoryStream(size);

            while (dataoutput.Length < size)
            {
                int flagByte = datareader.ReadByte();
                for (int i = 0; i < 8; i++)
                {
                    if ((flagByte & (0x80 >> i)) != 0)
                    {
                        int count;
                        int disp;
                        byte byte_2, byte_3, byte_4;
                        byte byte_1 = datareader.ReadByte();
                        switch ((byte_1 >> 4) & 0xF)
                        {
                            case 0:
                                byte_2 = datareader.ReadByte();
                                byte_3 = datareader.ReadByte();
                                count = ((byte_1 << 4) | (byte_2 >> 4)) + 0x11;
                                disp = ((byte_2 & 0x0F) << 8) | (byte_3);
                                break;

                            case 1:
                                byte_2 = datareader.ReadByte();
                                byte_3 = datareader.ReadByte();
                                byte_4 = datareader.ReadByte();
                                count = (((byte_1 & 0x0F) << 12) | (byte_2 << 4) | (byte_3 >> 4)) + 0x111;
                                disp = ((byte_3 & 0x0F) << 8) | (byte_4);
                                break;

                            default:
                                byte_2 = datareader.ReadByte();
                                count = (byte_1 >> 4) + 1;
                                disp = ((byte_1 & 0x0F) << 8) | (byte_2);
                                break;
                        }
                        long outPos = dataoutput.Position;
                        long copyPos = dataoutput.Position - disp - 1;

                        for (int j = 0; j < count; j++)
                        {
                            dataoutput.Position = copyPos++;
                            byte b = (byte)dataoutput.ReadByte();

                            dataoutput.Position = outPos++;
                            dataoutput.WriteByte(b);
                        }
                    }
                    else
                    {
                        dataoutput.WriteByte(datareader.ReadByte());
                    }
                    if (dataoutput.Length >= size)
                    {
                        break;
                    }
                }
            }
            dataoutput.Position = 0;
            return dataoutput;
        }


        public static MemoryStream DeCompress_LZMA(BinaryReader datareader)
        {
            MemoryStream dataoutput = new MemoryStream(1);
            dataoutput.Position = 0;
            return dataoutput;
        }
    }
}

