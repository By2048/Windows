namespace 简单加法器
{
    partial class simpleAdd
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
            this.labFirstNum = new System.Windows.Forms.Label();
            this.labSecondNum = new System.Windows.Forms.Label();
            this.labResult = new System.Windows.Forms.Label();
            this.textFirstNum = new System.Windows.Forms.TextBox();
            this.textSecondNum = new System.Windows.Forms.TextBox();
            this.textResult = new System.Windows.Forms.TextBox();
            this.clean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calc
            // 
            this.calc.Location = new System.Drawing.Point(131, 157);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(53, 23);
            this.calc.TabIndex = 0;
            this.calc.Text = "计 算";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // labFirstNum
            // 
            this.labFirstNum.AutoSize = true;
            this.labFirstNum.Location = new System.Drawing.Point(32, 32);
            this.labFirstNum.Name = "labFirstNum";
            this.labFirstNum.Size = new System.Drawing.Size(29, 12);
            this.labFirstNum.TabIndex = 1;
            this.labFirstNum.Text = "加数";
            // 
            // labSecondNum
            // 
            this.labSecondNum.AutoSize = true;
            this.labSecondNum.Location = new System.Drawing.Point(20, 73);
            this.labSecondNum.Name = "labSecondNum";
            this.labSecondNum.Size = new System.Drawing.Size(41, 12);
            this.labSecondNum.TabIndex = 2;
            this.labSecondNum.Text = "被加数";
            // 
            // labResult
            // 
            this.labResult.AutoSize = true;
            this.labResult.Location = new System.Drawing.Point(44, 113);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(17, 12);
            this.labResult.TabIndex = 3;
            this.labResult.Text = "和";
            // 
            // textFirstNum
            // 
            this.textFirstNum.Location = new System.Drawing.Point(84, 29);
            this.textFirstNum.Name = "textFirstNum";
            this.textFirstNum.Size = new System.Drawing.Size(100, 21);
            this.textFirstNum.TabIndex = 4;
            this.textFirstNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.firstNumPress);
            // 
            // textSecondNum
            // 
            this.textSecondNum.Location = new System.Drawing.Point(84, 70);
            this.textSecondNum.Name = "textSecondNum";
            this.textSecondNum.Size = new System.Drawing.Size(100, 21);
            this.textSecondNum.TabIndex = 5;
            this.textSecondNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.secondNumPress);
            // 
            // textResult
            // 
            this.textResult.Location = new System.Drawing.Point(84, 110);
            this.textResult.Name = "textResult";
            this.textResult.Size = new System.Drawing.Size(100, 21);
            this.textResult.TabIndex = 6;
            // 
            // clean
            // 
            this.clean.Location = new System.Drawing.Point(34, 157);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(53, 23);
            this.clean.TabIndex = 7;
            this.clean.Text = "清 除";
            this.clean.UseVisualStyleBackColor = true;
            this.clean.Click += new System.EventHandler(this.clean_Click);
            // 
            // simpleAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 202);
            this.Controls.Add(this.clean);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.textSecondNum);
            this.Controls.Add(this.textFirstNum);
            this.Controls.Add(this.labResult);
            this.Controls.Add(this.labSecondNum);
            this.Controls.Add(this.labFirstNum);
            this.Controls.Add(this.calc);
            this.Name = "simpleAdd";
            this.Text = "简单加法器";
            this.Load += new System.EventHandler(this.simpleAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calc;
        private System.Windows.Forms.Label labFirstNum;
        private System.Windows.Forms.Label labSecondNum;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.TextBox textFirstNum;
        private System.Windows.Forms.TextBox textSecondNum;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.Button clean;
    }
}

