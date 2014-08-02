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
using Nkujukira.Demo.Singletons;
using Nkujukira.Demo.Custom_Controls;

namespace Nkujukira.Demo.Views
{
    public partial class PerpetratorsListDialog : MetroForm
    {
        private string DELETE_CONFRIRMATION = "Are You Sure You Want To Do This?";
        private string CAPTION              = "CONFIRMATION";
        private string SUCESS_MESSAGE       = "Operation Successfull";
        private string ERROR_MESSAGE        = "Operation Failed. Please try again";
        private Perpetrator[] all_active_perps;
        public int y                        = 9;
        private int x                       = 13;
        private int Y_INCREMENT=198;

        public PerpetratorsListDialog()
        {
            all_active_perps = PerpetratorsManager.GetAllActivePerpetrators();
            InitializeComponent();        

        }

        private void PerpetratorsListDialog_Load(object sender, EventArgs e)
        {
            foreach (var perp in all_active_perps) 
            {
                Panel perps_panel = CreateNewPerpPanel(perp);
                AddPanelToForm(perps_panel);
                y += Y_INCREMENT;
            }
        }

        private void AddPanelToForm(Panel perps_panel)
        {
            this.main_panel.Controls.Add(perps_panel);
        }

        private Panel CreateNewPerpPanel(Perpetrator perp)
        {
            ComboBox comboBox_gender           = CreateGenderField(perp.gender);
            Label gender_label                 = CreateGenderLabel();
            ComboBox comboBox_is_active        = CreateIsActiveField(perp.is_still_active);
            Label is_active_label              = CreateIsActiveLabel();
            ComboBox comboBox_is_a_student     = CreateIsAStudentField(perp.is_a_student);
            Label is_a_student_label           = CreateIsAStudentLabel();
            TextBox textBox_perpetrator_name   = CreatePerpsNameField(perp.name);
            Label perps_name_label             = CreatePerpsNameLabel();
            PictureBox perpetrator_picture_box = CreatePerpsPictureBox(perp.faces[0].ToBitmap());
            Label vertical_separator           = CreateVerticalSeparator();

            Control[] all_controls             = {
                                                    vertical_separator,
                                                    comboBox_gender,
                                                    gender_label,
                                                    comboBox_is_active,
                                                    is_active_label,
                                                    comboBox_is_a_student,
                                                    is_a_student_label,
                                                    textBox_perpetrator_name,
                                                    perps_name_label,
                                                    perpetrator_picture_box
                                                 };

   
            Panel a_panel                      = new Panel();
            a_panel.BorderStyle                = System.Windows.Forms.BorderStyle.FixedSingle;
            a_panel.Controls.AddRange(all_controls);
            a_panel.Font                       = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            a_panel.ForeColor                  = System.Drawing.SystemColors.ControlLight;
            a_panel.Location                   = new System.Drawing.Point(x, y);
            a_panel.Name                       = "panel2";
            a_panel.Size                       = new System.Drawing.Size(515, 191);
            a_panel.TabIndex                   = 1;
            return a_panel;
        }

        private MyPictureBox CreatePerpsPictureBox(Bitmap bitmap_image)
        {
            MyPictureBox perps_picturebox = new MyPictureBox();
            perps_picturebox.Location     = new System.Drawing.Point(15, 13);
            perps_picturebox.Name         = "perpetrator_picture_box";
            perps_picturebox.Size         = new System.Drawing.Size(120, 120);
            perps_picturebox.TabIndex     = 0;
            perps_picturebox.TabStop      = false;
            perps_picturebox.Image = bitmap_image;
            return perps_picturebox;
        }

        private TextBox CreatePerpsNameField(String name)
        {
            TextBox perps_name_textbox  = new TextBox();
            perps_name_textbox.Location = new System.Drawing.Point(293, 13);
            perps_name_textbox.Name     = "textBox_perpetrator_name";
            perps_name_textbox.Text = name;
            perps_name_textbox.Enabled = false;
            perps_name_textbox.Size     = new System.Drawing.Size(208, 27);
            perps_name_textbox.TabIndex = 11;
            return perps_name_textbox;
            
        }

        private Label CreateVerticalSeparator() 
        {
            Label vertical_separator = new Label();
            vertical_separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            vertical_separator.Location = new System.Drawing.Point(180, 0);
            vertical_separator.Name = "label6";
            vertical_separator.Size = new System.Drawing.Size(1, 190);
            vertical_separator.TabIndex = 35;
            return vertical_separator;
        }

        public Label CreatePerpsNameLabel() 
        {
            Label perps_name_label     = new Label();
            perps_name_label.AutoSize  = true;
            perps_name_label.Font      = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            perps_name_label.ForeColor = System.Drawing.SystemColors.ControlLight;
            perps_name_label.Location  = new System.Drawing.Point(191, 16);
            perps_name_label.Name      = "label1";
            perps_name_label.Size      = new System.Drawing.Size(55, 19);
            perps_name_label.TabIndex  = 1;
            perps_name_label.Text      = "Name :";
            return perps_name_label;
        }

        private ComboBox CreateIsAStudentField(bool is_a_student)
        {
            ComboBox is_a_student_combobox = new ComboBox();
            is_a_student_combobox.Location = new System.Drawing.Point(293, 104);
            is_a_student_combobox.Name     = "comboBox_is_active";
            is_a_student_combobox.Size     = new System.Drawing.Size(208, 27);
            is_a_student_combobox.TabIndex = 29;
            is_a_student_combobox.Text = "" + is_a_student;
            is_a_student_combobox.Enabled = false;

            return is_a_student_combobox;
            
        }

        private Label CreateIsAStudentLabel() 
        {
            Label is_a_student_label          = new Label();
            is_a_student_label.AutoSize       = true;
            is_a_student_label.Font           = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            is_a_student_label.ForeColor      = System.Drawing.SystemColors.ControlLight;
            is_a_student_label.Location       = new System.Drawing.Point(191, 62);
            is_a_student_label.Name           = "label2";
            is_a_student_label.Size           = new System.Drawing.Size(86, 19);
            is_a_student_label.TabIndex       = 2;
            is_a_student_label.Text           = "Is A Student";
            return is_a_student_label;
        }

        private ComboBox CreateIsActiveField(bool is_active)
        {
            ComboBox is_active_combobox       = new ComboBox();
            is_active_combobox.Enabled        = false;
            is_active_combobox.Location       = new System.Drawing.Point(293, 104);
            is_active_combobox.Name           = "comboBox_is_active";
            is_active_combobox.Size           = new System.Drawing.Size(208, 27);
            is_active_combobox.TabIndex       = 29;
            is_active_combobox.Text           = ""+is_active;
            is_active_combobox.Enabled = false;

            return is_active_combobox;
        }

        private Label CreateIsActiveLabel() 
        {
            Label is_a_active_label           = new Label();
            is_a_active_label.AutoSize        = true;
            is_a_active_label.Font            = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            is_a_active_label.ForeColor       = System.Drawing.SystemColors.ControlLight;
            is_a_active_label.Location        = new System.Drawing.Point(191, 107);
            is_a_active_label.Name            = "label3";
            is_a_active_label.Size            = new System.Drawing.Size(64, 19);
            is_a_active_label.TabIndex        = 3;
            is_a_active_label.Text            = "Is Active";
            return is_a_active_label;
        }

        private ComboBox CreateGenderField(string gender)
        {
            ComboBox gender_combobox          = new ComboBox();
            gender_combobox.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            gender_combobox.FormattingEnabled = true;
            gender_combobox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            gender_combobox.Location          = new System.Drawing.Point(293, 147);
            gender_combobox.Name              = "comboBox_gender";
            gender_combobox.Size              = new System.Drawing.Size(208, 27);
            gender_combobox.TabIndex          = 31;
            gender_combobox.Text = gender;
            gender_combobox.Enabled = false;
            return gender_combobox;
        }

        public Label CreateGenderLabel()
        {

            Label gender_label                = new Label();
            gender_label.AutoSize             = true;
            gender_label.Font                 = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gender_label.ForeColor            = System.Drawing.SystemColors.ControlLight;
            gender_label.Location             = new System.Drawing.Point(191, 150);
            gender_label.Name                 = "label4";
            gender_label.Size                 = new System.Drawing.Size(56, 19);
            gender_label.TabIndex             = 30;
            gender_label.Text                 = "Gender";
            return gender_label;
        }



      
    }
}
