using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_7_Models
{
    public class Worker
    {
        public string Id {get;set;}
        public string Name{get;set;}
        public string Sex {get;set;}
        public string Birthday{get;set;}
        public string Job {get;set;}
        public string Department { get; set; }

        public Worker(string id,string name,string sex,string birthday,string job,string department)
        {
            this.Id = id;
            this.Name = name;
            this.Sex = sex;
            this.Birthday = birthday;
            this.Job = job;
            this.Department = department;
        }

    }
}
