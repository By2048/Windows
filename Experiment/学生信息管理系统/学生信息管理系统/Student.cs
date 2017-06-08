using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 学生信息管理系统
{
    [Serializable]
    public class Student
    {
        public string ID;
        public string Name;
        public string Sex;
        public string Faculty;
        public string Description;
        public Student(string id, string name, string sex, string faculty, string description)
        {
            this.ID = id;
            this.Name = name;
            this.Sex = sex;
            this.Faculty = faculty;
            this.Description = description;
        }
    }
}
