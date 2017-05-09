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

namespace WinFormTest
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3(string folderPath, Size panelSize)
        {
            InitializeComponent();

            Size = panelSize;

            splitContainer1.SplitterDistance = int.Parse(Math.Round(Size.Width * (0.618)).ToString());
            splitContainer2.SplitterDistance = int.Parse(Math.Round(Size.Height * (1 - 0.618)).ToString());

            panelSmallImages.AutoScroll = true;
            pictureBoxLarge.SizeMode = PictureBoxSizeMode.Zoom;

            ShowPictureByFolder(folderPath, panelSize);


        }

        private void ShowPictureByFolder(string folderPath, Size panelSize)
        {
            string[] pictures = Directory.GetFiles(folderPath, "*jpg");
            int pictureCount = pictures.Length;

            int columnCount = panelSize.Width / 100;
            int rowCount = (pictureCount % columnCount == 0) ?
                pictureCount / columnCount :
                (pictureCount / columnCount) + 1;

            int padding = 2;
            int pictureWidth = panelSize.Width / columnCount - 2 * padding;
            int pictureHeight = pictureWidth * 9 / 16; // 16*9比例

            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    int index = row * columnCount + column;
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = pictureWidth;
                    pictureBox.Height = pictureHeight;
                    if (index >= pictureCount) { return; }
                    //pictureBox.Image = Image.FromFile(pictures[pictureIndex]);
                    pictureBox.Load(pictures[index]);
                    Point pictureLoction = new Point();
                    pictureLoction.X = padding * (column + 1) + pictureWidth * column;
                    pictureLoction.Y = padding * (row + 1) + pictureHeight * row;
                    pictureBox.Location = pictureLoction;
                    pictureBox.Click += pictureBox_Click;
                    panelSmallImages.Controls.Add(pictureBox);
                }
            }
            pictureBoxLarge.Load(pictures[0]);
            ShowImageInfo(Path.GetFullPath(pictures[0]));
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            //PictureBox selectPicture = (PictureBox)sender;
            PictureBox selectPicture = sender as PictureBox;
            pictureBoxLarge.Load(selectPicture.ImageLocation);
            string selectImagePath = Path.GetFullPath(selectPicture.ImageLocation);
            ShowImageInfo(selectImagePath);
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
            propertyGrid1.Height = panelImageInfo.Height/5*4;
            ImageInfo imageInfo = new ImageInfo(imageSize, imageVerticalResolution, imageHorizontalResolution,
                                                fileDirectoryName, fileName, fileType, fillFullName, fileSize,
                                                createTime, lastWriteTime, lastAccessTime);
            propertyGrid1.SelectedObject = imageInfo;
        }

    }
}


public class ImageInfo
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


    public ImageInfo(Size imageSize, string imageVerticalResolution, string imageHorizontalResolution,
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

    [Description("图片大小"), Category("图片信息")]
    public Size ImageSize { get => imageSize; set => imageSize = value; }

    [Description("图片垂直分辨率"), Category("图片信息")]
    public string ImageVerticalResolution { get => imageVerticalResolution; set => imageVerticalResolution = value; }

    [Description("图片水平分辨率"), Category("图片信息")]
    public string ImageHorizontalResolution { get => imageHorizontalResolution; set => imageHorizontalResolution = value; }

    [Description("文件路径"), Category("文件信息")]
    public string FileDirectoryName { get => fileDirectoryName; set => fileDirectoryName = value; }

    [Description("文件名"), Category("文件信息")]
    public string FileName { get => fileName; set => fileName = value; }

    [Description("文件类型"), Category("文件信息")]
    public string FileType { get => fileType; set => fileType = value; }

    [Description("文件路径"), Category("文件信息")]
    public string FillFullName { get => fillFullName; set => fillFullName = value; }

    [Description("文件大小（K）"), Category("文件信息")]
    public double FileSize { get => fileSize; set => fileSize = value; }

    [Description("文件创建时间"), Category("时间信息")]
    public DateTime CreateTime { get => createTime; set => createTime = value; }

    [Description("文件修改时间"), Category("时间信息")]
    public DateTime LastWriteTime { get => lastWriteTime; set => lastWriteTime = value; }

    [Description("文件上次访问时间"), Category("时间信息")]
    public DateTime LastAccessTime { get => lastAccessTime; set => lastAccessTime = value; }

    //[Description("以毫秒表示的文本重复率。"), Category("全局设置"), DefaultValue(90), ReadOnly(true)]

}