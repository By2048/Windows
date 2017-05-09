using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class Form00 : Form
    {
        public Form00()
        {
            InitializeComponent();
        }

        private void Form00_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            propertyGrid1.Text = "12312";
            AppSettings appset = new AppSettings();
            propertyGrid1.SelectedObject = appset;

            //propertyGrid1.HelpVisible = false;
            //propertyGrid1.ToolbarVisible = false;
        }


    }
}

[DefaultProperty("SaveOnClose")]
public class AppSettings
{
    private bool saveOnClose = true;
    private string greetingText = "欢迎使用应用程序！";
    private int itemsInMRU;
    private int maxRepeatRate = 10;
    private bool settingsChanged = false;
    private string appVersion = "1.0";

    public bool SaveOnClose
    {
        get { return saveOnClose; }
        set { saveOnClose = value; }
    }
    public string GreetingText
    {
        get { return greetingText; }
        set { greetingText = value; }
    }
    public int MaxRepeatRate
    {
        get { return maxRepeatRate; }
        set { maxRepeatRate = value; }
    }

    [Description("以毫秒表示的文本重复率。"), Category("全局设置"), DefaultValue(90)]
    public int ItemsInMRUList
    {
        get { return itemsInMRU; }
        set { itemsInMRU = value; }
    }
    public bool SettingsChanged
    {
        get { return settingsChanged; }
        set { settingsChanged = value; }
    }
    [Category("版本"), DefaultValue("1.0"), ReadOnly(true)]
    public string AppVersion
    {
        get { return appVersion; }
        set { appVersion = value; }
    }
}