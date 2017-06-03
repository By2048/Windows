namespace WinFormTest
{
    partial class Form12
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.Del = new System.Windows.Forms.Button();
            this.Write = new System.Windows.Forms.Button();
            this.Show = new System.Windows.Forms.Button();
            this.LoadJson = new System.Windows.Forms.Button();
            this.btnAlId = new System.Windows.Forms.Button();
            this.btnTestShow = new System.Windows.Forms.Button();
            this.btnMaxId = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(48, 12);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(469, 176);
            this.textBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(306, 240);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(157, 282);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 4;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Del
            // 
            this.Del.Location = new System.Drawing.Point(255, 281);
            this.Del.Name = "Del";
            this.Del.Size = new System.Drawing.Size(75, 23);
            this.Del.TabIndex = 5;
            this.Del.Text = "Del";
            this.Del.UseVisualStyleBackColor = true;
            this.Del.Click += new System.EventHandler(this.Del_Click);
            // 
            // Write
            // 
            this.Write.Location = new System.Drawing.Point(354, 282);
            this.Write.Name = "Write";
            this.Write.Size = new System.Drawing.Size(75, 23);
            this.Write.TabIndex = 7;
            this.Write.Text = "Write";
            this.Write.UseVisualStyleBackColor = true;
            this.Write.Click += new System.EventHandler(this.Write_Click);
            // 
            // Show
            // 
            this.Show.Location = new System.Drawing.Point(460, 281);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(75, 23);
            this.Show.TabIndex = 8;
            this.Show.Text = "Show";
            this.Show.UseVisualStyleBackColor = true;
            this.Show.Click += new System.EventHandler(this.Show_Click);
            // 
            // LoadJson
            // 
            this.LoadJson.Location = new System.Drawing.Point(48, 282);
            this.LoadJson.Name = "LoadJson";
            this.LoadJson.Size = new System.Drawing.Size(75, 23);
            this.LoadJson.TabIndex = 9;
            this.LoadJson.Text = "LoadJson";
            this.LoadJson.UseVisualStyleBackColor = true;
            this.LoadJson.Click += new System.EventHandler(this.LoadJson_Click);
            // 
            // btnAlId
            // 
            this.btnAlId.Location = new System.Drawing.Point(48, 400);
            this.btnAlId.Name = "btnAlId";
            this.btnAlId.Size = new System.Drawing.Size(75, 23);
            this.btnAlId.TabIndex = 10;
            this.btnAlId.Text = "AllId";
            this.btnAlId.UseVisualStyleBackColor = true;
            this.btnAlId.Click += new System.EventHandler(this.btnAllId_Click);
            // 
            // btnTestShow
            // 
            this.btnTestShow.Location = new System.Drawing.Point(167, 400);
            this.btnTestShow.Name = "btnTestShow";
            this.btnTestShow.Size = new System.Drawing.Size(75, 23);
            this.btnTestShow.TabIndex = 11;
            this.btnTestShow.Text = "TestShow";
            this.btnTestShow.UseVisualStyleBackColor = true;
            this.btnTestShow.Click += new System.EventHandler(this.btnTestShow_Click);
            // 
            // btnMaxId
            // 
            this.btnMaxId.Location = new System.Drawing.Point(280, 400);
            this.btnMaxId.Name = "btnMaxId";
            this.btnMaxId.Size = new System.Drawing.Size(75, 23);
            this.btnMaxId.TabIndex = 12;
            this.btnMaxId.Text = "MaxId";
            this.btnMaxId.UseVisualStyleBackColor = true;
            this.btnMaxId.Click += new System.EventHandler(this.btnMaxId_Click);
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 482);
            this.Controls.Add(this.btnMaxId);
            this.Controls.Add(this.btnTestShow);
            this.Controls.Add(this.btnAlId);
            this.Controls.Add(this.LoadJson);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.Write);
            this.Controls.Add(this.Del);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox);
            this.Name = "Form12";
            this.Text = "Form12";
            this.Load += new System.EventHandler(this.Form12_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Del;
        private System.Windows.Forms.Button Write;
        private System.Windows.Forms.Button Show;
        private System.Windows.Forms.Button LoadJson;
        private System.Windows.Forms.Button btnAlId;
        private System.Windows.Forms.Button btnTestShow;
        private System.Windows.Forms.Button btnMaxId;
    }
}