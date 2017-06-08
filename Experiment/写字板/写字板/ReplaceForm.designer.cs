namespace 写字板
{
    partial class ReplaceForm
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
            this.tbbfind1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.next = new System.Windows.Forms.Button();
            this.last = new System.Windows.Forms.Button();
            this.labelFindText = new System.Windows.Forms.Label();
            this.textBoxFindTextOnly = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxReplaceText = new System.Windows.Forms.TextBox();
            this.textBoxFindText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.replaceall = new System.Windows.Forms.Button();
            this.replace = new System.Windows.Forms.Button();
            this.tbbfind1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbbfind1
            // 
            this.tbbfind1.Controls.Add(this.tabPage1);
            this.tbbfind1.Controls.Add(this.tabPage2);
            this.tbbfind1.Location = new System.Drawing.Point(12, 12);
            this.tbbfind1.Name = "tbbfind1";
            this.tbbfind1.SelectedIndex = 0;
            this.tbbfind1.Size = new System.Drawing.Size(281, 174);
            this.tbbfind1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.next);
            this.tabPage1.Controls.Add(this.last);
            this.tabPage1.Controls.Add(this.labelFindText);
            this.tabPage1.Controls.Add(this.textBoxFindTextOnly);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(273, 148);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "查找";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(160, 106);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 7;
            this.next.Text = "下一个";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // last
            // 
            this.last.Location = new System.Drawing.Point(28, 106);
            this.last.Name = "last";
            this.last.Size = new System.Drawing.Size(75, 23);
            this.last.TabIndex = 9;
            this.last.Text = "上一个";
            this.last.UseVisualStyleBackColor = true;
            this.last.Click += new System.EventHandler(this.last_Click);
            // 
            // labelFindText
            // 
            this.labelFindText.AutoSize = true;
            this.labelFindText.Location = new System.Drawing.Point(26, 49);
            this.labelFindText.Name = "labelFindText";
            this.labelFindText.Size = new System.Drawing.Size(53, 12);
            this.labelFindText.TabIndex = 3;
            this.labelFindText.Text = "查找内容";
            // 
            // textBoxFindTextOnly
            // 
            this.textBoxFindTextOnly.Location = new System.Drawing.Point(85, 46);
            this.textBoxFindTextOnly.Name = "textBoxFindTextOnly";
            this.textBoxFindTextOnly.Size = new System.Drawing.Size(150, 21);
            this.textBoxFindTextOnly.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxReplaceText);
            this.tabPage2.Controls.Add(this.textBoxFindText);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.replaceall);
            this.tabPage2.Controls.Add(this.replace);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(273, 148);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "替换";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxReplaceText
            // 
            this.textBoxReplaceText.Location = new System.Drawing.Point(85, 62);
            this.textBoxReplaceText.Name = "textBoxReplaceText";
            this.textBoxReplaceText.Size = new System.Drawing.Size(157, 21);
            this.textBoxReplaceText.TabIndex = 12;
            // 
            // textBoxFindText
            // 
            this.textBoxFindText.Location = new System.Drawing.Point(85, 21);
            this.textBoxFindText.Name = "textBoxFindText";
            this.textBoxFindText.Size = new System.Drawing.Size(157, 21);
            this.textBoxFindText.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "替换为";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "查找内容";
            // 
            // replaceall
            // 
            this.replaceall.Location = new System.Drawing.Point(167, 109);
            this.replaceall.Name = "replaceall";
            this.replaceall.Size = new System.Drawing.Size(75, 23);
            this.replaceall.TabIndex = 8;
            this.replaceall.Text = "全部替换";
            this.replaceall.UseVisualStyleBackColor = true;
            this.replaceall.Click += new System.EventHandler(this.replaceall_Click);
            // 
            // replace
            // 
            this.replace.Location = new System.Drawing.Point(25, 109);
            this.replace.Name = "replace";
            this.replace.Size = new System.Drawing.Size(75, 23);
            this.replace.TabIndex = 5;
            this.replace.Text = "替换";
            this.replace.UseVisualStyleBackColor = true;
            this.replace.Click += new System.EventHandler(this.replace_Click);
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 200);
            this.Controls.Add(this.tbbfind1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "1";
            this.Load += new System.EventHandler(this.ReplaceForm_Load);
            this.tbbfind1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbbfind1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button replace;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button replaceall;
        private System.Windows.Forms.Button last;
        private System.Windows.Forms.Label labelFindText;
        private System.Windows.Forms.TextBox textBoxFindTextOnly;
        private System.Windows.Forms.TextBox textBoxReplaceText;
        private System.Windows.Forms.TextBox textBoxFindText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}