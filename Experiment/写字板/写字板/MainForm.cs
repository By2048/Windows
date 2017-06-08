using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace 写字板
{
    public partial class MainForm : Form
    {
        int findPostion = 0;
        int findBeforPostion = 0;
        string fileName = "";
        public MainForm()
        {
            InitializeComponent();
            CenterToScreen();
            Text = "写字板";
            toolStripStatusLabel1.Text = "14145306 计算机142 付祥运";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
                tscbFontStyle.Items.Add(font.Name);
            for (int i = 5; i <= 72; i = i + 2)
                tscbFontSize.Items.Add(i.ToString());
            Font curFont = richTextBoxShow.Font;
            tscbFontStyle.SelectedIndex = tscbFontStyle.FindString(curFont.Name);
            tscbFontSize.SelectedIndex = tscbFontSize.FindString(((int)curFont.Size).ToString());
            Font = curFont;
        }
        private void 编辑ToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            撤销ToolStripMenuItem.Enabled = richTextBoxShow.CanUndo;
            重复ToolStripMenuItem.Enabled = richTextBoxShow.CanRedo;
            复制ToolStripMenuItem.Enabled = richTextBoxShow.SelectedText != "";
            粘贴ToolStripMenuItem.Enabled = richTextBoxShow.CanPaste(DataFormats.GetFormat(DataFormats.Rtf));

        }
        private void tscbfontstyle_SelectedIndexChanged(object sender, EventArgs e)
        {         
            if (richTextBoxShow.SelectionLength > 0)
            {
                int start = richTextBoxShow.SelectionStart;
                int length = richTextBoxShow.SelectionLength;
                int end = start + length;
                while (start < end)
                {
                    richTextBoxShow.Select(start++, 1);
                    using (Font oldFont = richTextBoxShow.SelectionFont)
                    {
                        richTextBoxShow.SelectionFont = new Font(tscbFontStyle.SelectedItem.ToString(), oldFont.Size, oldFont.Style);
                    }
                }
                richTextBoxShow.Select(end - length, length);
            }
            else
            {
                Font oldFont = richTextBoxShow.SelectionFont;
                richTextBoxShow.SelectionFont = new Font(tscbFontStyle.SelectedItem.ToString(), oldFont.Size, oldFont.Style);
            }
        }
        private void tscbfontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBoxShow.SelectionLength > 0)
            {
                int start = richTextBoxShow.SelectionStart;
                int length = richTextBoxShow.SelectionLength;
                int end = start + length;
                while (start < end)
                {
                    richTextBoxShow.Select(start++, 1);
                    using (Font oldFont = richTextBoxShow.SelectionFont)
                    {
                        richTextBoxShow.SelectionFont = new Font(oldFont.Name, float.Parse(tscbFontSize.SelectedItem.ToString()), oldFont.Style);
                    }
                }
                richTextBoxShow.Select(end - length, length);
            }
            else
            {
                Font oldFont = richTextBoxShow.SelectionFont;
                richTextBoxShow.SelectionFont = new Font(oldFont.Name, float.Parse(tscbFontSize.SelectedItem.ToString()), oldFont.Style);
            }
        }
        private void bold_Click(object sender, EventArgs e)
        {
            Font curFont = richTextBoxShow.SelectionFont;
            Font newFont;
            if (bold.Checked)
                newFont = new Font(curFont, curFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(curFont, curFont.Style | FontStyle.Bold);
            richTextBoxShow.SelectionFont = newFont;
            bold.Checked = !(bold.Checked);
        }      
        private void ltalic_Click(object sender, EventArgs e)
        {
            Font curFont = richTextBoxShow.SelectionFont;
            Font newFont;
            if (ltalic.Checked)
                newFont = new Font(curFont, curFont.Style & ~FontStyle.Italic);
            else
                newFont = new Font(curFont, curFont.Style | FontStyle.Italic);
            richTextBoxShow.SelectionFont = newFont;
            ltalic.Checked = !(ltalic.Checked);
        }
        private void underline_Click(object sender, EventArgs e)
        {
            Font curFont = richTextBoxShow.SelectionFont;
            Font newFont;
            if (underline.Checked)
                newFont = new Font(curFont, curFont.Style & ~FontStyle.Underline);
            else
                newFont = new Font(curFont, curFont.Style | FontStyle.Underline);
            richTextBoxShow.SelectionFont = newFont;
            underline.Checked = !(underline.Checked);
        }
        private void 替换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findPostion = 0;
            ReplaceForm newForm = new ReplaceForm(this);
            newForm.Show();
        }
        private void 查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findPostion = 0;
            ReplaceForm newForm = new ReplaceForm(this);
            newForm.Show();
        }
        public void SerachBefor(string findText)
        {

            int endPos = richTextBoxShow.SelectionStart;
            int index = richTextBoxShow.Find(findText, 0, endPos, RichTextBoxFinds.Reverse);
            if (index > -1)
            {
                richTextBoxShow.SelectionStart = index;
                richTextBoxShow.SelectionLength = findText.Length;
                findBeforPostion++;
            }
            else if (index < 0)
            {
                findBeforPostion = 0;
            }
        }
        public void Serach(string findText)
        {
            if (findPostion >= richTextBoxShow.Text.Length)
            {
                MessageBox.Show("已到文本底部", "提示", MessageBoxButtons.OK);
                findPostion = 0;
                return;
            }
            findPostion = richTextBoxShow.Find(findText, findPostion, RichTextBoxFinds.MatchCase);
            if (findPostion == -1)
            {
                MessageBox.Show("已到文本底部", "提示", MessageBoxButtons.OK);
                findPostion = 0;
            }
            else
            {
                findPostion += findText.Length;
            }
        }
        public void Replace(string findText, string replaceText)
        {
            Serach(findText);
            if (richTextBoxShow.SelectedText.Length != 0)
            {
                richTextBoxShow.SelectedText = replaceText;
            }
        }
        public void ReplaceAll(string findText, string replaceText)
        {
            findPostion = 0;
            MessageBox.Show(richTextBoxShow.Text.Length.ToString());

            while (findPostion <= richTextBoxShow.Text.Length)
            {
                findPostion = richTextBoxShow.Find(findText, findPostion, RichTextBoxFinds.MatchCase);
                if (findPostion >= richTextBoxShow.Text.Length || findPostion == -1)
                    break;
                richTextBoxShow.SelectedText = replaceText;
                findPostion += findText.Length;
            }
            return;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bool isCheck = toolStripButton2.Checked;
            if (isCheck == false)
            {
                toolStripButton2.Checked = true;
                richTextBoxShow.SelectionAlignment = HorizontalAlignment.Left;
                toolStripButton3.Checked = false;
                toolStripButton4.Checked = false;
            }
            else
            {
                return;
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            bool isCheck = toolStripButton3.Checked;
            if (isCheck == false)
            {
                toolStripButton3.Checked = true;
                richTextBoxShow.SelectionAlignment = HorizontalAlignment.Center;
                toolStripButton2.Checked = false;
                toolStripButton4.Checked = false;
            }
            else
            {
                return;
            }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            bool isCheck = toolStripButton4.Checked;
            if (isCheck == false)
            {
                toolStripButton4.Checked = true;
                richTextBoxShow.SelectionAlignment = HorizontalAlignment.Right;
                toolStripButton2.Checked = false;
                toolStripButton3.Checked = false;
            }
            else
            {
                return;
            }
        }
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFile();
        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName != string.Empty)
                Save();
            else
                SaveAs();
        }
        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            CreateFile();
        }
        private void 打开OToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            if (fileName != string.Empty)
                Save();
            else
                SaveAs();
        }
        private void OpenFile()
        {
            openFileDialog1.Filter = "文本文件|*.txt|rtf文档|*.rtf|word文档|*.doc;*.docx|所有文件|*.*";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FilterIndex == 1)
                {
                    richTextBoxShow.Clear();
                    richTextBoxShow.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
                else if (openFileDialog1.FilterIndex == 2)
                {
                    richTextBoxShow.Clear();
                    richTextBoxShow.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBoxShow.Clear();
                    OpenWord(openFileDialog1.FileName);
                }
                fileName = openFileDialog1.FileName;
            }
            Text = fileName;
        }
        private void CreateFile()
        {
            saveFileDialog1.Filter = "文本文件|*.txt|rtf文档|*.rtf|word文档|*.doc;*.docx|所有文件|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.Title = "新建文档";
            saveFileDialog1.FileName = "新建文本文档";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.DefaultExt == ".txt")
                {
                    richTextBoxShow.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.TextTextOleObjs);
                }
                else if (saveFileDialog1.DefaultExt == ".rtf")
                {
                    richTextBoxShow.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    SaveAsWord(saveFileDialog1.FileName);
                }
                if (saveFileDialog1.FileName != string.Empty)
                {
                    fileName = saveFileDialog1.FileName;
                    Text = "写字板 " + fileName;
                }
            }
        }
        private void SaveAs()
        {
            saveFileDialog1.Filter = "TXT|*.txt|RTF|*.rtf|Word|*.doc;*.docx|所有文件|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.Title = "另存为";
            saveFileDialog1.FileName = "新建文本文档";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.DefaultExt == ".txt")
                {
                    richTextBoxShow.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
                else if (saveFileDialog1.DefaultExt == ".rtf")
                {
                    richTextBoxShow.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    SaveAsWord(saveFileDialog1.FileName);
                }
                if (saveFileDialog1.FileName != string.Empty)
                {
                    fileName = saveFileDialog1.FileName;
                    Text = "写字板 " + fileName;
                }
            }
        }
        private void Save()
        {
            if (fileName == string.Empty)
            {
                SaveAs();
            }
            else
            {
                if (fileName.EndsWith(".txt"))
                {
                    richTextBoxShow.SaveFile(fileName, RichTextBoxStreamType.PlainText);
                }
                else if (fileName.EndsWith(".rtf"))
                {
                    richTextBoxShow.SaveFile(fileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    SaveWord(fileName);
                }
            }
            Text = fileName;
        }
        public void OpenWord(string fileName)
        {
            Word.Application app = new Word.Application();
            Word.Document doc = null;
            object missing = System.Reflection.Missing.Value;
            object File = fileName;
            object readOnly = false;
            object isVisible = true;
            try
            {
                doc = app.Documents.Open(ref File, ref missing, ref readOnly,
                 ref missing, ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref isVisible, ref missing,
                 ref missing, ref missing, ref missing);
                doc.ActiveWindow.Selection.WholeStory();//全选word文档中的数据
                doc.ActiveWindow.Selection.Copy();//复制数据到剪切板
                richTextBoxShow.Paste();//richTextBox粘贴数据
                //richTextBox1.Text = doc.Content.Text;//显示无格式数据
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    doc = null;
                }
                if (app != null)
                {
                    app.Quit(ref missing, ref missing, ref missing);
                    app = null;
                }
            }
        }
        //保存richTextBox数据到已经存在的word文档中。
        //先打开word文档，全选word文档中的数据，然后全选richTextBox中的数据并复制，粘贴到word文档中，最后保存word文档，并关闭文档
        public void SaveWord(string fileName)
        {
            Word.Application app = new Word.Application();

            Word.Document doc = null;
            object missing = System.Reflection.Missing.Value;
            object File = fileName;
            object readOnly = false;
            object isVisible = true;
            try
            {
                doc = app.Documents.Open(ref File, ref missing, ref readOnly,
                 ref missing, ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref isVisible, ref missing,
                 ref missing, ref missing, ref missing);
                doc.ActiveWindow.Selection.WholeStory();//全选
                richTextBoxShow.SelectAll();
                Clipboard.SetData(DataFormats.Rtf, richTextBoxShow.SelectedRtf);//复制RTF数据到剪贴板 

                doc.ActiveWindow.Selection.Paste();

                //doc.Paragraphs.Last.Range.Text = richTextBox1.Text;//word文档赋值数据，不带格式

                doc.Save();
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    doc = null;
                }
                if (app != null)
                {
                    app.Quit(ref missing, ref missing, ref missing);
                    app = null;
                }
            }
        }
        //将richTextBox带格式的文本另存为word文档
        //先创建一个word文档，全选word文档中的数据，然后全选richTextBox中的数据并复制，粘贴到word文档中，最后保存word文档，并关闭文档
        public void SaveAsWord(string fileName)
        {
            Word.Application app = new Word.Application();
            Word.Document doc = null;
            object missing = System.Reflection.Missing.Value;
            object File = fileName;
            try
            {
                doc = app.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                doc.ActiveWindow.Selection.WholeStory();//全选
                richTextBoxShow.SelectAll();
                Clipboard.SetData(DataFormats.Rtf, richTextBoxShow.SelectedRtf);//复制RTF数据到剪贴板
                doc.ActiveWindow.Selection.Paste();
                doc.SaveAs(ref File, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    doc = null;
                }
                if (app != null)
                {
                    app.Quit(ref missing, ref missing, ref missing);
                    app = null;
                }
            }
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
    }
}
