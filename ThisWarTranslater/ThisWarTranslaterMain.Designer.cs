namespace ThisWarTranslater
{
    partial class ThisWarTranslaterMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonConnectDatabase = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textDataTable = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textDataBase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textDataPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textDataName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textDataPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textDataAddress = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonRefreshing = new System.Windows.Forms.Button();
            this.buttonUpdateData = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.hashList = new System.Windows.Forms.ListView();
            this.headerHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonTemp = new System.Windows.Forms.Button();
            this.buttonExportFile = new System.Windows.Forms.Button();
            this.buttonFolderHandle = new System.Windows.Forms.Button();
            this.buttonChooseFolder = new System.Windows.Forms.Button();
            this.buttonChooseFile = new System.Windows.Forms.Button();
            this.buttonExportFolder = new System.Windows.Forms.Button();
            this.buttonFileHandle = new System.Windows.Forms.Button();
            this.infoList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePath = new System.Windows.Forms.TextBox();
            this.textDebug = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonConnectDatabase);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textDataTable);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textDataBase);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textDataPass);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textDataName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textDataPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textDataAddress);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Location = new System.Drawing.Point(348, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库操作";
            // 
            // buttonConnectDatabase
            // 
            this.buttonConnectDatabase.Location = new System.Drawing.Point(189, 101);
            this.buttonConnectDatabase.Name = "buttonConnectDatabase";
            this.buttonConnectDatabase.Size = new System.Drawing.Size(75, 23);
            this.buttonConnectDatabase.TabIndex = 17;
            this.buttonConnectDatabase.Text = "连接";
            this.buttonConnectDatabase.UseVisualStyleBackColor = true;
            this.buttonConnectDatabase.Click += new System.EventHandler(this.buttonConnectDatabase_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "表名";
            // 
            // textDataTable
            // 
            this.textDataTable.Enabled = false;
            this.textDataTable.Location = new System.Drawing.Point(210, 74);
            this.textDataTable.Name = "textDataTable";
            this.textDataTable.Size = new System.Drawing.Size(122, 21);
            this.textDataTable.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "库名";
            // 
            // textDataBase
            // 
            this.textDataBase.Location = new System.Drawing.Point(47, 74);
            this.textDataBase.Name = "textDataBase";
            this.textDataBase.Size = new System.Drawing.Size(122, 21);
            this.textDataBase.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "密码";
            // 
            // textDataPass
            // 
            this.textDataPass.Location = new System.Drawing.Point(210, 47);
            this.textDataPass.Name = "textDataPass";
            this.textDataPass.Size = new System.Drawing.Size(122, 21);
            this.textDataPass.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "用户";
            // 
            // textDataName
            // 
            this.textDataName.Location = new System.Drawing.Point(47, 47);
            this.textDataName.Name = "textDataName";
            this.textDataName.Size = new System.Drawing.Size(122, 21);
            this.textDataName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "端口";
            // 
            // textDataPort
            // 
            this.textDataPort.Location = new System.Drawing.Point(210, 20);
            this.textDataPort.Name = "textDataPort";
            this.textDataPort.Size = new System.Drawing.Size(122, 21);
            this.textDataPort.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "地址";
            // 
            // textDataAddress
            // 
            this.textDataAddress.Location = new System.Drawing.Point(47, 20);
            this.textDataAddress.Name = "textDataAddress";
            this.textDataAddress.Size = new System.Drawing.Size(122, 21);
            this.textDataAddress.TabIndex = 5;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(270, 101);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 4;
            this.button8.Text = "导出至文件";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonRefreshing);
            this.groupBox2.Controls.Add(this.buttonUpdateData);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.hashList);
            this.groupBox2.Location = new System.Drawing.Point(348, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 136);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "语言文件哈希值";
            // 
            // buttonRefreshing
            // 
            this.buttonRefreshing.Location = new System.Drawing.Point(270, 78);
            this.buttonRefreshing.Name = "buttonRefreshing";
            this.buttonRefreshing.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshing.TabIndex = 6;
            this.buttonRefreshing.Text = "刷新列表";
            this.buttonRefreshing.UseVisualStyleBackColor = true;
            this.buttonRefreshing.Click += new System.EventHandler(this.buttonRefreshing_Click);
            // 
            // buttonUpdateData
            // 
            this.buttonUpdateData.Enabled = false;
            this.buttonUpdateData.Location = new System.Drawing.Point(270, 107);
            this.buttonUpdateData.Name = "buttonUpdateData";
            this.buttonUpdateData.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateData.TabIndex = 5;
            this.buttonUpdateData.Text = "更新数据库";
            this.buttonUpdateData.UseVisualStyleBackColor = true;
            this.buttonUpdateData.Click += new System.EventHandler(this.buttonUpdateData_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(270, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "导入列表";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "导出列表";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // hashList
            // 
            this.hashList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerHash,
            this.headerName,
            this.headerState});
            this.hashList.Location = new System.Drawing.Point(6, 20);
            this.hashList.Name = "hashList";
            this.hashList.Size = new System.Drawing.Size(258, 110);
            this.hashList.TabIndex = 1;
            this.hashList.UseCompatibleStateImageBehavior = false;
            this.hashList.View = System.Windows.Forms.View.Details;
            this.hashList.SelectedIndexChanged += new System.EventHandler(this.hashList_SelectedIndexChanged);
            // 
            // headerHash
            // 
            this.headerHash.Text = "哈希值";
            this.headerHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.headerHash.Width = 100;
            // 
            // headerName
            // 
            this.headerName.Text = "语言";
            this.headerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // headerState
            // 
            this.headerState.Text = "状态";
            this.headerState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.buttonTemp);
            this.groupBox3.Controls.Add(this.buttonExportFile);
            this.groupBox3.Controls.Add(this.buttonFolderHandle);
            this.groupBox3.Controls.Add(this.buttonChooseFolder);
            this.groupBox3.Controls.Add(this.buttonChooseFile);
            this.groupBox3.Controls.Add(this.buttonExportFolder);
            this.groupBox3.Controls.Add(this.buttonFileHandle);
            this.groupBox3.Controls.Add(this.infoList);
            this.groupBox3.Controls.Add(this.filePath);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(330, 413);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文件操作";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(249, 69);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "释放内存";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // buttonTemp
            // 
            this.buttonTemp.Location = new System.Drawing.Point(249, 98);
            this.buttonTemp.Name = "buttonTemp";
            this.buttonTemp.Size = new System.Drawing.Size(75, 23);
            this.buttonTemp.TabIndex = 10;
            this.buttonTemp.Text = "----";
            this.buttonTemp.UseVisualStyleBackColor = true;
            this.buttonTemp.Click += new System.EventHandler(this.buttonTemp_Click);
            // 
            // buttonExportFile
            // 
            this.buttonExportFile.Location = new System.Drawing.Point(168, 98);
            this.buttonExportFile.Name = "buttonExportFile";
            this.buttonExportFile.Size = new System.Drawing.Size(75, 23);
            this.buttonExportFile.TabIndex = 9;
            this.buttonExportFile.Text = "输出打包";
            this.buttonExportFile.UseVisualStyleBackColor = true;
            // 
            // buttonFolderHandle
            // 
            this.buttonFolderHandle.Location = new System.Drawing.Point(87, 98);
            this.buttonFolderHandle.Name = "buttonFolderHandle";
            this.buttonFolderHandle.Size = new System.Drawing.Size(75, 23);
            this.buttonFolderHandle.TabIndex = 8;
            this.buttonFolderHandle.Text = "加载并打包";
            this.buttonFolderHandle.UseVisualStyleBackColor = true;
            this.buttonFolderHandle.Click += new System.EventHandler(this.buttonFolderHandle_Click);
            // 
            // buttonChooseFolder
            // 
            this.buttonChooseFolder.Location = new System.Drawing.Point(6, 98);
            this.buttonChooseFolder.Name = "buttonChooseFolder";
            this.buttonChooseFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseFolder.TabIndex = 7;
            this.buttonChooseFolder.Text = "选择文件夹";
            this.buttonChooseFolder.UseVisualStyleBackColor = true;
            this.buttonChooseFolder.Click += new System.EventHandler(this.buttonChooseFolder_Click);
            // 
            // buttonChooseFile
            // 
            this.buttonChooseFile.Location = new System.Drawing.Point(6, 69);
            this.buttonChooseFile.Name = "buttonChooseFile";
            this.buttonChooseFile.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseFile.TabIndex = 6;
            this.buttonChooseFile.Text = "选择文件";
            this.buttonChooseFile.UseVisualStyleBackColor = true;
            this.buttonChooseFile.Click += new System.EventHandler(this.buttonChooseFile_Click);
            // 
            // buttonExportFolder
            // 
            this.buttonExportFolder.Location = new System.Drawing.Point(168, 69);
            this.buttonExportFolder.Name = "buttonExportFolder";
            this.buttonExportFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonExportFolder.TabIndex = 5;
            this.buttonExportFolder.Text = "输出解包";
            this.buttonExportFolder.UseVisualStyleBackColor = true;
            this.buttonExportFolder.Click += new System.EventHandler(this.buttonExportFolder_Click);
            // 
            // buttonFileHandle
            // 
            this.buttonFileHandle.Location = new System.Drawing.Point(87, 69);
            this.buttonFileHandle.Name = "buttonFileHandle";
            this.buttonFileHandle.Size = new System.Drawing.Size(75, 23);
            this.buttonFileHandle.TabIndex = 4;
            this.buttonFileHandle.Text = "加载并解包";
            this.buttonFileHandle.UseVisualStyleBackColor = true;
            this.buttonFileHandle.Click += new System.EventHandler(this.buttonFileHandle_Click);
            // 
            // infoList
            // 
            this.infoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.infoList.Location = new System.Drawing.Point(6, 127);
            this.infoList.Name = "infoList";
            this.infoList.Size = new System.Drawing.Size(318, 280);
            this.infoList.TabIndex = 4;
            this.infoList.UseCompatibleStateImageBehavior = false;
            this.infoList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "哈希值";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "偏移";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "压缩大小";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "解压大小";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(7, 21);
            this.filePath.Multiline = true;
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(317, 42);
            this.filePath.TabIndex = 0;
            // 
            // textDebug
            // 
            this.textDebug.Location = new System.Drawing.Point(348, 290);
            this.textDebug.Multiline = true;
            this.textDebug.Name = "textDebug";
            this.textDebug.ReadOnly = true;
            this.textDebug.Size = new System.Drawing.Size(351, 105);
            this.textDebug.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(349, 401);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(350, 23);
            this.progressBar.TabIndex = 6;
            // 
            // ThisWarTranslaterMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 440);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textDebug);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ThisWarTranslaterMain";
            this.Text = "ThisWarTranslater";
            this.Load += new System.EventHandler(this.ThisWarTranslaterMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ListView hashList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader headerName;
        private System.Windows.Forms.ColumnHeader headerHash;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonFileHandle;
        public System.Windows.Forms.ListView infoList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.TextBox textDebug;
        public System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonExportFolder;
        private System.Windows.Forms.Button buttonChooseFolder;
        private System.Windows.Forms.Button buttonChooseFile;
        private System.Windows.Forms.Button buttonFolderHandle;
        private System.Windows.Forms.Button buttonExportFile;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonTemp;
        private System.Windows.Forms.Button buttonRefreshing;
        public System.Windows.Forms.ColumnHeader headerState;
        public System.Windows.Forms.Button buttonUpdateData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonConnectDatabase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textDataAddress;
        public System.Windows.Forms.TextBox textDataPort;
        public System.Windows.Forms.TextBox textDataPass;
        public System.Windows.Forms.TextBox textDataName;
        public System.Windows.Forms.TextBox textDataTable;
        public System.Windows.Forms.TextBox textDataBase;
        public System.Windows.Forms.ProgressBar progressBar;
    }
}

