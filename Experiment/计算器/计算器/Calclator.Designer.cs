namespace 计算器
{
    partial class Calclator
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
            this.calc = new System.Windows.Forms.Button();
            this.binary = new System.Windows.Forms.Button();
            this.square = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button22 = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cleanEnter = new System.Windows.Forms.Button();
            this.clean = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.calcExpress = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.textResult = new System.Windows.Forms.TextBox();
            this.textFormula = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // calc
            // 
            this.calc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.calc.Location = new System.Drawing.Point(234, 146);
            this.calc.Margin = new System.Windows.Forms.Padding(0);
            this.calc.Name = "calc";
            this.tableLayoutPanel1.SetRowSpan(this.calc, 2);
            this.calc.Size = new System.Drawing.Size(40, 87);
            this.calc.TabIndex = 17;
            this.calc.TabStop = false;
            this.calc.Text = "=";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // binary
            // 
            this.binary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.binary.Location = new System.Drawing.Point(234, 97);
            this.binary.Margin = new System.Windows.Forms.Padding(0);
            this.binary.Name = "binary";
            this.binary.Size = new System.Drawing.Size(40, 40);
            this.binary.TabIndex = 14;
            this.binary.TabStop = false;
            this.binary.Text = "B";
            this.binary.UseVisualStyleBackColor = true;
            this.binary.Click += new System.EventHandler(this.binary_Click);
            // 
            // square
            // 
            this.square.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.square.Location = new System.Drawing.Point(234, 50);
            this.square.Margin = new System.Windows.Forms.Padding(0);
            this.square.Name = "square";
            this.square.Size = new System.Drawing.Size(40, 40);
            this.square.TabIndex = 9;
            this.square.TabStop = false;
            this.square.Text = "√";
            this.square.UseVisualStyleBackColor = true;
            this.square.Click += new System.EventHandler(this.square_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.button22, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.back, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cleanEnter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.clean, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.calcExpress, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button7, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.square, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.button12, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.button11, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button13, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button14, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button17, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.binary, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.calc, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.button16, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button19, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button20, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button24, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.button25, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 123);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 239);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button22
            // 
            this.button22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.button22, 2);
            this.button22.Location = new System.Drawing.Point(8, 193);
            this.button22.Margin = new System.Windows.Forms.Padding(0);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(96, 40);
            this.button22.TabIndex = 21;
            this.button22.TabStop = false;
            this.button22.Text = "0";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.Number_Click);
            // 
            // back
            // 
            this.back.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.back.Location = new System.Drawing.Point(8, 3);
            this.back.Margin = new System.Windows.Forms.Padding(0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(40, 40);
            this.back.TabIndex = 0;
            this.back.TabStop = false;
            this.back.Text = "<--";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(8, 50);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Text = "7";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Number_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(64, 50);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 2;
            this.button3.TabStop = false;
            this.button3.Text = "8";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Number_Click);
            // 
            // cleanEnter
            // 
            this.cleanEnter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cleanEnter.Location = new System.Drawing.Point(64, 3);
            this.cleanEnter.Margin = new System.Windows.Forms.Padding(0);
            this.cleanEnter.Name = "cleanEnter";
            this.cleanEnter.Size = new System.Drawing.Size(40, 40);
            this.cleanEnter.TabIndex = 4;
            this.cleanEnter.TabStop = false;
            this.cleanEnter.Text = "CE";
            this.cleanEnter.UseVisualStyleBackColor = true;
            this.cleanEnter.Click += new System.EventHandler(this.cleanEnter_Click);
            // 
            // clean
            // 
            this.clean.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clean.Location = new System.Drawing.Point(120, 3);
            this.clean.Margin = new System.Windows.Forms.Padding(0);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(40, 40);
            this.clean.TabIndex = 3;
            this.clean.TabStop = false;
            this.clean.Text = "C";
            this.clean.UseVisualStyleBackColor = true;
            this.clean.Click += new System.EventHandler(this.clean_Click);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.Location = new System.Drawing.Point(120, 50);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 40);
            this.button6.TabIndex = 5;
            this.button6.TabStop = false;
            this.button6.Text = "9";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Number_Click);
            // 
            // calcExpress
            // 
            this.calcExpress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.calcExpress, 2);
            this.calcExpress.Location = new System.Drawing.Point(175, 3);
            this.calcExpress.Margin = new System.Windows.Forms.Padding(0);
            this.calcExpress.Name = "calcExpress";
            this.calcExpress.Size = new System.Drawing.Size(101, 40);
            this.calcExpress.TabIndex = 8;
            this.calcExpress.TabStop = false;
            this.calcExpress.Text = "Calc Express";
            this.calcExpress.UseVisualStyleBackColor = true;
            this.calcExpress.Click += new System.EventHandler(this.calcExpress_Click);
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.Location = new System.Drawing.Point(176, 50);
            this.button7.Margin = new System.Windows.Forms.Padding(0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(40, 40);
            this.button7.TabIndex = 6;
            this.button7.TabStop = false;
            this.button7.Text = "/";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.operat_Click);
            // 
            // button12
            // 
            this.button12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button12.Location = new System.Drawing.Point(176, 144);
            this.button12.Margin = new System.Windows.Forms.Padding(0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(40, 40);
            this.button12.TabIndex = 11;
            this.button12.TabStop = false;
            this.button12.Text = "-";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.operat_Click);
            // 
            // button11
            // 
            this.button11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button11.Location = new System.Drawing.Point(120, 97);
            this.button11.Margin = new System.Windows.Forms.Padding(0);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(40, 40);
            this.button11.TabIndex = 10;
            this.button11.TabStop = false;
            this.button11.Text = "6";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Number_Click);
            // 
            // button13
            // 
            this.button13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button13.Location = new System.Drawing.Point(64, 97);
            this.button13.Margin = new System.Windows.Forms.Padding(0);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(40, 40);
            this.button13.TabIndex = 12;
            this.button13.TabStop = false;
            this.button13.Text = "5";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.Number_Click);
            // 
            // button14
            // 
            this.button14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button14.Location = new System.Drawing.Point(8, 97);
            this.button14.Margin = new System.Windows.Forms.Padding(0);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(40, 40);
            this.button14.TabIndex = 13;
            this.button14.TabStop = false;
            this.button14.Text = "4";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.Number_Click);
            // 
            // button17
            // 
            this.button17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button17.Location = new System.Drawing.Point(176, 97);
            this.button17.Margin = new System.Windows.Forms.Padding(0);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(40, 40);
            this.button17.TabIndex = 16;
            this.button17.TabStop = false;
            this.button17.Text = "*";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.operat_Click);
            // 
            // button16
            // 
            this.button16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button16.Location = new System.Drawing.Point(120, 144);
            this.button16.Margin = new System.Windows.Forms.Padding(0);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(40, 40);
            this.button16.TabIndex = 15;
            this.button16.TabStop = false;
            this.button16.Text = "3";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.Number_Click);
            // 
            // button19
            // 
            this.button19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button19.Location = new System.Drawing.Point(64, 144);
            this.button19.Margin = new System.Windows.Forms.Padding(0);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(40, 40);
            this.button19.TabIndex = 18;
            this.button19.TabStop = false;
            this.button19.Text = "2";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.Number_Click);
            // 
            // button20
            // 
            this.button20.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button20.Location = new System.Drawing.Point(8, 144);
            this.button20.Margin = new System.Windows.Forms.Padding(0);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(40, 40);
            this.button20.TabIndex = 19;
            this.button20.TabStop = false;
            this.button20.Text = "1";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.Number_Click);
            // 
            // button24
            // 
            this.button24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button24.Location = new System.Drawing.Point(176, 193);
            this.button24.Margin = new System.Windows.Forms.Padding(0);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(40, 40);
            this.button24.TabIndex = 23;
            this.button24.TabStop = false;
            this.button24.Text = "+";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.operat_Click);
            // 
            // button25
            // 
            this.button25.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button25.Location = new System.Drawing.Point(120, 193);
            this.button25.Margin = new System.Windows.Forms.Padding(0);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(40, 40);
            this.button25.TabIndex = 24;
            this.button25.TabStop = false;
            this.button25.Text = ".";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.Number_Click);
            // 
            // textResult
            // 
            this.textResult.Location = new System.Drawing.Point(8, 51);
            this.textResult.Margin = new System.Windows.Forms.Padding(0);
            this.textResult.MaxLength = 40;
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.Size = new System.Drawing.Size(266, 42);
            this.textResult.TabIndex = 1;
            this.textResult.TabStop = false;
            // 
            // textFormula
            // 
            this.textFormula.Location = new System.Drawing.Point(8, 9);
            this.textFormula.Margin = new System.Windows.Forms.Padding(0);
            this.textFormula.MaxLength = 40;
            this.textFormula.Multiline = true;
            this.textFormula.Name = "textFormula";
            this.textFormula.Size = new System.Drawing.Size(266, 42);
            this.textFormula.TabIndex = 2;
            this.textFormula.TabStop = false;
            // 
            // Calclator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.textFormula);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 400);
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "Calclator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator-tool";
            this.Load += new System.EventHandler(this.Calculator_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.calc_KeyPress);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calc;
        private System.Windows.Forms.Button binary;
        private System.Windows.Forms.Button square;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button cleanEnter;
        private System.Windows.Forms.Button clean;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button calcExpress;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.TextBox textFormula;
    }
}

