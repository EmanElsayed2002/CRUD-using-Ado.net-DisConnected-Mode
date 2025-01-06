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
    public partial class FormRead : Form
    {
        DataTable dt;
        public FormRead()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = BLL.EntityManger.StudentManager.GetAll();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["St_Id"].ReadOnly = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.EndEdit();
                int rowsAffected = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr.RowState == DataRowState.Deleted)
                    {
                        rowsAffected += BLL.EntityManger.StudentManager.deleteDateFromDB(Convert.ToInt32(dr["St_Id", DataRowVersion.Original]));
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        Student s = new Student
                        {
                            St_Id = Convert.ToInt32(dr["St_Id"]),
                            St_Fname = Convert.ToString(dr["St_Fname"]),
                            St_Lname = Convert.ToString(dr["St_Lname"]),
                            St_Address = Convert.ToString(dr["St_Address"]),
                            St_Age = Convert.ToInt32(dr["St_Age"]),
                        };
                        rowsAffected += BLL.EntityManger.StudentManager.UpdateDateIntoDB(s);
                    }
                    else if (dr.RowState == DataRowState.Added)
                    {
                        Student s = new Student
                        {
                            St_Id = Convert.ToInt32(dr["St_Id"]),
                            St_Fname = Convert.ToString(dr["St_Fname"]),
                            St_Lname = Convert.ToString(dr["St_Lname"]),
                            St_Address = Convert.ToString(dr["St_Address"]),
                            St_Age = Convert.ToInt32(dr["St_Age"]),
                        };
                        rowsAffected += BLL.EntityManger.StudentManager.InsertDateIntoDB(s);
                    }
                }

                dt.AcceptChanges();
                ResLabel.Text = $"{rowsAffected} row(s) affected.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}");
            }
        }


        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }
    }
}
