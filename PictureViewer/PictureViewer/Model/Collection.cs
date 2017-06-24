using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureViewer
{
    public class Collection
    {
        public string Type;
        public string Path;
        public string Date;

        public Collection()
        {
          
        }

        public Collection(string type, string path, string date)
        {
            Type = type;
            Path = path;
            Date = date;
        }

    }
}
