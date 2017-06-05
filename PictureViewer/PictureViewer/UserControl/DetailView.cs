using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PictureViewer
{
    public partial class DetailView : UserControl
    {
        public DetailView()
        {
            InitializeComponent();

            Size = MainConfig.PanelMainSize;

            splitContainer1.SplitterDistance = int.Parse(Math.Round(Size.Width * (0.618)).ToString());
            splitContainer2.SplitterDistance = int.Parse(Math.Round(Size.Height * (1 - 0.618)).ToString());

            panelSmallImages.AutoScroll = true;
            pictureBoxLarge.SizeMode = PictureBoxSizeMode.Zoom;

            ShowSmallImages();


        }

        private void ShowSmallImages()
        {
            string[] pictures = ImageTool.GetAllImagePath(MainConfig.ShowFolderPath);

            int pictureCount = pictures.Length;

            int padding = 2;
            int columnCount = splitContainer1.Panel1.Width / MainConfig.ImageSize.Width;
            int rowCount = (pictureCount % columnCount == 0) ?
                pictureCount / columnCount :
                (pictureCount / columnCount) + 1;

            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    int index = row * columnCount + column;
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Size = MainConfig.ImageSize;
                    if (index >= pictureCount) { return; }

                    //pictureBox.Image = Image.FromFile(pictures[pictureIndex]);
                    //pictureBox.Load(pictures[index]);

                    pictureBox.Image = ImageTool.LoadImage(pictures[index]);
                    pictureBox.Tag = pictures[index];

                    Point pictureLoction = new Point()
                    {
                        X = padding * (column + 1) + pictureBox.Width * column,
                        Y = padding * (row + 1) + pictureBox.Height * row
                    };
                    pictureBox.Location = pictureLoction;
                    pictureBox.Click += pictureBox_Click;
                    pictureBox.DoubleClick += pictureBox_DoubleClick;
                    panelSmallImages.Controls.Add(pictureBox);
                }
            }
            pictureBoxLarge.Load(pictures[0]);
            ShowImageInfo(Path.GetFullPath(pictures[0]));
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string filePath = pictureBox.Tag.ToString();
            ShowImage newForm = new ShowImage();
            newForm.picPath = filePath;
            newForm.Show();
        }

        private void pictureBoxLarge_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string filePath = pictureBox.Tag.ToString();
            ShowImage newForm = new ShowImage();
            newForm.picPath = filePath;
            newForm.Show();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            string filePath = pictureBox.Tag.ToString();

            //pictureBoxLarge.Load(selectPicture.ImageLocation);
            pictureBoxLarge.Image = ImageTool.LoadImage(filePath);
            pictureBoxLarge.Tag = filePath;
            pictureBoxLarge.DoubleClick += pictureBoxLarge_DoubleClick;

            //string selectImagePath = Path.GetFullPath(selectPicture.ImageLocation);
            ShowImageInfo(filePath);
        }



        private void ShowImageInfo(string filePath)
        {
            Image image = Image.FromFile(filePath);
            Size imageSize = image.Size;

            string imageVerticalResolution = image.VerticalResolution.ToString(); // 垂直分辨率
            string imageHorizontalResolution = image.HorizontalResolution.ToString(); // 水平分辨率

            FileInfo fileInfo = new FileInfo(filePath);
            string fileDirectoryName = fileInfo.DirectoryName;  // F:\Test
            string fileName = fileInfo.Name.Split('.')[0];    // 001
            //string fileType = path.Split('.').Last();
            string fileType = fileInfo.Extension.Trim('.').ToString(); // jpg
            string fillFullName = fileInfo.FullName;        // F:\Test\001.jpg
            double fileSize = fileInfo.Length / 1000.0;   // 72.121
            DateTime createTime = fileInfo.CreationTime;    // 创建时间
            DateTime lastWriteTime = fileInfo.LastWriteTime;   // 修改时间
            DateTime lastAccessTime = fileInfo.LastAccessTime;  // 上次访问时间

            //propertyGrid1.HelpVisible = false;
            propertyGrid1.ToolbarVisible = false;
            propertyGrid1.Height = panelImageInfo.Height / 5 * 4;
            ImageDetailInfo imageInfo = new ImageDetailInfo(imageSize, imageVerticalResolution, imageHorizontalResolution,
                                                fileDirectoryName, fileName, fileType, fillFullName, fileSize,
                                                createTime, lastWriteTime, lastAccessTime);
            propertyGrid1.SelectedObject = imageInfo;
        }

      
    }
}


public class ImageDetailInfo
{
    private Size imageSize;
    private string imageVerticalResolution;
    private string imageHorizontalResolution;
    private string fileDirectoryName;
    private string fileName;
    private string fileType;
    private string fillFullName;
    private double fileSize;
    private DateTime createTime;
    private DateTime lastWriteTime;
    private DateTime lastAccessTime;

    //private int num = 0;


    public ImageDetailInfo(Size imageSize, string imageVerticalResolution, string imageHorizontalResolution,
                     string fileDirectoryName, string fileName, string fileType, string fillFullName, double fileSize,
                     DateTime createTime, DateTime lastWriteTime, DateTime lastAccessTime)
    {
        this.imageSize = imageSize;
        this.imageVerticalResolution = imageVerticalResolution;
        this.imageHorizontalResolution = imageHorizontalResolution;
        this.fileDirectoryName = fileDirectoryName;
        this.fileName = fileName;
        this.fileType = fileType;
        this.fillFullName = fillFullName;
        this.fileSize = fileSize;
        this.createTime = createTime;
        this.lastWriteTime = lastWriteTime;
        this.lastAccessTime = lastAccessTime;
    }


    //Description - 设置显示在属性下方说明帮助窗格中的属性文本。这是一种为活动属性（即具有焦点的属性）提供帮助文本的有效方法。可以将此特性应用于 MaxRepeatRate 属性。
    //Category - 设置属性在网格中所属的类别。当您需要将属性按类别名称分组时，此特性非常有用。如果没有为属性指定类别，该属性将被分配给杂项 类别。可以将此特性应用于所有属性。
    //Browsable – 表示是否在网格中显示属性。此特性可用于在网格中隐藏属性。默认情况下，公共属性始终显示在网格中。可以将此特性应用于 SettingsChanged 属性。
    //ReadOnly – 表示属性是否为只读。此特性可用于禁止在网格中编辑属性。默认情况下，带有 get 和 set 访问函数的公共属性在网格中是可以编辑的。可以将此特性应用于 AppVersion 属性。
    //DefaultValue – 表示属性的默认值。如果希望为属性提供默认值，然后确定该属性值是否与默认值相同，则可使用此特性。可以将此特性应用于所有属性。
    //DefaultProperty – 表示类的默认属性。在网格中选择某个类时，将首先突出显示该类的默认属性。可以将此特性应用于 AppSettings 类。

    [Description("图片大小"), Category("图片信息")]
    public Size ImageSize { get { return imageSize; } set { imageSize = value; } }

    [Description("图片垂直分辨率"), Category("图片信息")]
    public string ImageVerticalResolution { get { return imageVerticalResolution; } set { imageVerticalResolution = value; } }

    [Description("图片水平分辨率"), Category("图片信息")]
    public string ImageHorizontalResolution { get { return imageHorizontalResolution; } set { imageHorizontalResolution = value; } }

    [Description("文件路径"), Category("文件信息")]
    public string FileDirectoryName { get { return fileDirectoryName; } set { fileDirectoryName = value; } }

    [Description("文件名"), Category("文件信息")]
    public string FileName { get { return fileName; } set { fileName = value; } }

    [Description("文件类型"), Category("文件信息")]
    public string FileType { get { return fileType; } set { fileType = value; } }

    [Description("文件路径"), Category("文件信息")]
    public string FillFullName { get { return fillFullName; } set { fillFullName = value; } }

    [Description("文件大小（K）"), Category("文件信息")]
    public double FileSize { get { return fileSize; } set { fileSize = value; } }

    [Description("文件创建时间"), Category("时间信息")]
    public DateTime CreateTime { get { return createTime; } set { createTime = value; } }

    [Description("文件修改时间"), Category("时间信息")]
    public DateTime LastWriteTime { get { return lastWriteTime; } set { lastWriteTime = value; } }

    [Description("文件上次访问时间"), Category("时间信息")]
    public DateTime LastAccessTime { get { return lastAccessTime; } set { lastAccessTime = value; } }

    //[Description("图片大小"), Category("图片信息")]
    //public Size ImageSize { get => imageSize; set => imageSize = value; }    

    //[Description("图片垂直分辨率"), Category("图片信息")]
    //public string ImageVerticalResolution { get => imageVerticalResolution; set => imageVerticalResolution = value; }

    //[Description("图片水平分辨率"), Category("图片信息")]
    //public string ImageHorizontalResolution { get => imageHorizontalResolution; set => imageHorizontalResolution = value; }

    //[Description("文件路径"), Category("文件信息")]
    //public string FileDirectoryName { get => fileDirectoryName; set => fileDirectoryName = value; }

    //[Description("文件名"), Category("文件信息")]
    //public string FileName { get => fileName; set => fileName = value; }

    //[Description("文件类型"), Category("文件信息")]
    //public string FileType { get => fileType; set => fileType = value; }

    //[Description("文件路径"), Category("文件信息")]
    //public string FillFullName { get => fillFullName; set => fillFullName = value; }

    //[Description("文件大小（K）"), Category("文件信息")]
    //public double FileSize { get => fileSize; set => fileSize = value; }

    //[Description("文件创建时间"), Category("时间信息")]
    //public DateTime CreateTime { get => createTime; set => createTime = value; }

    //[Description("文件修改时间"), Category("时间信息")]
    //public DateTime LastWriteTime { get => lastWriteTime; set => lastWriteTime = value; }

    //[Description("文件上次访问时间"), Category("时间信息")]
    //public DateTime LastAccessTime { get => lastAccessTime; set => lastAccessTime = value; }

    //[Description("以毫秒表示的文本重复率。"), Category("全局设置"), DefaultValue(90), ReadOnly(true)]

}