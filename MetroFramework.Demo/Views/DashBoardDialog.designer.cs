using MetroFramework;
using MetroFramework.Controls;
namespace Nkujukira.Demo.Views
{
    partial class DashBoardDialog
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
            this.save_changes = new MetroFramework.Controls.MetroButton();
            this.change_theme = new MetroFramework.Controls.MetroComboBox();
            this.remove_login_component = new MetroFramework.Controls.MetroCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // save_changes
            // 
            this.save_changes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.save_changes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_changes.Location = new System.Drawing.Point(183, 169);
            this.save_changes.Name = "save_changes";
            this.save_changes.Size = new System.Drawing.Size(122, 32);
            this.save_changes.TabIndex = 34;
            this.save_changes.Text = "Save Changes";
            this.save_changes.UseSelectable = true;
            this.save_changes.Click += new System.EventHandler(this.save_changes_Click);
            // 
            // change_theme
            // 
            this.change_theme.FormattingEnabled = true;
            this.change_theme.ItemHeight = 23;
            this.change_theme.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.change_theme.Location = new System.Drawing.Point(228, 62);
            this.change_theme.Name = "change_theme";
            this.change_theme.PromptText = "Dark";
            this.change_theme.Size = new System.Drawing.Size(166, 29);
            this.change_theme.TabIndex = 32;
            this.change_theme.UseSelectable = true;
            // 
            // remove_login_component
            // 
            this.remove_login_component.AutoSize = true;
            this.remove_login_component.Cursor = System.Windows.Forms.Cursors.Hand;
            this.remove_login_component.FontSize = MetroCheckBoxSize.Medium;
            this.remove_login_component.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.remove_login_component.Location = new System.Drawing.Point(147, 109);
            this.remove_login_component.Name = "remove_login_component";
            this.remove_login_component.Size = new System.Drawing.Size(189, 19);
            this.remove_login_component.TabIndex = 31;
            this.remove_login_component.Text = "Remove Login Component";
            this.remove_login_component.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.remove_login_component.UseCustomBackColor = true;
            this.remove_login_component.UseCustomForeColor = true;
            this.remove_login_component.UseSelectable = true;
            this.remove_login_component.CheckedChanged += new System.EventHandler(this.remove_login_component_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(144, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 35;
            this.label1.Text = "Theme";
            // 
            // DashBoardDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 247);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save_changes);
            this.Controls.Add(this.change_theme);
            this.Controls.Add(this.remove_login_component);
            this.Name = "DashBoardDialog";
            this.Text = "Dash Bord";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.DashBordDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton save_changes;
        private MetroComboBox change_theme;
        private MetroCheckBox remove_login_component;
        private System.Windows.Forms.Label label1;
    }
}