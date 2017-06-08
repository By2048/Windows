using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 动态添加按钮
{
    public partial class AddButton : Form
    {
        public AddButton()
        {
            InitializeComponent();
        }
        int cnt = 1;
        int point_x = 1, point_y = 1;

        private void Add_Click(object sender, EventArgs e)
        {
            // 新建一个Button对象
            Button newButton = new Button();
            // 设置Button的位置
            newButton.Location = new Point(point_x, point_y);
            // 设置Button显示的文字
            newButton.Text = "NewButton" + cnt;
            this.Controls.Add(newButton);
            // 为新添加的Button添加点击时间
            newButton.Click += new EventHandler(ShowMessage);
            point_y = point_y + 30;
            if (cnt % 5 == 0)
            {
                point_x += 80;
                point_y = 1;
            }
            cnt++;
        }

        private void AddButton_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        // 新添加的按钮的点击事件
        private void ShowMessage(object sender, EventArgs e)
        {
            Button aButton = sender as Button;
            if (aButton != null)
                MessageBox.Show(aButton.Text);
        }
    }
}
