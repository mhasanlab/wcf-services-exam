using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF_Test_With_WinForm
{
    public partial class Form1 : Form
    {
        SchoolServiceDB.SchoolServiceClient db = new SchoolServiceDB.SchoolServiceClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.ShowAllStudent();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.ShowAllStudent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            db.InsertStudent(txtId.Text, txtName.Text, txtAddress.Text);
            MessageBox.Show("Data inserted successfully!!!");
            ClearAll();
            dataGridView1.DataSource = db.ShowAllStudent();
        }

        private void ClearAll()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtId.Focus();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SchoolServiceDB.Student stu = new SchoolServiceDB.Student();
            stu = db.FindStudent(txtId.Text);
            txtName.Text = stu.StudentName;
            txtAddress.Text = stu.StudentAddress;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
