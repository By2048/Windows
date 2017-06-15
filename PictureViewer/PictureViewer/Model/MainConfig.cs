using System.Drawing;

namespace PictureViewer
{
    public static class MainConfig
    {
        // TreeView 根目录
        public static string StartTreePath;

        // 当前显示的图片目录
        public static string ShowFolderPath;

        // 当前显示的图片目录
        public static string ShowImagePath;

        // 状态栏文本
        public static string ToolStripStatusLabelImage;

        // 加载TreeView窗体的大小
        public static Size PanelTreeSize;

        // 加载UserControl窗体的大小
        public static Size PanelMainSize;

        // 图片大小
        public static Size ImageSize;

        // 图片当前显示的模式
        public static ShowView ShowView;

        // 当前点击 TreeView 的文本
        public static string CurNodeText;
    }

}
