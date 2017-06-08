namespace Test_6_ADO.NET_Operat_Data
{
    partial class Form61
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.moveFirst = new System.Windows.Forms.Button();
            this.textPosition = new System.Windows.Forms.TextBox();
            this.movePrevious = new System.Windows.Forms.Button();
            this.moveNext = new System.Windows.Forms.Button();
            this.moveLast = new System.Windows.Forms.Button();
            this.del = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.revok = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.textCourseInfo = new System.Windows.Forms.TextBox();
            this.labCourseInfo = new System.Windows.Forms.Label();
            this.textCourseName = new System.Windows.Forms.TextBox();
            this.textTeacherID = new System.Windows.Forms.TextBox();
            this.labCourseName = new System.Windows.Forms.Label();
            this.labTeacherID = new System.Windows.Forms.Label();
            this.textCourseID = new System.Windows.Forms.TextBox();
            this.labCourseID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.del);
            this.groupBox1.Controls.Add(this.edit);
            this.groupBox1.Controls.Add(this.revok);
            this.groupBox1.Controls.Add(this.update);
            this.groupBox1.Controls.Add(this.add);
            this.groupBox1.Controls.Add(this.textCourseInfo);
            this.groupBox1.Controls.Add(this.labCourseInfo);
            this.groupBox1.Controls.Add(this.textCourseName);
            this.groupBox1.Controls.Add(this.textTeacherID);
            this.groupBox1.Controls.Add(this.labCourseName);
            this.groupBox1.Controls.Add(this.labTeacherID);
            this.groupBox1.Controls.Add(this.textCourseID);
            this.groupBox1.Controls.Add(this.labCourseID);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 259);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.moveFirst);
            this.groupBox2.Controls.Add(this.textPosition);
            this.groupBox2.Controls.Add(this.movePrevious);
            this.groupBox2.Controls.Add(this.moveNext);
            this.groupBox2.Controls.Add(this.moveLast);
            this.groupBox2.Location = new System.Drawing.Point(31, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 58);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // moveFirst
            // 
            this.moveFirst.Location = new System.Drawing.Point(9, 22);
            this.moveFirst.Name = "moveFirst";
            this.moveFirst.Size = new System.Drawing.Size(30, 23);
            this.moveFirst.TabIndex = 21;
            this.moveFirst.Text = "|<<";
            this.moveFirst.UseVisualStyleBackColor = true;
            this.moveFirst.Click += new System.EventHandler(this.moveFirst_Click);
            // 
            // textPosition
            // 
            this.textPosition.Location = new System.Drawing.Point(93, 23);
            this.textPosition.Name = "textPosition";
            this.textPosition.Size = new System.Drawing.Size(187, 21);
            this.textPosition.TabIndex = 8;
            // 
            // movePrevious
            // 
            this.movePrevious.Location = new System.Drawing.Point(45, 22);
            this.movePrevious.Name = "movePrevious";
            this.movePrevious.Size = new System.Drawing.Size(30, 23);
            this.movePrevious.TabIndex = 9;
            this.movePrevious.Text = "<<";
            this.movePrevious.UseVisualStyleBackColor = true;
            this.movePrevious.Click += new System.EventHandler(this.movePrevious_Click);
            // 
            // moveNext
            // 
            this.moveNext.Location = new System.Drawing.Point(296, 22);
            this.moveNext.Name = "moveNext";
            this.moveNext.Size = new System.Drawing.Size(30, 23);
            this.moveNext.TabIndex = 19;
            this.moveNext.Text = ">>";
            this.moveNext.UseVisualStyleBackColor = true;
            this.moveNext.Click += new System.EventHandler(this.moveNext_Click);
            // 
            // moveLast
            // 
            this.moveLast.Location = new System.Drawing.Point(332, 22);
            this.moveLast.Name = "moveLast";
            this.moveLast.Size = new System.Drawing.Size(30, 23);
            this.moveLast.TabIndex = 20;
            this.moveLast.Text = ">|";
            this.moveLast.UseVisualStyleBackColor = true;
            this.moveLast.Click += new System.EventHandler(this.moveLast_Click);
            // 
            // del
            // 
            this.del.Location = new System.Drawing.Point(107, 219);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(55, 23);
            this.del.TabIndex = 25;
            this.del.Text = "删除";
            this.del.UseVisualStyleBackColor = true;
            this.del.Click += new System.EventHandler(this.del_Click);
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(185, 219);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(55, 23);
            this.edit.TabIndex = 24;
            this.edit.Text = "编辑";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // revok
            // 
            this.revok.Location = new System.Drawing.Point(344, 219);
            this.revok.Name = "revok";
            this.revok.Size = new System.Drawing.Size(55, 23);
            this.revok.TabIndex = 23;
            this.revok.Text = "撤销";
            this.revok.UseVisualStyleBackColor = true;
            this.revok.Click += new System.EventHandler(this.revok_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(267, 219);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(55, 23);
            this.update.TabIndex = 22;
            this.update.Text = "更新";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(28, 219);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(55, 23);
            this.add.TabIndex = 13;
            this.add.Text = "添加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // textCourseInfo
            // 
            this.textCourseInfo.Location = new System.Drawing.Point(218, 50);
            this.textCourseInfo.Multiline = true;
            this.textCourseInfo.Name = "textCourseInfo";
            this.textCourseInfo.Size = new System.Drawing.Size(181, 65);
            this.textCourseInfo.TabIndex = 7;
            // 
            // labCourseInfo
            // 
            this.labCourseInfo.AutoSize = true;
            this.labCourseInfo.Location = new System.Drawing.Point(216, 31);
            this.labCourseInfo.Name = "labCourseInfo";
            this.labCourseInfo.Size = new System.Drawing.Size(53, 12);
            this.labCourseInfo.TabIndex = 6;
            this.labCourseInfo.Text = "课程描述";
            // 
            // textCourseName
            // 
            this.textCourseName.Location = new System.Drawing.Point(76, 68);
            this.textCourseName.Name = "textCourseName";
            this.textCourseName.Size = new System.Drawing.Size(100, 21);
            this.textCourseName.TabIndex = 5;
            // 
            // textTeacherID
            // 
            this.textTeacherID.Location = new System.Drawing.Point(76, 100);
            this.textTeacherID.Name = "textTeacherID";
            this.textTeacherID.Size = new System.Drawing.Size(100, 21);
            this.textTeacherID.TabIndex = 4;
            // 
            // labCourseName
            // 
            this.labCourseName.AutoSize = true;
            this.labCourseName.Location = new System.Drawing.Point(17, 71);
            this.labCourseName.Name = "labCourseName";
            this.labCourseName.Size = new System.Drawing.Size(53, 12);
            this.labCourseName.TabIndex = 3;
            this.labCourseName.Text = "课程名称";
            // 
            // labTeacherID
            // 
            this.labTeacherID.AutoSize = true;
            this.labTeacherID.Location = new System.Drawing.Point(17, 103);
            this.labTeacherID.Name = "labTeacherID";
            this.labTeacherID.Size = new System.Drawing.Size(53, 12);
            this.labTeacherID.TabIndex = 2;
            this.labTeacherID.Text = "教师编号";
            // 
            // textCourseID
            // 
            this.textCourseID.Location = new System.Drawing.Point(76, 32);
            this.textCourseID.Name = "textCourseID";
            this.textCourseID.Size = new System.Drawing.Size(100, 21);
            this.textCourseID.TabIndex = 1;
            // 
            // labCourseID
            // 
            this.labCourseID.AutoSize = true;
            this.labCourseID.Location = new System.Drawing.Point(17, 35);
            this.labCourseID.Name = "labCourseID";
            this.labCourseID.Size = new System.Drawing.Size(53, 12);
            this.labCourseID.TabIndex = 0;
            this.labCourseID.Text = "课程编号";
            // 
            // Form61
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 282);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form61";
            this.Text = "Test-6 ADO.NET Operat Data";
            this.Load += new System.EventHandler(this.Form61_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button moveFirst;
        private System.Windows.Forms.TextBox textPosition;
        private System.Windows.Forms.Button movePrevious;
        private System.Windows.Forms.Button moveNext;
        private System.Windows.Forms.Button moveLast;
        private System.Windows.Forms.Button del;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button revok;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox textCourseInfo;
        private System.Windows.Forms.Label labCourseInfo;
        private System.Windows.Forms.TextBox textCourseName;
        private System.Windows.Forms.TextBox textTeacherID;
        private System.Windows.Forms.Label labCourseName;
        private System.Windows.Forms.Label labTeacherID;
        private System.Windows.Forms.TextBox textCourseID;
        private System.Windows.Forms.Label labCourseID;
    }
}

