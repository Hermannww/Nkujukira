namespace Nkujukira.Demo.Views
{
    partial class DashBoard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.similarity_dropdownlist = new System.Windows.Forms.NumericUpDown();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.save = new MetroFramework.Controls.MetroButton();
            this.change_theme_combobox = new MetroFramework.Controls.MetroComboBox();
            this.theme = new MetroFramework.Controls.MetroLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.similarity_dropdownlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.metroLabel2);
            this.panel1.Controls.Add(this.similarity_dropdownlist);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.save);
            this.panel1.Controls.Add(this.change_theme_combobox);
            this.panel1.Controls.Add(this.theme);
            this.panel1.Location = new System.Drawing.Point(15, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 246);
            this.panel1.TabIndex = 0;
            // 
            // similarity_dropdownlist
            // 
            this.similarity_dropdownlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.similarity_dropdownlist.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.similarity_dropdownlist.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.similarity_dropdownlist.Location = new System.Drawing.Point(335, 89);
            this.similarity_dropdownlist.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.similarity_dropdownlist.Name = "similarity_dropdownlist";
            this.similarity_dropdownlist.Size = new System.Drawing.Size(60, 27);
            this.similarity_dropdownlist.TabIndex = 38;
            this.similarity_dropdownlist.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(127, 89);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(123, 29);
            this.metroLabel1.TabIndex = 37;
            this.metroLabel1.Text = "Similarity Threshold";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // save
            // 
            this.save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save.Location = new System.Drawing.Point(310, 183);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(138, 50);
            this.save.TabIndex = 36;
            this.save.Text = "Save Changes";
            this.save.UseSelectable = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // change_theme_combobox
            // 
            this.change_theme_combobox.FormattingEnabled = true;
            this.change_theme_combobox.ItemHeight = 23;
            this.change_theme_combobox.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.change_theme_combobox.Location = new System.Drawing.Point(310, 36);
            this.change_theme_combobox.Name = "change_theme_combobox";
            this.change_theme_combobox.PromptText = "Dark";
            this.change_theme_combobox.Size = new System.Drawing.Size(138, 29);
            this.change_theme_combobox.TabIndex = 34;
            this.change_theme_combobox.UseSelectable = true;
            // 
            // theme
            // 
            this.theme.Location = new System.Drawing.Point(150, 36);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(100, 29);
            this.theme.TabIndex = 35;
            this.theme.Text = "Change Theme";
            this.theme.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(0, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(490, 2);
            this.label12.TabIndex = 32;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Location = new System.Drawing.Point(3, 134);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(247, 29);
            this.metroLabel2.TabIndex = 39;
            this.metroLabel2.Text = "Minimum Faces per Perpetrator/Student";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(335, 134);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 27);
            this.numericUpDown1.TabIndex = 40;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(487, 321);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DashBoard";
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.Text = "User Settings";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.similarity_dropdownlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown similarity_dropdownlist;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton save;
        private MetroFramework.Controls.MetroComboBox change_theme_combobox;
        private MetroFramework.Controls.MetroLabel theme;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private MetroFramework.Controls.MetroLabel metroLabel2;

    }
}
