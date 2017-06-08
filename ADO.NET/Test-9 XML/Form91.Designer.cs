namespace Test_9_XML
{
    partial class Form91
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
            this.listBoxBook = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxBook
            // 
            this.listBoxBook.FormattingEnabled = true;
            this.listBoxBook.ItemHeight = 12;
            this.listBoxBook.Location = new System.Drawing.Point(43, 32);
            this.listBoxBook.Name = "listBoxBook";
            this.listBoxBook.Size = new System.Drawing.Size(193, 196);
            this.listBoxBook.TabIndex = 0;
            // 
            // Form91
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.listBoxBook);
            this.Name = "Form91";
            this.Text = "Form91";
            this.Load += new System.EventHandler(this.Form91_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxBook;
    }
}

