using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PictureViewer
{

    public static class CollectionTool
    {
        public static string jsonPath = @"F:\\Test3.json";
        public static string json;
        public static JObject obj;

        public static void Load()
        {
            json = File.ReadAllText(jsonPath);
            obj = JObject.Parse(json);
        }
        public static void Refresh()
        {
            json = File.ReadAllText(jsonPath);
            obj = JObject.Parse(json);
        }
        public static void Save()
        {
            string strJson = obj.ToString();
            FileInfo myFile = new FileInfo(jsonPath);
            StreamWriter sw = myFile.CreateText();
            sw.WriteLine(strJson);
            sw.Close();

            Refresh();
        }

        // 添加至收藏
        public static void Add(Collection item)
        {
            Load();

            StringWriter sw = new StringWriter();
            JsonWriter writer = new JsonTextWriter(sw);

            writer.WriteStartObject();
            writer.WritePropertyName("Path");
            writer.WriteValue(item.Path);
            writer.WritePropertyName("Type");
            writer.WriteValue(item.Type);
            writer.WritePropertyName("Date");
            writer.WriteValue(item.Date);
            writer.WriteEndObject();
            writer.Flush();

            string jsonText = sw.GetStringBuilder().ToString();

            string maxId = ((JProperty)(obj.Last)).Name.ToString();
            string newId = (int.Parse(maxId) + 1).ToString();

            if (FindByPath(item.Path) == false) // 没有添加收藏
            {
                obj.Add(newId, JObject.Parse(jsonText));
                Save();
                Refresh();
            }
            else
                return;

        }

        // 根据文件或文件夹路径删除 
        public static void RemoveByPath(string path)
        {
            Load();
            string delId = "";
            foreach (JProperty item in obj.Children())
            {
                if (item.Value["Path"].ToString() == path)
                    delId = item.Name;
            }
            if (delId != "")
            {
                obj.Remove(delId);
                Save();
                Refresh();
            }
            else
                return;
        }

        public static bool FindByPath(string path)
        {
            Load();
            foreach (JProperty item in obj.Children())
            {
                if (item.Value["Path"].ToString() == path)
                    return true;
            }
            return false;
        }


    }

}

//               {
//                 "2": {
//                   "Path": "F:\\Test2",
//                   "Type":"Folder",
//                   "Date": "2015-11-52"
//                 },
//                 "3": {
//                   "Path": "F:\\Test3",
//                   "Type":"Folder",    
//                   "Date": "2015-11-52"
//                 }
//               }