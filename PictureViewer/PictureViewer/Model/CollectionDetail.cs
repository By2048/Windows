using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureViewer
{
    public class CollectionDetail : Collection
    {
        public string Id;

        public CollectionDetail(string id, string type, string path, string date) 
            : base(type, path, date)
        {
            Id = id;
        }

    }
}
