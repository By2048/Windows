using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Test_6_ADO.NET_Operat_Data
{
    public partial class Form61 : Form
    {
        public Form61()
        {
            InitializeComponent();
        }

        string strConn = "initial catalog = northwind;data source=.;integrated security=true";
        string strCreate = "create table Courses(ID int identity(1,1) primary key,CourseID varchar(10) ,CourseName varchar(50),CourseInfo varchar(500),TeacherID varchar(10))";
        string strSelect = "select * from Courses";

        SqlConnection connection = null;
        SqlDataAdapter dataAdapterCourse = null;
        DataSet dataSetCourse = null;
        DataTable dataTableCourse = null;
        string[,] arrayCourses = new string[100, 5];
        int courseCount, position = 0;

        private void createDB()
        {

            SqlConnection connection = new SqlConnection(strConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(strCreate, connection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                MessageBox.Show("数据已经建立！");
                //MessageBox.Show(error.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                connection.Close();
            }
        }


        private void Form61_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            createDB();

            connection = new SqlConnection(strConn);
            dataAdapterCourse = new SqlDataAdapter(strSelect, connection);

            dataSetCourse = new DataSet();
            dataTableCourse = new DataTable();
            dataAdapterCourse.Fill(dataSetCourse, "Courses");
            dataTableCourse = dataSetCourse.Tables["Courses"];

            courseCount = dataTableCourse.Rows.Count;
            getAllCourse();
            UpdateDisplay();
        }



        private void UpdateDisplay()
        {
            getAllCourse();
            textCourseID.Text = arrayCourses[position, 1].ToString();
            textCourseName.Text = arrayCourses[position, 2].ToString();
            textCourseInfo.Text = arrayCourses[position, 3].ToString();
            textTeacherID.Text = arrayCourses[position, 4].ToString();
            textPosition.Text = string.Format("Course {0} of {1}", position + 1, courseCount);
        }
        private void getAllCourse()
        {
            int i = 0;
            DataRow[] currentRows = dataTableCourse.Select(null, null, DataViewRowState.CurrentRows);
            foreach (DataRow row in currentRows)
            {
                arrayCourses[i, 0] = row["ID"].ToString().Trim();
                arrayCourses[i, 1] = row["CourseID"].ToString().Trim();
                arrayCourses[i, 2] = row["CourseName"].ToString().Trim();
                arrayCourses[i, 3] = row["CourseInfo"].ToString().Trim();
                arrayCourses[i, 4] = row["TeacherID"].ToString().Trim();               
                i++;               
            }           
        }
        private void add_Click(object sender, EventArgs e)
        {
            string courseID = textCourseID.Text.ToString();
            string courseName = textCourseName.Text.ToString();
            string courseInfo = textCourseInfo.Text.ToString();
            string teacherID = textTeacherID.Text.ToString();

            DataRow newCourse = dataTableCourse.NewRow();
            newCourse["CourseID"] = courseID;
            newCourse["CourseName"] = courseName;
            newCourse["CourseInfo"] = courseInfo;
            newCourse["TeacherID"] = teacherID;

            dataTableCourse.Rows.Add(newCourse);

            courseCount += 1;

        }

        private void update_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapterCourse);
            dataAdapterCourse.Update(dataSetCourse,"Courses");
            //dataSetCourse.AcceptChanges();
            //dataAdapterCourse.Update(dataTableCourse.Select(null, null, DataViewRowState.Deleted));
            //dataAdapterCourse.Update(dataTableCourse.Select(null, null,DataViewRowState.ModifiedCurrent));
            //dataAdapterCourse.Update(dataTableCourse.Select(null, null, DataViewRowState.Added));
        }

       

        private void del_Click(object sender, EventArgs e)
        {
            DataRow currentRows = dataTableCourse.Rows[position];
            //dataTableCourse.Rows.Remove(currentRows);
            currentRows.Delete();
            position -= 1;
            courseCount -= 1;
            UpdateDisplay();
        }
        private void edit_Click(object sender, EventArgs e)
        {
            string courseID = textCourseID.Text.ToString();
            string courseName = textCourseName.Text.ToString();
            string courseInfo = textCourseInfo.Text.ToString();
            string teacherID = textTeacherID.Text.ToString();

            DataRow currentRows = dataTableCourse.Rows[position];
            currentRows["CourseID"] = courseID;
            currentRows["CourseName"] = courseName;
            currentRows["CourseInfo"] = courseInfo;
            currentRows["TeacherID"] = teacherID;
        }
        private void moveNext_Click(object sender, EventArgs e)
        {
            position += 1;
            if (position <= courseCount - 1)
                UpdateDisplay();
            else
                position -= 1;
        }

        private void movePrevious_Click(object sender, EventArgs e)
        {
            position -= 1;
            if (position >= 0)
                UpdateDisplay();
            else
                position += 1; ;
        }

        private void moveLast_Click(object sender, EventArgs e)
        {
            position = courseCount-1;
            UpdateDisplay();
        }

        private void moveFirst_Click(object sender, EventArgs e)
        {
            position = 0;
            UpdateDisplay();
        }        

        private void revok_Click(object sender, EventArgs e)
        {
            dataSetCourse.RejectChanges();
            UpdateDisplay();
        }

        private void showDataSet()
        {
            DataRow[] currentRows = dataTableCourse.Select(null, null, DataViewRowState.CurrentRows);
            string info = "";
            foreach (DataRow row in currentRows)
            {
                foreach (DataColumn column in dataTableCourse.Columns)
                {
                    info += row[column] + " ";
                }         

                info += row.RowState;
                info += "\n";
            }
            MessageBox.Show(info);
        }
    }
}

//    --Test--
//    --SQL--
//    create table Courses
//    (
//        ID int identity(1,1) primary key,
//        CourseID varchar(10) ,
//        CourseName varchar(50),
//        CourseInfo varchar(500),
//        TeacherID varchar(10)
//    )
      
//    insert into Courses values('c-1','name-1','info-1','t-1')
//    insert into Courses values('c-2','name-2','info-2','t-2')
//    insert into Courses values('c-3','name-3','info-3','t-3')
//    insert into Courses values('c-4','name-4','info-4','t-4')
      
//    select * from Courses
//    delete from Courses
//    drop table Courses