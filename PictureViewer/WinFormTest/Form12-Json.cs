using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormTest
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string jsonText = File.ReadAllText(@"F:\\Test.json");
            //textBox1.Text += jsonText;

            //JsonReader reader = new JsonTextReader(new StringReader(jsonText));


            //while (reader.Read())
            //{
            //    textBox1.Text += ("TokenType = " + reader.TokenType + "   ValueType =  " + reader.ValueType + "   Value = " + reader.Value + "\r\n");
            //    //textBox1.Text += ("ValueType = " + reader.TokenType + "||"+reader.Value + "\r\n");
            //    textBox1.Text += "\r\n--------\r\n";

            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //StringWriter sw = new StringWriter();
            //JsonWriter writer = new JsonTextWriter(sw);

            //writer.WriteStartObject();
            //writer.WritePropertyName("Id");
            //writer.WriteValue("3");
            //writer.WritePropertyName("FolderPath");
            //writer.WriteValue("F:\\Test3");
            //writer.WritePropertyName("CollectionDate");
            //writer.WriteValue("2015-11-53");
            //writer.WriteEndObject();
            //writer.Flush();

            //string jsonText = sw.GetStringBuilder().ToString();

            //MessageBox.Show(jsonText);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //string json = File.ReadAllText(@"F:\\Test.json");

            //MessageBox.Show((string)obj["Collections"].ToString());
            //MessageBox.Show((string)obj["Collections"][0]["FolderPath"]);

            //string pp = @"{""Id"": ""3"",""FolderPath"": ""F:\\Test3"",""CollectionDate"": ""2015-11-53""}";
            //MessageBox.Show(pp);

            //JArray objArr = (JArray)obj["Collections"];
            //MessageBox.Show(objArr.ToString());

            //objArr.Add(JObject.Parse(pp));
            //MessageBox.Show(obj.ToString());


            //objArr.Remove(obj["Collections"][0]);
            //MessageBox.Show(obj.ToString());




            //string json = @"{  
            //                school:{  
            //                name:'实验高中',  
            //                students:[  
            //                    {name:'张三',age:18},  
            //                    {name:'李四',age:19}  
            //                ],  
            //                sites:['济南','聊城']  
            //                }  
            //            }";
            //JObject obj = JObject.Parse(json);
            //string schname = (string)obj["school"]["name"];
            //Console.WriteLine(schname); //实验高中  
            //string stuname = (string)obj["school"]["students"][1]["name"];
            //Console.WriteLine(stuname);//李四  
            //JArray sites = (JArray)obj["school"]["sites"];
            //foreach (var item in sites)
            //{
            //    //MessageBox.Show(item.ToString());
            //}
            //IList<string> siteList = sites.Select(q => (string)q).ToList();
            //Console.WriteLine(sites.Count);//2             
            //MessageBox.Show(sites.Count.ToString());//2
            //MessageBox.Show((string)obj["school"].ToString());

        }

        string json;
        JObject obj;
        private void LoadJson_Click(object sender, EventArgs e)
        {
            json = File.ReadAllText(@"F:\\Test3.json");
            obj = JObject.Parse(json);
        }
        private void Add_Click(object sender, EventArgs e)
        {
            string addJson = @" {""FolderPath"": ""F:\\Test3"",""CollectionDate"": ""2015-11-52""}";
            obj.Add("Id3", JObject.Parse(addJson));
            MessageBox.Show(obj.ToString());
        }

        private void Del_Click(object sender, EventArgs e)
        {
            obj.Remove("Id1");
            MessageBox.Show(obj.ToString());
        }

        private void Write_Click(object sender, EventArgs e)
        {
            string strJson = obj.ToString();

            FileInfo myFile = new FileInfo(@"F:\Test3.Json");
            StreamWriter sw = myFile.CreateText();
            sw.WriteLine(strJson);
            sw.Close();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            //string json = File.ReadAllText(@"F:\\Test3.json");
            //JObject obj = JObject.Parse(json);
            //textBox.Text += obj.ToString();
            textBox.Text += obj.ToString();
        }


    }
}
