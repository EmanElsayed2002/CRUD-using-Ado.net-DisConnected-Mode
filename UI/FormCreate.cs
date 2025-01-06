using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Entity;
namespace UI
{
    public partial class FormCreate : Form
    {
        public FormCreate()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(St_Id.Text) ||
        string.IsNullOrWhiteSpace(St_Fname.Text) ||
        string.IsNullOrWhiteSpace(St_Lname.Text) ||
        string.IsNullOrWhiteSpace(St_Address.Text) ||
        string.IsNullOrWhiteSpace(St_Age.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(St_Id.Text, out int stId) || !int.TryParse(St_Age.Text, out int stAge))
            {
                MessageBox.Show("ID and Age must be numeric values.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Student s = new Student
            {
                St_Id = Convert.ToInt32(St_Id.Text),
                St_Fname = St_Fname.Text,
                St_Lname = St_Lname.Text,
                St_Address = St_Address.Text,
                St_Age = Convert.ToInt32(St_Age.Text),
            };
            int rowsAffeted = BLL.EntityManger.StudentManager.InsertDateIntoDB(s);
            ResText.Text = $"{rowsAffeted} row(s) Affected";
        }
    }
}
