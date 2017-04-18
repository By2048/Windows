using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureViewer
{
    public class Image
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Image(string name, string path)
        {
            this.Name = name;
            this.Path = path;
        }
        public Image() { }

    }
}
