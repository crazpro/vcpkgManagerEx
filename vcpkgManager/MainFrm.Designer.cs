namespace vcpkgManager
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReflush = new System.Windows.Forms.Button();
            this.btnRemovePkg = new System.Windows.Forms.Button();
            this.pkglistView = new System.Windows.Forms.ListView();
            this.pkgName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pkgVer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pkgText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.searchlistView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSetup = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.platformChkBox = new System.Windows.Forms.CheckedListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInstallAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReflush);
            this.groupBox1.Controls.Add(this.btnRemovePkg);
            this.groupBox1.Controls.Add(this.pkglistView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 500);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "包列表";
            // 
            // btnReflush
            // 
            this.btnReflush.Location = new System.Drawing.Point(6, 471);
            this.btnReflush.Name = "btnReflush";
            this.btnReflush.Size = new System.Drawing.Size(150, 23);
            this.btnReflush.TabIndex = 2;
            this.btnReflush.Text = "刷新列表";
            this.btnReflush.UseVisualStyleBackColor = true;
            this.btnReflush.Click += new System.EventHandler(this.btnReflush_Click);
            // 
            // btnRemovePkg
            // 
            this.btnRemovePkg.Location = new System.Drawing.Point(259, 471);
            this.btnRemovePkg.Name = "btnRemovePkg";
            this.btnRemovePkg.Size = new System.Drawing.Size(150, 23);
            this.btnRemovePkg.TabIndex = 1;
            this.btnRemovePkg.Text = "移除选择包";
            this.btnRemovePkg.UseVisualStyleBackColor = true;
            this.btnRemovePkg.Click += new System.EventHandler(this.btnRemovePkg_Click);
            // 
            // pkglistView
            // 
            this.pkglistView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pkglistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pkgName,
            this.pkgVer,
            this.pkgText});
            this.pkglistView.FullRowSelect = true;
            this.pkglistView.GridLines = true;
            this.pkglistView.HideSelection = false;
            this.pkglistView.Location = new System.Drawing.Point(6, 20);
            this.pkglistView.MultiSelect = false;
            this.pkglistView.Name = "pkglistView";
            this.pkglistView.Size = new System.Drawing.Size(403, 445);
            this.pkglistView.TabIndex = 0;
            this.pkglistView.UseCompatibleStateImageBehavior = false;
            this.pkglistView.View = System.Windows.Forms.View.Details;
            // 
            // pkgName
            // 
            this.pkgName.Text = "包名称";
            this.pkgName.Width = 100;
            // 
            // pkgVer
            // 
            this.pkgVer.Text = "版本号";
            this.pkgVer.Width = 100;
            // 
            // pkgText
            // 
            this.pkgText.Text = "包描述";
            this.pkgText.Width = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.searchlistView);
            this.groupBox2.Controls.Add(this.btnSetup);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.platformChkBox);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtSearchKey);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(433, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 382);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检索安装包";
            // 
            // searchlistView
            // 
            this.searchlistView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.searchlistView.FullRowSelect = true;
            this.searchlistView.GridLines = true;
            this.searchlistView.HideSelection = false;
            this.searchlistView.Location = new System.Drawing.Point(6, 61);
            this.searchlistView.MultiSelect = false;
            this.searchlistView.Name = "searchlistView";
            this.searchlistView.Size = new System.Drawing.Size(433, 175);
            this.searchlistView.TabIndex = 3;
            this.searchlistView.UseCompatibleStateImageBehavior = false;
            this.searchlistView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "包名称";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "版本号";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "包描述";
            this.columnHeader3.Width = 200;
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(280, 347);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(161, 24);
            this.btnSetup.TabIndex = 7;
            this.btnSetup.Text = "安装包";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "目标平台";
            // 
            // platformChkBox
            // 
            this.platformChkBox.CheckOnClick = true;
            this.platformChkBox.FormattingEnabled = true;
            this.platformChkBox.Items.AddRange(new object[] {
            "x64-windows-static",
            "x64-windows",
            "x86-windows-static",
            "x86-windows"});
            this.platformChkBox.Location = new System.Drawing.Point(6, 257);
            this.platformChkBox.Name = "platformChkBox";
            this.platformChkBox.Size = new System.Drawing.Size(435, 84);
            this.platformChkBox.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(374, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Location = new System.Drawing.Point(86, 32);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(282, 21);
            this.txtSearchKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "包关键字：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnInstallAll);
            this.groupBox3.Location = new System.Drawing.Point(433, 400);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(447, 112);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "全局操作";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "本程序为vcpkg程序管理工具，代码编写:koangel\r\n";
            // 
            // btnInstallAll
            // 
            this.btnInstallAll.Location = new System.Drawing.Point(8, 29);
            this.btnInstallAll.Name = "btnInstallAll";
            this.btnInstallAll.Size = new System.Drawing.Size(149, 23);
            this.btnInstallAll.TabIndex = 0;
            this.btnInstallAll.Text = "同步库到VS";
            this.btnInstallAll.UseVisualStyleBackColor = true;
            this.btnInstallAll.Click += new System.EventHandler(this.btnInstallAll_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 524);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "vcpkg管理工具集 1.2 by koangel";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView pkglistView;
        private System.Windows.Forms.ColumnHeader pkgName;
        private System.Windows.Forms.ColumnHeader pkgText;
        private System.Windows.Forms.ColumnHeader pkgVer;
        private System.Windows.Forms.Button btnRemovePkg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchKey;
        private System.Windows.Forms.CheckedListBox platformChkBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReflush;
        private System.Windows.Forms.Button btnInstallAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView searchlistView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

