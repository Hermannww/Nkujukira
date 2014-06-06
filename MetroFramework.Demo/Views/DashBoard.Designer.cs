namespace MetroFramework.Demo.Views
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
            this.show_detected_faces = new MetroFramework.Controls.MetroCheckBox();
            this.change_theme = new MetroFramework.Controls.MetroComboBox();
            this.theme = new MetroFramework.Controls.MetroLabel();
            this.save = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // show_detected_faces
            // 
            this.show_detected_faces.AutoSize = true;
            this.show_detected_faces.Cursor = System.Windows.Forms.Cursors.Hand;
            this.show_detected_faces.Location = new System.Drawing.Point(78, 116);
            this.show_detected_faces.Name = "show_detected_faces";
            this.show_detected_faces.Size = new System.Drawing.Size(166, 15);
            this.show_detected_faces.TabIndex = 11;
            this.show_detected_faces.Text = "Remove Login Component";
            this.show_detected_faces.UseSelectable = true;
            // 
            // change_theme
            // 
            this.change_theme.FormattingEnabled = true;
            this.change_theme.ItemHeight = 23;
            this.change_theme.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.change_theme.Location = new System.Drawing.Point(184, 61);
            this.change_theme.Name = "change_theme";
            this.change_theme.PromptText = "Dark";
            this.change_theme.Size = new System.Drawing.Size(166, 29);
            this.change_theme.TabIndex = 16;
            this.change_theme.UseSelectable = true;
            // 
            // theme
            // 
            this.theme.Location = new System.Drawing.Point(78, 61);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(100, 29);
            this.theme.TabIndex = 17;
            this.theme.Text = "Change Theme";
            // 
            // save
            // 
            this.save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save.Location = new System.Drawing.Point(134, 174);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(122, 32);
            this.save.TabIndex = 30;
            this.save.Text = "Save Changes";
            this.save.UseSelectable = true;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.save);
            this.Controls.Add(this.change_theme);
            this.Controls.Add(this.theme);
            this.Controls.Add(this.show_detected_faces);
            this.Name = "DashBoard";
            this.Size = new System.Drawing.Size(487, 340);
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.MetroCheckBox show_detected_faces;
        private Controls.MetroComboBox change_theme;
        private Controls.MetroLabel theme;
        private Controls.MetroButton save;
    }
}
