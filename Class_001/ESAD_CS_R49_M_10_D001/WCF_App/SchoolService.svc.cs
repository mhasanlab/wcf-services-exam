using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_App.Models;
using System.Data.SqlClient;
using System.Data;

namespace WCF_App
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SchoolService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SchoolService.svc or SchoolService.svc.cs at the Solution Explorer and start debugging.
    public class SchoolService : ISchoolService
    {
        public void DeleteStudent(string stuId)
        {
            Data("DELETE FROM student WHERE stuId='" + stuId + "'");
        }

        public Student FindStudent(string stuId)
        {
            DataSet ds = Data("SELECT * FROM student WHERE stuId='" + stuId + "'");
            Student stu = new Student();
            if (ds.Tables[0].Rows.Count == 1)
            {
                stu.StudentId = ds.Tables[0].Rows[0][0].ToString();
                stu.StudentName = ds.Tables[0].Rows[0][1].ToString();
                stu.StudentAddress = ds.Tables[0].Rows[0][2].ToString();
            }
            return stu;
        }

        public void InsertStudent(string stuId, string stuName, string stuAddress)
        {
            Data("Insert INTO student VALUES('" + stuId + "', '" + stuName + "', '" + stuAddress + "')");
        }

        public List<Student> ShowAllStudent()
        {
            DataSet ds = Data("SELECT * FROM student");
            List<Student> list = new List<Student>();
            Student stu;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                stu = new Student();
                stu.StudentId = ds.Tables[0].Rows[i][0].ToString();
                stu.StudentName = ds.Tables[0].Rows[i][1].ToString();
                stu.StudentAddress = ds.Tables[0].Rows[i][2].ToString();
                list.Add(stu);
            }
            return list;
        }

        public void UpdateStudent(string stuId, string stuName, string stuAddress)
        {
            Data("UPDATE student SET stuName='" + stuName + "', stuAddress='" + stuAddress + "' WHERE stuId='" + stuId + "'");
        }
        private DataSet Data(string str)
        {
            SqlConnection con = new SqlConnection(@"Server=BDPNT-AZMAN;Database=AzDB;Trusted_Connection=True;");
            SqlDataAdapter sda = new SqlDataAdapter(str,con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
    }
}
