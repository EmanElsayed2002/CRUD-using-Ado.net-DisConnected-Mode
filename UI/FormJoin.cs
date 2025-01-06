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
    public partial class FormJoin : Form
    {
        DataTable dt;
        public FormJoin()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            dt = BLL.EntityManger.StudentManager.GetFullName();
            comboBoxStudentNames.DataSource = dt;
            comboBoxStudentNames.DisplayMember = "Fullname";
            comboBoxStudentNames.ValueMember = "St_Id";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (comboBoxStudentNames.SelectedValue == null)
            {
                MessageBox.Show("Please select a student first.");
                return;
            }
            //if (comboBoxStudentNames.SelectedValue == null) return;
            try
            {
                int selectedItem = Convert.ToInt32(comboBoxStudentNames.SelectedValue);
                dt = BLL.EntityManger.StudentManager.ShowStudentSourse(selectedItem);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
