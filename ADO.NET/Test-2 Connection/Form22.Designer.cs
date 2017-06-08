namespace Test_2_Connection
{
    partial class Form22
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
            this.link = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.file = new System.Windows.Forms.Label();
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.Button();
            this.loginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginInfo
            // 
            this.loginInfo.Controls.Add(this.openFile);
            this.loginInfo.Controls.Add(this.textFilePath);
            this.loginInfo.Controls.Add(this.file);
            this.loginInfo.Location = new System.Drawing.Point(12, 12);
            this.loginInfo.Name = "loginInfo";
            this.loginInfo.Size = new System.Drawing.Size(265, 69);
            this.loginInfo.TabIndex = 0;
            this.loginInfo.TabStop = false;
            this.loginInfo.Text = "登录信息";
            // 
            // link
            // 
            this.link.Location = new System.Drawing.Point(20, 96);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(75, 23);
            this.link.TabIndex = 1;
            this.link.Text = "连 接";
            this.link.UseVisualStyleBackColor = true;
            this.link.Click += new System.EventHandler(this.link_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(185, 96);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 2;
            this.exit.Text = "退 出";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // file
            // 
            this.file.AutoSize = true;
            this.file.Location = new System.Drawing.Point(6, 36);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(53, 12);
            this.file.TabIndex = 0;
            this.file.Text = "数据文件";
            // 
            // textFilePath
            // 
            this.textFilePath.Location = new System.Drawing.Point(63, 33);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.Size = new System.Drawing.Size(145, 21);
            this.textFilePath.TabIndex = 1;
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(214, 31);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(34, 23);
            this.openFile.TabIndex = 2;
            this.openFile.Text = "...";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // Form22
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 129);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.link);
            this.Controls.Add(this.loginInfo);
            this.Name = "Form22";
            this.Text = "实验 2-2 连接Access数据源";
            this.Load += new System.EventHandler(this.Form22_Load);
            this.loginInfo.ResumeLayout(false);
            this.loginInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox loginInfo;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.TextBox textFilePath;
        private System.Windows.Forms.Label file;
        private System.Windows.Forms.Button link;
        private System.Windows.Forms.Button exit;
    }
}