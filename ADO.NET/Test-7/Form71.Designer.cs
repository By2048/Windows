namespace Test_7
{
    partial class Form71
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.labID = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.labBirthday = new System.Windows.Forms.Label();
            this.labJob = new System.Windows.Forms.Label();
            this.labSex = new System.Windows.Forms.Label();
            this.labDepartment = new System.Windows.Forms.Label();
            this.textID = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.textBirthday = new System.Windows.Forms.TextBox();
            this.textJob = new System.Windows.Forms.TextBox();
            this.textSex = new System.Windows.Forms.TextBox();
            this.textDepartment = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(29, 268);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 0;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(151, 268);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // labID
            // 
            this.labID.AutoSize = true;
            this.labID.Location = new System.Drawing.Point(27, 34);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(53, 12);
            this.labID.TabIndex = 2;
            this.labID.Text = "职工编号";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(27, 71);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(29, 12);
            this.labName.TabIndex = 3;
            this.labName.Text = "姓名";
            // 
            // labBirthday
            // 
            this.labBirthday.AutoSize = true;
            this.labBirthday.Location = new System.Drawing.Point(27, 106);
            this.labBirthday.Name = "labBirthday";
            this.labBirthday.Size = new System.Drawing.Size(53, 12);
            this.labBirthday.TabIndex = 4;
            this.labBirthday.Text = "出生日期";
            // 
            // labJob
            // 
            this.labJob.AutoSize = true;
            this.labJob.Location = new System.Drawing.Point(27, 179);
            this.labJob.Name = "labJob";
            this.labJob.Size = new System.Drawing.Size(29, 12);
            this.labJob.TabIndex = 5;
            this.labJob.Text = "职称";
            // 
            // labSex
            // 
            this.labSex.AutoSize = true;
            this.labSex.Location = new System.Drawing.Point(27, 142);
            this.labSex.Name = "labSex";
            this.labSex.Size = new System.Drawing.Size(29, 12);
            this.labSex.TabIndex = 6;
            this.labSex.Text = "性别";
            // 
            // labDepartment
            // 
            this.labDepartment.AutoSize = true;
            this.labDepartment.Location = new System.Drawing.Point(27, 222);
            this.labDepartment.Name = "labDepartment";
            this.labDepartment.Size = new System.Drawing.Size(29, 12);
            this.labDepartment.TabIndex = 7;
            this.labDepartment.Text = "部门";
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(86, 31);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(140, 21);
            this.textID.TabIndex = 8;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(86, 68);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(140, 21);
            this.textName.TabIndex = 9;
            // 
            // textBirthday
            // 
            this.textBirthday.Location = new System.Drawing.Point(86, 103);
            this.textBirthday.Name = "textBirthday";
            this.textBirthday.Size = new System.Drawing.Size(140, 21);
            this.textBirthday.TabIndex = 10;
            // 
            // textJob
            // 
            this.textJob.Location = new System.Drawing.Point(86, 176);
            this.textJob.Name = "textJob";
            this.textJob.Size = new System.Drawing.Size(140, 21);
            this.textJob.TabIndex = 11;
            // 
            // textSex
            // 
            this.textSex.Location = new System.Drawing.Point(86, 139);
            this.textSex.Name = "textSex";
            this.textSex.Size = new System.Drawing.Size(140, 21);
            this.textSex.TabIndex = 12;
            // 
            // textDepartment
            // 
            this.textDepartment.Location = new System.Drawing.Point(86, 219);
            this.textDepartment.Name = "textDepartment";
            this.textDepartment.Size = new System.Drawing.Size(140, 21);
            this.textDepartment.TabIndex = 13;
            // 
            // Form71
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 313);
            this.Controls.Add(this.textDepartment);
            this.Controls.Add(this.textSex);
            this.Controls.Add(this.textJob);
            this.Controls.Add(this.textBirthday);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textID);
            this.Controls.Add(this.labDepartment);
            this.Controls.Add(this.labSex);
            this.Controls.Add(this.labJob);
            this.Controls.Add(this.labBirthday);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.labID);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Name = "Form71";
            this.Text = "Test-7";
            this.Load += new System.EventHandler(this.Form71_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labBirthday;
        private System.Windows.Forms.Label labJob;
        private System.Windows.Forms.Label labSex;
        private System.Windows.Forms.Label labDepartment;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textBirthday;
        private System.Windows.Forms.TextBox textJob;
        private System.Windows.Forms.TextBox textSex;
        private System.Windows.Forms.TextBox textDepartment;
    }
}

