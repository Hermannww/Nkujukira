using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using System.Diagnostics;

namespace MetroFramework.Demo.Views
{
    public partial class PerpetratorsListDialog : MetroForm
    {
        public PerpetratorsListDialog()
        {
            InitializeComponent();
            this.Style = MetroColorStyle.Red;
            this.DrawTable(PerpetratorsManager.GetAllPerpetrators());

        }

        private void PerpetratorsListDialog_Load(object sender, EventArgs e)
        {

        }
        public void DrawTable(Perpetrator[] perpetrators_list)
        {
            object[] rows = null;
            dataGridViewX1.ColumnCount = 6;
            dataGridViewX1.ColumnHeadersVisible = true;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 9, FontStyle.Regular);
            dataGridViewX1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
            dataGridViewX1.Columns[0].Name = "Id";
            dataGridViewX1.Columns[1].Name = "Name";
            dataGridViewX1.Columns[2].Name = "Student";
            dataGridViewX1.Columns[3].Name = "Status";
            dataGridViewX1.Columns[4].Name = "Gender";
            dataGridViewX1.Columns[5].Name = "Creation Date";
            if (perpetrators_list.Length > 0)
            {
                rows = new object[perpetrators_list.Length];
                int i = 0;
                foreach (var perpetrator in perpetrators_list)
                {
                    String id = Convert.ToString(perpetrators_list[i].id);
                    String name = perpetrators_list[i].name;
                    String is_a_student = Convert.ToString(perpetrators_list[i].is_a_student);
                    String is_active = Convert.ToString(perpetrators_list[i].is_still_active);
                    String gender = perpetrators_list[i].gender;
                    String created_at = perpetrators_list[i].created_at;
                    string[] row = new string[] { id, name, is_a_student, is_active, gender, created_at };
                    rows[i] = row;
                    i++;
                }
                if (perpetrators_list != null)
                {

                    foreach (string[] rowArray in rows)
                    {
                        dataGridViewX1.Rows.Add(rowArray);

                    }
                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Deleting perpetrator");
            try
            {
                DialogResult response = MetroMessageBox.Show(this, "Are You Sure You Want To Delete The Selected Perpetrator", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (response == DialogResult.Yes)
                {
                    int selected_row = dataGridViewX1.CurrentRow.Index;
                    int id = Convert.ToInt32(dataGridViewX1[0, selected_row].Value);
                    bool perpetrator_deleted = PerpetratorsManager.Delete(id);
                    if (perpetrator_deleted)
                    {
                        MetroMessageBox.Show(this, "Perpetrator Deleted Successfully", "CONGRATULATIONS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewX1.Rows.RemoveAt(selected_row);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Unknown Error Occured while deleting. Please try again", "ERROR");
                    }
                }
                else if (response == DialogResult.No)
                {
                   

                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Displaying details NOW");
            try
            {
                int Row = dataGridViewX1.CurrentRow.Index;
                int id = Convert.ToInt32(dataGridViewX1[0, Row].Value);
                String name = Convert.ToString(dataGridViewX1[1, Row].Value);
                bool is_a_student = Convert.ToBoolean(dataGridViewX1[2, Row].Value);
                bool is_active = Convert.ToBoolean(dataGridViewX1[3, Row].Value);
                String gender = Convert.ToString(dataGridViewX1[4, Row].Value);
                String created_at = Convert.ToString(dataGridViewX1[5, Row].Value);
                PerpetratorDetailsForm form = new PerpetratorDetailsForm(new Perpetrator(id, name, PerpetratorsManager.GetPerpetratorFaces(id), is_a_student, is_active, gender, created_at), true);
                form.Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Displaying details NOW");
            try
            {
                int Row = dataGridViewX1.CurrentRow.Index;
                int id = Convert.ToInt32(dataGridViewX1[0, Row].Value);
                String name = Convert.ToString(dataGridViewX1[1, Row].Value);
                bool is_a_student = Convert.ToBoolean(dataGridViewX1[2, Row].Value);
                bool is_active = Convert.ToBoolean(dataGridViewX1[3, Row].Value);
                String gender = Convert.ToString(dataGridViewX1[4, Row].Value);
                String created_at = Convert.ToString(dataGridViewX1[5, Row].Value);
                PerpetratorDetailsForm form = new PerpetratorDetailsForm(new Perpetrator(id, name, PerpetratorsManager.GetPerpetratorFaces(id), is_a_student, is_active, gender, created_at), true);
                form.Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

    }
}
