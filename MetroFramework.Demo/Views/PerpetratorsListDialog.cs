using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Managers;
using System.Diagnostics;
using MetroFramework;

namespace Nkujukira.Demo.Views
{
    public partial class PerpetratorsListDialog : MetroForm
    {
        private string DELETE_CONFRIRMATION = "Are You Sure You Want To Do This?";
        private string CAPTION = "CONFIRMATION";
        private string SUCESS_MESSAGE = "Operation Successfull";
        private string ERROR_MESSAGE = "Operation Failed. Please try again";
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
            all_perpetrators_table.ColumnCount = 6;
            all_perpetrators_table.ColumnHeadersVisible = true;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 9, FontStyle.Regular);
            all_perpetrators_table.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
            all_perpetrators_table.Columns[0].Name = "Id";
            all_perpetrators_table.Columns[1].Name = "Name";
            all_perpetrators_table.Columns[2].Name = "Student";
            all_perpetrators_table.Columns[3].Name = "Status";
            all_perpetrators_table.Columns[4].Name = "Gender";
            all_perpetrators_table.Columns[5].Name = "Creation Date";

            if (perpetrators_list.Length > 0)
            {
                rows                    = new object[perpetrators_list.Length];
                int i                   = 0;

                foreach (var perpetrator in perpetrators_list)
                {
                    String id           = ""+perpetrators_list[i].id;
                    String name         = perpetrators_list[i].name;
                    String is_a_student = ""+perpetrators_list[i].is_a_student;
                    String is_active    = ""+perpetrators_list[i].is_still_active;
                    String gender       = perpetrators_list[i].gender;
                    String created_at   = perpetrators_list[i].created_at;
                    string[] row        = new string[] { id, name, is_a_student, is_active, gender, created_at };
                    rows[i]             = row;
                    i++;
                }

                if (perpetrators_list != null)
                {

                    foreach (string[] rowArray in rows)
                    {
                        all_perpetrators_table.Rows.Add(rowArray);

                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Deleting perpetrator");
            try
            {
                DialogResult response = MessageBox.Show(this, DELETE_CONFRIRMATION, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    //GET ID OF PERP SELECTED
                    int selected_row = all_perpetrators_table.CurrentRow.Index;
                    int id = Convert.ToInt32(all_perpetrators_table[0, selected_row].Value);

                    //GET PERPETRATOR ASSOCIATED WITH ID
                    Perpetrator perp = PerpetratorsManager.GetPerpetrator(id);

                    if (perp != null)
                    {
                        //DELETE HIS CRIMES AND VICTIMS ASSOCIATED WITH PERP
                        DeleteCrimesAndVictimsOfCrimes(perp.id);

                        //DELETE PERP
                        PerpetratorsManager.Delete(perp.id);

                        //SHOW SUCEES MESSAGE
                        MessageBox.Show(this, SUCESS_MESSAGE, CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //UPDATE GUI
                        all_perpetrators_table.Rows.RemoveAt(selected_row);
                    }
                    else
                    {
                        MessageBox.Show(this, ERROR_MESSAGE, CAPTION);
                    }

                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "");
            }
        }

        private void DeleteCrimesAndVictimsOfCrimes(int perp_id)
        {
            //GET CRIMES COMMITTED BY THE PERP
            Crime[] crimes = CrimesManager.GetCrimesCommitted(perp_id);


            //DELETE EACH CRIME AND THE VICTIMS OF THE CRIME
            foreach (var crime in crimes)
            {
                DeleteVictimsOfCrimes(crime.id);

                CrimesManager.Delete(crime.id);
            }
        }

        private void DeleteVictimsOfCrimes(int crime_id)
        {
            Victim[] victims = VictimsManager.GetVictimsOfCrime(crime_id);

            foreach (var victim in victims)
            {
                VictimsManager.Delete(victim.id);
            }
        }



        private void EditDetailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                int Row                     = all_perpetrators_table.CurrentRow.Index;
                int id                      = Convert.ToInt32(all_perpetrators_table[0, Row].Value);
                String name                 = Convert.ToString(all_perpetrators_table[1, Row].Value);
                bool is_a_student           = Convert.ToBoolean(all_perpetrators_table[2, Row].Value);
                bool is_active              = Convert.ToBoolean(all_perpetrators_table[3, Row].Value);
                String gender               = Convert.ToString(all_perpetrators_table[4, Row].Value);
                String created_at           = Convert.ToString(all_perpetrators_table[5, Row].Value);

                Perpetrator perp            = new Perpetrator(id, name, PerpetratorsManager.GetPerpetratorFaces(id), is_a_student, is_active, gender, created_at);
                PerpetratorDetailsForm form = new PerpetratorDetailsForm(perp, true);
                form.Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private void ViewDetailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                int Row                     = all_perpetrators_table.CurrentRow.Index;
                int id                      = Convert.ToInt32(all_perpetrators_table[0, Row].Value);
                String name                 = Convert.ToString(all_perpetrators_table[1, Row].Value);
                bool is_a_student           = Convert.ToBoolean(all_perpetrators_table[2, Row].Value);
                bool is_active              = Convert.ToBoolean(all_perpetrators_table[3, Row].Value);
                String gender               = Convert.ToString(all_perpetrators_table[4, Row].Value);
                String created_at           = Convert.ToString(all_perpetrators_table[5, Row].Value);
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
