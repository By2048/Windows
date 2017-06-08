namespace 学生信息管理系统
{
    partial class AddFaculty
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
            this.textAddFaculty = new System.Windows.Forms.TextBox();
            this.butSure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textAddFaculty
            // 
            this.textAddFaculty.Location = new System.Drawing.Point(13, 13);
            this.textAddFaculty.Name = "textAddFaculty";
            this.textAddFaculty.Size = new System.Drawing.Size(166, 21);
            this.textAddFaculty.TabIndex = 0;
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(185, 11);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(55, 23);
            this.butSure.TabIndex = 1;
            this.butSure.Text = "确定";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // AddFaculty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 46);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.textAddFaculty);
            this.Name = "AddFaculty";
            this.Text = "AddFaculty";
            this.Load += new System.EventHandler(this.AddFaculty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textAddFaculty;
        private System.Windows.Forms.Button butSure;
    }
}