namespace Test_2_Connection
{
    partial class Form23
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginInfo = new System.Windows.Forms.GroupBox();
            this.textPWD = new System.Windows.Forms.TextBox();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.textDBName = new System.Windows.Forms.TextBox();
            this.PWD = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.DBName = new System.Windows.Forms.Label();
            this.link = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.loginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginInfo
            // 
            this.loginInfo.Controls.Add(this.textPWD);
            this.loginInfo.Controls.Add(this.textUserName);
            this.loginInfo.Controls.Add(this.textDBName);
            this.loginInfo.Controls.Add(this.PWD);
            this.loginInfo.Controls.Add(this.userName);
            this.loginInfo.Controls.Add(this.DBName);
            this.loginInfo.Location = new System.Drawing.Point(12, 12);
            this.loginInfo.Name = "loginInfo";
            this.loginInfo.Size = new System.Drawing.Size(197, 157);
            this.loginInfo.TabIndex = 0;
            this.loginInfo.TabStop = false;
            this.loginInfo.Text = "登录信息";
            // 
            // textPWD
            // 
            this.textPWD.Location = new System.Drawing.Point(74, 117);
            this.textPWD.Name = "textPWD";
            this.textPWD.Size = new System.Drawing.Size(100, 21);
            this.textPWD.TabIndex = 5;
            // 
            // textUserName
            // 
            this.textUserName.Location = new System.Drawing.Point(74, 72);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(100, 21);
            this.textUserName.TabIndex = 4;
            // 
            // textDBName
            // 
            this.textDBName.Location = new System.Drawing.Point(74, 30);
            this.textDBName.Name = "textDBName";
            this.textDBName.Size = new System.Drawing.Size(100, 21);
            this.textDBName.TabIndex = 3;
            // 
            // PWD
            // 
            this.PWD.AutoSize = true;
            this.PWD.Location = new System.Drawing.Point(15, 120);
            this.PWD.Name = "PWD";
            this.PWD.Size = new System.Drawing.Size(35, 12);
            this.PWD.TabIndex = 2;
            this.PWD.Text = "密 码";
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(15, 75);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(41, 12);
            this.userName.TabIndex = 1;
            this.userName.Text = "用户名";
            // 
            // DBName
            // 
            this.DBName.AutoSize = true;
            this.DBName.Location = new System.Drawing.Point(15, 33);
            this.DBName.Name = "DBName";
            this.DBName.Size = new System.Drawing.Size(53, 12);
            this.DBName.TabIndex = 0;
            this.DBName.Text = "数据库名";
            // 
            // link
            // 
            this.link.Location = new System.Drawing.Point(12, 186);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(75, 23);
            this.link.TabIndex = 1;
            this.link.Text = "连 接";
            this.link.UseVisualStyleBackColor = true;
            this.link.Click += new System.EventHandler(this.link_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(134, 186);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 2;
            this.exit.Text = "退 出";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Form23
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 222);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.link);
            this.Controls.Add(this.loginInfo);
            this.Name = "Form23";
            this.Text = "实验 2-3 连接Oracle数据源";
            this.Load += new System.EventHandler(this.Form23_Load);
            this.loginInfo.ResumeLayout(false);
            this.loginInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox loginInfo;
        private System.Windows.Forms.TextBox textPWD;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.TextBox textDBName;
        private System.Windows.Forms.Label PWD;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label DBName;
        private System.Windows.Forms.Button link;
        private System.Windows.Forms.Button exit;
    }
}