using MetroFramework.Controls;
namespace Nkujukira.Demo.Views
{
    partial class PerpetratorsListDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.user_name = new MetroFramework.Controls.MetroTextBox();
            this.all_perpetrators_table = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeloginCredentials = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.all_perpetrators_table)).BeginInit();
            this.SuspendLayout();
            // 
            // user_name
            // 
            this.user_name.Lines = new string[0];
            this.user_name.Location = new System.Drawing.Point(271, 63);
            this.user_name.MaxLength = 32767;
            this.user_name.Name = "user_name";
            this.user_name.PasswordChar = '\0';
            this.user_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.user_name.SelectedText = "";
            this.user_name.Size = new System.Drawing.Size(290, 26);
            this.user_name.TabIndex = 5;
            this.user_name.UseSelectable = true;
            // 
            // all_perpetrators_table
            // 
            this.all_perpetrators_table.AllowUserToResizeColumns = false;
            this.all_perpetrators_table.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.all_perpetrators_table.ColumnHeadersHeight = 28;
            this.all_perpetrators_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.Status,
            this.photo,
            this.gender,
            this.date});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.all_perpetrators_table.DefaultCellStyle = dataGridViewCellStyle1;
            this.all_perpetrators_table.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.all_perpetrators_table.Location = new System.Drawing.Point(11, 95);
            this.all_perpetrators_table.MultiSelect = false;
            this.all_perpetrators_table.Name = "all_perpetrators_table";
            this.all_perpetrators_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.all_perpetrators_table.SelectAllSignVisible = false;
            this.all_perpetrators_table.Size = new System.Drawing.Size(643, 253);
            this.all_perpetrators_table.TabIndex = 6;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            // 
            // Status
            // 
            this.Status.HeaderText = "Student";
            this.Status.Name = "Status";
            // 
            // photo
            // 
            this.photo.HeaderText = "Active";
            this.photo.Name = "photo";
            // 
            // gender
            // 
            this.gender.HeaderText = "Gender";
            this.gender.Name = "gender";
            // 
            // date
            // 
            this.date.HeaderText = "Creation Date";
            this.date.Name = "date";
            // 
            // changeloginCredentials
            // 
            this.changeloginCredentials.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.changeloginCredentials.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeloginCredentials.Location = new System.Drawing.Point(567, 63);
            this.changeloginCredentials.Name = "changeloginCredentials";
            this.changeloginCredentials.Size = new System.Drawing.Size(66, 26);
            this.changeloginCredentials.TabIndex = 20;
            this.changeloginCredentials.Text = "Search";
            this.changeloginCredentials.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.Location = new System.Drawing.Point(40, 63);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(66, 26);
            this.metroButton1.TabIndex = 21;
            this.metroButton1.Text = "View";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.ViewDetailsButton_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton2.Location = new System.Drawing.Point(112, 63);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(66, 26);
            this.metroButton2.TabIndex = 22;
            this.metroButton2.Text = "Edit";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.EditDetailsButton_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton3.Location = new System.Drawing.Point(184, 63);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(66, 26);
            this.metroButton3.TabIndex = 23;
            this.metroButton3.Text = "Delete";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // PerpetratorsListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 355);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.changeloginCredentials);
            this.Controls.Add(this.all_perpetrators_table);
            this.Controls.Add(this.user_name);
            this.Name = "PerpetratorsListDialog";
            this.Text = "Perpetrators List Dialogs";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.PerpetratorsListDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.all_perpetrators_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroTextBox user_name;
        private DevComponents.DotNetBar.Controls.DataGridViewX all_perpetrators_table;
        private MetroFramework.Controls.MetroButton changeloginCredentials;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn photo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
    
        //private  role;
        
    }
}