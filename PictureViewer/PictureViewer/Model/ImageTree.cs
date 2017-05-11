using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureViewer
{
    public class ImageTree
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public ImageTree(string name, string path)
        {
            this.Name = name;
            this.Path = path;
        }
        public ImageTree() { }
      
    }
}
