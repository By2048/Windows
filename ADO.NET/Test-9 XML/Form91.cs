using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Test_9_XML
{
    public partial class Form91 : Form
    {
        public Form91()
        {
            InitializeComponent();
        }

        private void Form91_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            StringBuilder sb = null;
            XmlReader xReader = XmlReader.Create("../../Books.xml");
            xReader.MoveToContent();
            while (xReader.Read())
            {
                sb = new StringBuilder();
                switch (xReader.NodeType)
                {
                    case XmlNodeType.Element:
                        sb.Append(xReader[0] + "\t" + xReader[1] + "\t" + xReader[2]);
                        listBoxBook.Items.Add(sb.ToString());
                        break;
                    default:
                        break;
                }
            }

        }

    }
}
