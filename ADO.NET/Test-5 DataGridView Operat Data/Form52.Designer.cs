namespace Test_5_DataGridView_Operat_Data
{
    partial class Form52
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
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.ColBookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBookPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBookPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBooks
            // 
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColBookName,
            this.ColBookAuthor,
            this.ColBookPublisher,
            this.ColBookPrice});
            this.dgvBooks.Location = new System.Drawing.Point(12, 12);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.RowTemplate.Height = 23;
            this.dgvBooks.Size = new System.Drawing.Size(443, 219);
            this.dgvBooks.TabIndex = 0;
            // 
            // ColBookName
            // 
            this.ColBookName.DataPropertyName = "BookName";
            this.ColBookName.HeaderText = "BookName";
            this.ColBookName.Name = "ColBookName";
            // 
            // ColBookAuthor
            // 
            this.ColBookAuthor.DataPropertyName = "Author";
            this.ColBookAuthor.HeaderText = "Author";
            this.ColBookAuthor.Name = "ColBookAuthor";
            // 
            // ColBookPublisher
            // 
            this.ColBookPublisher.DataPropertyName = "Publisher";
            this.ColBookPublisher.HeaderText = "Publisher";
            this.ColBookPublisher.Name = "ColBookPublisher";
            // 
            // ColBookPrice
            // 
            this.ColBookPrice.DataPropertyName = "Price";
            this.ColBookPrice.HeaderText = "Price";
            this.ColBookPrice.Name = "ColBookPrice";
            // 
            // Form52
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 264);
            this.Controls.Add(this.dgvBooks);
            this.Name = "Form52";
            this.Text = "Test-5 DataGridView Operat Data";
            this.Load += new System.EventHandler(this.Form52_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBookAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBookPublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBookPrice;
    }
}