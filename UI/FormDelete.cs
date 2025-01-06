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
    public partial class FormDelete : Form
    {
        DataTable dt;
        public FormDelete()
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxStudentNames.SelectedValue == null) return;


            int rowsAffected = 0;
            int selectedItem = Convert.ToInt32(comboBoxStudentNames.SelectedValue);
            rowsAffected += BLL.EntityManger.StudentManager.deleteCouseStudent(selectedItem);
            rowsAffected += BLL.EntityManger.StudentManager.deleteDateFromDB(selectedItem);
            MessageBox.Show($"{rowsAffected} row(s) Affected");
            Load();
        }
    }
}
