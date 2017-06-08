namespace Test_2_Connection
{
    partial class Form21
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
            this.loginInfo = new System.Windows.Forms.GroupBox();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.textDBName = new System.Windows.Forms.TextBox();
            this.textPWD = new System.Windows.Forms.TextBox();
            this.textServerName = new System.Windows.Forms.TextBox();
            this.pwd = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.dbName = new System.Windows.Forms.Label();
            this.serverName = new System.Windows.Forms.Label();
            this.sqlLink = new System.Windows.Forms.RadioButton();
            this.winLink = new System.Windows.Forms.RadioButton();
            this.verification = new System.Windows.Forms.Label();
            this.link = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.loginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginInfo
            // 
            this.loginInfo.Controls.Add(this.textUserName);
            this.loginInfo.Controls.Add(this.textDBName);
            this.loginInfo.Controls.Add(this.textPWD);
            this.loginInfo.Controls.Add(this.textServerName);
            this.loginInfo.Controls.Add(this.pwd);
            this.loginInfo.Controls.Add(this.userName);
            this.loginInfo.Controls.Add(this.dbName);
            this.loginInfo.Controls.Add(this.serverName);
            this.loginInfo.Controls.Add(this.sqlLink);
            this.loginInfo.Controls.Add(this.winLink);
            this.loginInfo.Controls.Add(this.verification);
            this.loginInfo.Location = new System.Drawing.Point(33, 24);
            this.loginInfo.Name = "loginInfo";
            this.loginInfo.Size = new System.Drawing.Size(399, 236);
            this.loginInfo.TabIndex = 0;
            this.loginInfo.TabStop = false;
            this.loginInfo.Text = "登录信息";
            // 
            // textUserName
            // 
            this.textUserName.Location = new System.Drawing.Point(270, 115);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(100, 21);
            this.textUserName.TabIndex = 10;
            // 
            // textDBName
            // 
            this.textDBName.Location = new System.Drawing.Point(85, 171);
            this.textDBName.Name = "textDBName";
            this.textDBName.Size = new System.Drawing.Size(100, 21);
            this.textDBName.TabIndex = 9;
            // 
            // textPWD
            // 
            this.textPWD.Location = new System.Drawing.Point(270, 171);
            this.textPWD.Name = "textPWD";
            this.textPWD.Size = new System.Drawing.Size(100, 21);
            this.textPWD.TabIndex = 8;
            // 
            // textServerName
            // 
            this.textServerName.Location = new System.Drawing.Point(85, 115);
            this.textServerName.Name = "textServerName";
            this.textServerName.Size = new System.Drawing.Size(100, 21);
            this.textServerName.TabIndex = 7;
            // 
            // pwd
            // 
            this.pwd.AutoSize = true;
            this.pwd.Location = new System.Drawing.Point(222, 174);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(47, 12);
            this.pwd.TabIndex = 6;
            this.pwd.Text = "密 码：";
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(222, 118);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(53, 12);
            this.userName.TabIndex = 5;
            this.userName.Text = "用户名：";
            // 
            // dbName
            // 
            this.dbName.AutoSize = true;
            this.dbName.Location = new System.Drawing.Point(24, 174);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(65, 12);
            this.dbName.TabIndex = 4;
            this.dbName.Text = "数据库名：";
            // 
            // serverName
            // 
            this.serverName.AutoSize = true;
            this.serverName.Location = new System.Drawing.Point(24, 118);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(65, 12);
            this.serverName.TabIndex = 3;
            this.serverName.Text = "服务器名：";
            // 
            // sqlLink
            // 
            this.sqlLink.AutoSize = true;
            this.sqlLink.Location = new System.Drawing.Point(120, 55);
            this.sqlLink.Name = "sqlLink";
            this.sqlLink.Size = new System.Drawing.Size(113, 16);
            this.sqlLink.TabIndex = 2;
            this.sqlLink.TabStop = true;
            this.sqlLink.Text = "SQL Server 方式";
            this.sqlLink.UseVisualStyleBackColor = true;
            this.sqlLink.CheckedChanged += new System.EventHandler(this.sqlLink_CheckedChanged);
            // 
            // winLink
            // 
            this.winLink.AutoSize = true;
            this.winLink.Location = new System.Drawing.Point(120, 33);
            this.winLink.Name = "winLink";
            this.winLink.Size = new System.Drawing.Size(95, 16);
            this.winLink.TabIndex = 1;
            this.winLink.TabStop = true;
            this.winLink.Text = "Windows 方式";
            this.winLink.UseVisualStyleBackColor = true;
            this.winLink.CheckedChanged += new System.EventHandler(this.winLink_CheckedChanged);
            // 
            // verification
            // 
            this.verification.AutoSize = true;
            this.verification.Location = new System.Drawing.Point(24, 33);
            this.verification.Name = "verification";
            this.verification.Size = new System.Drawing.Size(53, 12);
            this.verification.TabIndex = 0;
            this.verification.Text = "验证方式";
            // 
            // link
            // 
            this.link.Location = new System.Drawing.Point(59, 279);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(75, 23);
            this.link.TabIndex = 1;
            this.link.Text = "连 接";
            this.link.UseVisualStyleBackColor = true;
            this.link.Click += new System.EventHandler(this.link_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(328, 279);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 2;
            this.exit.Text = "退 出";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Form21
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 323);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.link);
            this.Controls.Add(this.loginInfo);
            this.Name = "Form21";
            this.Text = "实验 2-1 连接SQL数据库";
            this.Load += new System.EventHandler(this.Form21_Load);
            this.loginInfo.ResumeLayout(false);
            this.loginInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox loginInfo;
        private System.Windows.Forms.Button link;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.TextBox textDBName;
        private System.Windows.Forms.TextBox textPWD;
        private System.Windows.Forms.TextBox textServerName;
        private System.Windows.Forms.Label pwd;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label dbName;
        private System.Windows.Forms.Label serverName;
        private System.Windows.Forms.RadioButton sqlLink;
        private System.Windows.Forms.RadioButton winLink;
        private System.Windows.Forms.Label verification;
    }
}

