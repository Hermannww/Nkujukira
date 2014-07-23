namespace Nkujukira.Demo.Views
{
    partial class SelectPerpetratorFacesForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectPerpetratorFacesForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.done_button = new MetroFramework.Controls.MetroButton();
            this.image_list_view = new Manina.Windows.Forms.ImageListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label_separator = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_separator);
            this.panel1.Controls.Add(this.done_button);
            this.panel1.Controls.Add(this.image_list_view);
            this.panel1.Location = new System.Drawing.Point(11, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 541);
            this.panel1.TabIndex = 0;
            // 
            // done_button
            // 
            this.done_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.done_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.done_button.Location = new System.Drawing.Point(155, 476);
            this.done_button.Name = "done_button";
            this.done_button.Size = new System.Drawing.Size(204, 48);
            this.done_button.TabIndex = 28;
            this.done_button.Text = "Done";
            this.done_button.UseSelectable = true;
            this.done_button.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // image_list_view
            // 
            this.image_list_view.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.image_list_view.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image_list_view.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image_list_view.DefaultImage = ((System.Drawing.Image)(resources.GetObject("image_list_view.DefaultImage")));
            this.image_list_view.ErrorImage = ((System.Drawing.Image)(resources.GetObject("image_list_view.ErrorImage")));
            this.image_list_view.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.image_list_view.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.image_list_view.Location = new System.Drawing.Point(11, 17);
            this.image_list_view.Name = "image_list_view";
            this.image_list_view.Size = new System.Drawing.Size(477, 428);
            this.image_list_view.TabIndex = 0;
            this.image_list_view.Text = "";
            this.image_list_view.SelectionChanged += new System.EventHandler(this.ImageListView1_SelectionChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label_separator
            // 
            this.label_separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_separator.Location = new System.Drawing.Point(-1, 457);
            this.label_separator.Name = "label_separator";
            this.label_separator.Size = new System.Drawing.Size(503, 2);
            this.label_separator.TabIndex = 29;
            // 
            // SelectPerpetratorFacesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 611);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectPerpetratorFacesForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Select 5 faces Of the Perpetrator";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private Manina.Windows.Forms.ImageListView image_list_view;
        private MetroFramework.Controls.MetroButton done_button;
        private System.Windows.Forms.Label label_separator;
    }
}