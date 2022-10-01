using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Test_WithConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolServiceDB.SchoolServiceClient db = new SchoolServiceDB.SchoolServiceClient();
            Console.WriteLine("Student Id :");
            string sId = Console.ReadLine();

            SchoolServiceDB.Student stu = new SchoolServiceDB.Student();
            stu = db.FindStudent(sId);

            Console.WriteLine("Name :"+stu.StudentName);
            Console.WriteLine("Add :"+stu.StudentAddress);
            Console.ReadKey();
        }
    }
}
