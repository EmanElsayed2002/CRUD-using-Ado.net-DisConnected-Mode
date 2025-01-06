using BLL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormUpdate : Form
    {
        DataTable dt;
        

        public FormUpdate()
        {
            InitializeComponent();
            LoadDataAndFresh();
        }
        private void LoadDataAndFresh()
        {
            dt = BLL.EntityManger.StudentManager.GetFullName();
            comboBoxStudentNames.DataSource = dt;
            comboBoxStudentNames.DisplayMember = "Fullname";
            comboBoxStudentNames.ValueMember = "St_Id";
        }
        private void comboBoxStudentNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStudentNames.SelectedValue == null) return;

            int selectedStudentId = Convert.ToInt32(comboBoxStudentNames.SelectedValue);

            Student s = BLL.EntityManger.StudentManager.GetStudentByID(selectedStudentId);

            St_Id.Text = s.St_Id.ToString();
            St_Id.Enabled = false;
            St_Fname.Text = s.St_Fname;
            St_Lname.Text = s.St_Lname;
            St_Address.Text = s.St_Address;
            St_Age.Text = s.St_Age.ToString();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Student s = new Student
            {
                St_Fname = St_Fname.Text,
                St_Lname = St_Lname.Text,
                St_Address = St_Address.Text,
                St_Id = Convert.ToInt32(St_Id.Text),
                St_Age = Convert.ToInt32(St_Age.Text)
            };

            int rowsAffected = BLL.EntityManger.StudentManager.UpdateDateIntoDB(s);
            MessageBox.Show($"{rowsAffected} row(s) Affected");
            //res.Text = $"{rowsAffected} row(s) Affected";
            //res.Text = "";
            LoadDataAndFresh();
        }

        
    }
}
