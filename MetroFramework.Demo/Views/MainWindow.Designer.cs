using Emgu.CV.UI;
namespace MetroFramework.Demo
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.show_detected_faces = new MetroFramework.Controls.MetroCheckBox();
            this.stop_button_1 = new MetroFramework.Controls.MetroButton();
            this.turn_on_button = new MetroFramework.Controls.MetroButton();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.total_time_label = new System.Windows.Forms.Label();
            this.time_elapsed_label = new System.Windows.Forms.Label();
            this.review_footage_color_slider = new MB.Controls.ColorSlider();
            this.panel_for_detected_faces = new System.Windows.Forms.Panel();
            this.review_footage_image_box = new Emgu.CV.UI.ImageBox();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.stop_button_2 = new MetroFramework.Controls.MetroButton();
            this.pick_video_button = new MetroFramework.Controls.MetroButton();
            this.show_detected_faces2 = new MetroFramework.Controls.MetroCheckBox();
            this.pause_button = new MetroFramework.Controls.MetroButton();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.colorSlider1 = new MB.Controls.ColorSlider();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.imageBox4 = new Emgu.CV.UI.ImageBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.perpetrator_box = new System.Windows.Forms.PictureBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroComboBox2 = new MetroFramework.Controls.MetroComboBox();
            this.metroToggle3 = new MetroFramework.Controls.MetroToggle();
            this.metroToggle2 = new MetroFramework.Controls.MetroToggle();
            this.metroRadioButton3 = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButton2 = new MetroFramework.Controls.MetroRadioButton();
            this.metroCheckBox3 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.userTable = new System.Windows.Forms.DataGridView();
            this.metroButton12 = new MetroFramework.Controls.MetroButton();
            this.metroButton11 = new MetroFramework.Controls.MetroButton();
            this.metroButton10 = new MetroFramework.Controls.MetroButton();
            this.metroButton9 = new MetroFramework.Controls.MetroButton();
            this.metroButton8 = new MetroFramework.Controls.MetroButton();
            this.metroButton7 = new MetroFramework.Controls.MetroButton();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroToolTip = new MetroFramework.Components.MetroToolTip();
            this.metroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.icons_list = new System.Windows.Forms.ImageList(this.components);
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.review_footage_image_box)).BeginInit();
            this.metroTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perpetrator_box)).BeginInit();
            this.metroTabPage4.SuspendLayout();
            this.metroTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Controls.Add(this.metroTabPage5);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Multiline = true;
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 4;
            this.metroTabControl1.Size = new System.Drawing.Size(926, 445);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.AutoScroll = true;
            this.metroTabPage1.Controls.Add(this.label5);
            this.metroTabPage1.Controls.Add(this.label4);
            this.metroTabPage1.Controls.Add(this.label3);
            this.metroTabPage1.Controls.Add(this.label2);
            this.metroTabPage1.Controls.Add(this.show_detected_faces);
            this.metroTabPage1.Controls.Add(this.stop_button_1);
            this.metroTabPage1.Controls.Add(this.turn_on_button);
            this.metroTabPage1.HorizontalScrollbar = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Padding = new System.Windows.Forms.Padding(25);
            this.metroTabPage1.Size = new System.Drawing.Size(918, 400);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Live Stream";
            this.metroTabPage1.VerticalScrollbar = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // label5
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label5, true);
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Camera 4";
            // 
            // label4
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label4, true);
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Camera 2";
            // 
            // label3
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label3, true);
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Camera 3";
            // 
            // label2
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label2, true);
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Camera 1";
            // 
            // show_detected_faces
            // 
            this.show_detected_faces.AutoSize = true;
            this.show_detected_faces.Cursor = System.Windows.Forms.Cursors.Hand;
            this.show_detected_faces.Location = new System.Drawing.Point(529, 3);
            this.show_detected_faces.Name = "show_detected_faces";
            this.show_detected_faces.Size = new System.Drawing.Size(134, 15);
            this.show_detected_faces.TabIndex = 10;
            this.show_detected_faces.Text = "Show Detected Faces";
            this.metroToolTip.SetToolTip(this.show_detected_faces, "Checkbox Tooltip");
            this.show_detected_faces.UseSelectable = true;
            // 
            // stop_button_1
            // 
            this.stop_button_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stop_button_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stop_button_1.Location = new System.Drawing.Point(112, 363);
            this.stop_button_1.Name = "stop_button_1";
            this.stop_button_1.Size = new System.Drawing.Size(98, 37);
            this.stop_button_1.TabIndex = 9;
            this.stop_button_1.Text = "Stop";
            this.metroToolTip.SetToolTip(this.stop_button_1, "Button Tooltip");
            this.stop_button_1.UseSelectable = true;
            // 
            // turn_on_button
            // 
            this.turn_on_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.turn_on_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.turn_on_button.Location = new System.Drawing.Point(3, 363);
            this.turn_on_button.Name = "turn_on_button";
            this.turn_on_button.Size = new System.Drawing.Size(103, 37);
            this.turn_on_button.TabIndex = 5;
            this.turn_on_button.Text = "Turn On";
            this.metroToolTip.SetToolTip(this.turn_on_button, "Button Tooltip");
            this.turn_on_button.UseSelectable = true;
            this.turn_on_button.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.AutoScroll = true;
            this.metroTabPage2.Controls.Add(this.total_time_label);
            this.metroTabPage2.Controls.Add(this.time_elapsed_label);
            this.metroTabPage2.Controls.Add(this.review_footage_color_slider);
            this.metroTabPage2.Controls.Add(this.panel_for_detected_faces);
            this.metroTabPage2.Controls.Add(this.review_footage_image_box);
            this.metroTabPage2.Controls.Add(this.metroButton4);
            this.metroTabPage2.Controls.Add(this.metroButton3);
            this.metroTabPage2.Controls.Add(this.stop_button_2);
            this.metroTabPage2.Controls.Add(this.pick_video_button);
            this.metroTabPage2.Controls.Add(this.show_detected_faces2);
            this.metroTabPage2.Controls.Add(this.pause_button);
            this.metroTabPage2.HorizontalScrollbar = true;
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Padding = new System.Windows.Forms.Padding(25);
            this.metroTabPage2.Size = new System.Drawing.Size(918, 400);
            this.metroTabPage2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTabPage2.TabIndex = 2;
            this.metroTabPage2.Text = "Review Footage";
            this.metroTabPage2.VerticalScrollbar = true;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            this.metroTabPage2.Visible = false;
            // 
            // total_time_label
            // 
            this.total_time_label.AutoSize = true;
            this.total_time_label.Location = new System.Drawing.Point(374, 343);
            this.total_time_label.Name = "total_time_label";
            this.total_time_label.Size = new System.Drawing.Size(49, 13);
            this.total_time_label.TabIndex = 25;
            this.total_time_label.Text = "00:00:00";
            // 
            // time_elapsed_label
            // 
            this.time_elapsed_label.AutoSize = true;
            this.time_elapsed_label.Location = new System.Drawing.Point(4, 344);
            this.time_elapsed_label.Name = "time_elapsed_label";
            this.time_elapsed_label.Size = new System.Drawing.Size(49, 13);
            this.time_elapsed_label.TabIndex = 24;
            this.time_elapsed_label.Text = "00:00:00";
            // 
            // review_footage_color_slider
            // 
            this.review_footage_color_slider.BackColor = System.Drawing.Color.Transparent;
            this.review_footage_color_slider.BarInnerColor = System.Drawing.Color.White;
            this.review_footage_color_slider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.review_footage_color_slider.ElapsedInnerColor = System.Drawing.Color.Red;
            this.review_footage_color_slider.ElapsedOuterColor = System.Drawing.Color.Maroon;
            this.review_footage_color_slider.LargeChange = ((uint)(5u));
            this.review_footage_color_slider.Location = new System.Drawing.Point(4, 317);
            this.review_footage_color_slider.Name = "review_footage_color_slider";
            this.review_footage_color_slider.Size = new System.Drawing.Size(419, 23);
            this.review_footage_color_slider.SmallChange = ((uint)(1u));
            this.review_footage_color_slider.TabIndex = 23;
            this.review_footage_color_slider.Text = "colorSlider2";
            this.review_footage_color_slider.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.review_footage_color_slider.Value = 0;
            this.review_footage_color_slider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SlidersScroll);
            // 
            // panel_for_detected_faces
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.panel_for_detected_faces, true);
            this.panel_for_detected_faces.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_for_detected_faces.Location = new System.Drawing.Point(439, 47);
            this.panel_for_detected_faces.Name = "panel_for_detected_faces";
            this.panel_for_detected_faces.Size = new System.Drawing.Size(272, 185);
            this.panel_for_detected_faces.TabIndex = 22;
            // 
            // review_footage_image_box
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.review_footage_image_box, true);
            this.review_footage_image_box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.review_footage_image_box.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.review_footage_image_box.Location = new System.Drawing.Point(4, 16);
            this.review_footage_image_box.Name = "review_footage_image_box";
            this.review_footage_image_box.Size = new System.Drawing.Size(419, 325);
            this.review_footage_image_box.TabIndex = 2;
            this.review_footage_image_box.TabStop = false;
            this.review_footage_image_box.Click += new System.EventHandler(this.review_footage_image_box_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton4.Location = new System.Drawing.Point(439, 292);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(103, 37);
            this.metroButton4.TabIndex = 21;
            this.metroButton4.Text = "Stop Alarm";
            this.metroToolTip.SetToolTip(this.metroButton4, "Button Tooltip");
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton3.Location = new System.Drawing.Point(439, 238);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(103, 37);
            this.metroButton3.TabIndex = 20;
            this.metroButton3.Text = "Alarm Now";
            this.metroToolTip.SetToolTip(this.metroButton3, "Button Tooltip");
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // stop_button_2
            // 
            this.stop_button_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stop_button_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stop_button_2.Location = new System.Drawing.Point(109, 363);
            this.stop_button_2.Name = "stop_button_2";
            this.stop_button_2.Size = new System.Drawing.Size(103, 37);
            this.stop_button_2.TabIndex = 19;
            this.stop_button_2.Text = "Stop ";
            this.metroToolTip.SetToolTip(this.stop_button_2, "Button Tooltip");
            this.stop_button_2.UseSelectable = true;
            this.stop_button_2.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // pick_video_button
            // 
            this.pick_video_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pick_video_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pick_video_button.Location = new System.Drawing.Point(320, 363);
            this.pick_video_button.Name = "pick_video_button";
            this.pick_video_button.Size = new System.Drawing.Size(103, 37);
            this.pick_video_button.TabIndex = 15;
            this.pick_video_button.Text = "Pick Video";
            this.metroToolTip.SetToolTip(this.pick_video_button, "Button Tooltip");
            this.pick_video_button.UseSelectable = true;
            this.pick_video_button.Click += new System.EventHandler(this.pick_video_button_Click);
            // 
            // show_detected_faces2
            // 
            this.show_detected_faces2.AutoSize = true;
            this.show_detected_faces2.Location = new System.Drawing.Point(439, 16);
            this.show_detected_faces2.Name = "show_detected_faces2";
            this.show_detected_faces2.Size = new System.Drawing.Size(134, 15);
            this.show_detected_faces2.TabIndex = 14;
            this.show_detected_faces2.Text = "Show Detected Faces";
            this.metroToolTip.SetToolTip(this.show_detected_faces2, "Checkbox Tooltip");
            this.show_detected_faces2.UseSelectable = true;
            this.show_detected_faces2.CheckedChanged += new System.EventHandler(this.show_detected_faces2_CheckedChanged);
            // 
            // pause_button
            // 
            this.pause_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pause_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pause_button.Location = new System.Drawing.Point(0, 363);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(103, 37);
            this.pause_button.TabIndex = 11;
            this.pause_button.Text = "Pause ";
            this.metroToolTip.SetToolTip(this.pause_button, "Button Tooltip");
            this.pause_button.UseSelectable = true;
            this.pause_button.Click += new System.EventHandler(this.pause_button_Click);
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.listBox1);
            this.metroTabPage3.Controls.Add(this.label13);
            this.metroTabPage3.Controls.Add(this.label12);
            this.metroTabPage3.Controls.Add(this.label11);
            this.metroTabPage3.Controls.Add(this.label10);
            this.metroTabPage3.Controls.Add(this.label9);
            this.metroTabPage3.Controls.Add(this.label8);
            this.metroTabPage3.Controls.Add(this.label6);
            this.metroTabPage3.Controls.Add(this.label7);
            this.metroTabPage3.Controls.Add(this.colorSlider1);
            this.metroTabPage3.Controls.Add(this.metroButton2);
            this.metroTabPage3.Controls.Add(this.metroButton1);
            this.metroTabPage3.Controls.Add(this.imageBox4);
            this.metroTabPage3.Controls.Add(this.metroLabel8);
            this.metroTabPage3.Controls.Add(this.metroLabel7);
            this.metroTabPage3.Controls.Add(this.metroLabel6);
            this.metroTabPage3.Controls.Add(this.metroLabel5);
            this.metroTabPage3.Controls.Add(this.metroLabel4);
            this.metroTabPage3.Controls.Add(this.metroLabel1);
            this.metroTabPage3.Controls.Add(this.perpetrator_box);
            this.metroTabPage3.Controls.Add(this.metroLabel3);
            this.metroTabPage3.Controls.Add(this.metroLabel2);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Padding = new System.Windows.Forms.Padding(25);
            this.metroTabPage3.Size = new System.Drawing.Size(918, 400);
            this.metroTabPage3.TabIndex = 3;
            this.metroTabPage3.Text = "Most Wanted";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            this.metroTabPage3.Visible = false;
            // 
            // listBox1
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.listBox1, true);
            this.listBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Thief 1",
            "Thief 2",
            "Thief 3",
            "Thief 4"});
            this.listBox1.Location = new System.Drawing.Point(504, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(171, 355);
            this.listBox1.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(429, 329);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "C:\\Users\\Videos\\etc";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(428, 304);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Yes";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(428, 279);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "You";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(428, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Theft";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(428, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Not a Student";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(428, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Mun G";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 304);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "00:00:00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "00:00:00";
            // 
            // colorSlider1
            // 
            this.colorSlider1.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider1.BarInnerColor = System.Drawing.Color.Silver;
            this.colorSlider1.BarOuterColor = System.Drawing.Color.Gainsboro;
            this.colorSlider1.BarPenColor = System.Drawing.Color.LimeGreen;
            this.colorSlider1.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider1.ElapsedOuterColor = System.Drawing.Color.LawnGreen;
            this.colorSlider1.LargeChange = ((uint)(5u));
            this.colorSlider1.Location = new System.Drawing.Point(60, 298);
            this.colorSlider1.Name = "colorSlider1";
            this.colorSlider1.Size = new System.Drawing.Size(181, 25);
            this.colorSlider1.SmallChange = ((uint)(1u));
            this.colorSlider1.TabIndex = 23;
            this.colorSlider1.Text = "/";
            this.colorSlider1.ThumbInnerColor = System.Drawing.Color.DarkGray;
            this.colorSlider1.ThumbOuterColor = System.Drawing.Color.Gray;
            this.colorSlider1.ThumbPenColor = System.Drawing.Color.DimGray;
            this.colorSlider1.ThumbRoundRectSize = new System.Drawing.Size(2, 2);
            this.colorSlider1.ThumbSize = 10;
            this.colorSlider1.Value = 0;
            // 
            // metroButton2
            // 
            this.metroButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton2.Location = new System.Drawing.Point(142, 331);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(90, 44);
            this.metroButton2.TabIndex = 19;
            this.metroButton2.Text = "Stop";
            this.metroButton2.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.Location = new System.Drawing.Point(0, 331);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(123, 44);
            this.metroButton1.TabIndex = 18;
            this.metroButton1.Text = "Play Crime Footage";
            this.metroButton1.UseSelectable = true;
            // 
            // imageBox4
            // 
            this.imageBox4.BackColor = System.Drawing.SystemColors.ControlText;
            this.imageBox4.Location = new System.Drawing.Point(3, 3);
            this.imageBox4.Name = "imageBox4";
            this.imageBox4.Size = new System.Drawing.Size(303, 284);
            this.imageBox4.TabIndex = 12;
            this.imageBox4.TabStop = false;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(312, 323);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(3);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(111, 19);
            this.metroLabel8.TabIndex = 11;
            this.metroLabel8.Text = "Footage of crime";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(312, 298);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(3);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(117, 19);
            this.metroLabel7.TabIndex = 10;
            this.metroLabel7.Text = "Still On the Loose?";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(312, 273);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(3);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(101, 19);
            this.metroLabel6.TabIndex = 9;
            this.metroLabel6.Text = "Victim of Crime";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(312, 248);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(3);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(45, 19);
            this.metroLabel5.TabIndex = 8;
            this.metroLabel5.Text = "Crime";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(312, 223);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(3);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(91, 19);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "Student Status";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(312, 198);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(3);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(45, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Name";
            // 
            // perpetrator_box
            // 
            this.perpetrator_box.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("perpetrator_box.BackgroundImage")));
            this.perpetrator_box.Image = ((System.Drawing.Image)(resources.GetObject("perpetrator_box.Image")));
            this.perpetrator_box.Location = new System.Drawing.Point(312, 3);
            this.perpetrator_box.Name = "perpetrator_box";
            this.perpetrator_box.Size = new System.Drawing.Size(186, 169);
            this.perpetrator_box.TabIndex = 5;
            this.perpetrator_box.TabStop = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(534, 3);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(3);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(117, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Pick A Perpetrator";
            this.metroToolTip.SetToolTip(this.metroLabel3, "Label Tooltip");
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(382, 174);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(3);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(47, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Details";
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.metroButton5);
            this.metroTabPage4.Controls.Add(this.metroComboBox2);
            this.metroTabPage4.Controls.Add(this.metroToggle3);
            this.metroTabPage4.Controls.Add(this.metroToggle2);
            this.metroTabPage4.Controls.Add(this.metroRadioButton3);
            this.metroTabPage4.Controls.Add(this.metroRadioButton2);
            this.metroTabPage4.Controls.Add(this.metroCheckBox3);
            this.metroTabPage4.Controls.Add(this.metroCheckBox2);
            this.metroTabPage4.Controls.Add(this.metroLabel19);
            this.metroTabPage4.Controls.Add(this.metroLabel18);
            this.metroTabPage4.Controls.Add(this.metroLabel17);
            this.metroTabPage4.Controls.Add(this.metroLabel16);
            this.metroTabPage4.Controls.Add(this.metroComboBox1);
            this.metroTabPage4.Controls.Add(this.metroRadioButton1);
            this.metroTabPage4.Controls.Add(this.metroToggle1);
            this.metroTabPage4.Controls.Add(this.metroCheckBox1);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Padding = new System.Windows.Forms.Padding(25);
            this.metroTabPage4.Size = new System.Drawing.Size(918, 400);
            this.metroTabPage4.TabIndex = 1;
            this.metroTabPage4.Text = "Help";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            this.metroTabPage4.Visible = false;
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(404, 47);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(123, 29);
            this.metroButton5.TabIndex = 17;
            this.metroButton5.Text = "&Show Context Menu";
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroComboBox2
            // 
            this.metroComboBox2.Enabled = false;
            this.metroComboBox2.FormattingEnabled = true;
            this.metroComboBox2.ItemHeight = 23;
            this.metroComboBox2.Items.AddRange(new object[] {
            "Normal Combobox"});
            this.metroComboBox2.Location = new System.Drawing.Point(181, 82);
            this.metroComboBox2.Name = "metroComboBox2";
            this.metroComboBox2.Size = new System.Drawing.Size(197, 29);
            this.metroComboBox2.TabIndex = 16;
            this.metroComboBox2.UseSelectable = true;
            // 
            // metroToggle3
            // 
            this.metroToggle3.AutoSize = true;
            this.metroToggle3.DisplayStatus = false;
            this.metroToggle3.Enabled = false;
            this.metroToggle3.Location = new System.Drawing.Point(211, 206);
            this.metroToggle3.Name = "metroToggle3";
            this.metroToggle3.Size = new System.Drawing.Size(50, 17);
            this.metroToggle3.TabIndex = 15;
            this.metroToggle3.Text = "Off";
            this.metroToggle3.UseSelectable = true;
            // 
            // metroToggle2
            // 
            this.metroToggle2.AutoSize = true;
            this.metroToggle2.DisplayStatus = false;
            this.metroToggle2.Location = new System.Drawing.Point(211, 183);
            this.metroToggle2.Name = "metroToggle2";
            this.metroToggle2.Size = new System.Drawing.Size(50, 17);
            this.metroToggle2.TabIndex = 14;
            this.metroToggle2.Text = "Off";
            this.metroToggle2.UseSelectable = true;
            this.metroToggle2.UseStyleColors = true;
            // 
            // metroRadioButton3
            // 
            this.metroRadioButton3.AutoSize = true;
            this.metroRadioButton3.Enabled = false;
            this.metroRadioButton3.Location = new System.Drawing.Point(18, 202);
            this.metroRadioButton3.Name = "metroRadioButton3";
            this.metroRadioButton3.Size = new System.Drawing.Size(137, 15);
            this.metroRadioButton3.TabIndex = 13;
            this.metroRadioButton3.TabStop = true;
            this.metroRadioButton3.Text = "Disabled Radiobutton";
            this.metroRadioButton3.UseSelectable = true;
            // 
            // metroRadioButton2
            // 
            this.metroRadioButton2.AutoSize = true;
            this.metroRadioButton2.Location = new System.Drawing.Point(18, 181);
            this.metroRadioButton2.Name = "metroRadioButton2";
            this.metroRadioButton2.Size = new System.Drawing.Size(124, 15);
            this.metroRadioButton2.TabIndex = 12;
            this.metroRadioButton2.TabStop = true;
            this.metroRadioButton2.Text = "Styled Radiobutton";
            this.metroRadioButton2.UseSelectable = true;
            this.metroRadioButton2.UseStyleColors = true;
            // 
            // metroCheckBox3
            // 
            this.metroCheckBox3.AutoSize = true;
            this.metroCheckBox3.Enabled = false;
            this.metroCheckBox3.Location = new System.Drawing.Point(18, 95);
            this.metroCheckBox3.Name = "metroCheckBox3";
            this.metroCheckBox3.Size = new System.Drawing.Size(123, 15);
            this.metroCheckBox3.TabIndex = 11;
            this.metroCheckBox3.Text = "Disabled Checkbox";
            this.metroCheckBox3.UseSelectable = true;
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.Location = new System.Drawing.Point(18, 74);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(110, 15);
            this.metroCheckBox2.TabIndex = 10;
            this.metroCheckBox2.Text = "Styled Checkbox";
            this.metroCheckBox2.UseSelectable = true;
            this.metroCheckBox2.UseStyleColors = true;
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.Location = new System.Drawing.Point(181, 133);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(86, 19);
            this.metroLabel19.TabIndex = 9;
            this.metroLabel19.Text = "MetroToggle";
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.Location = new System.Drawing.Point(18, 133);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(117, 19);
            this.metroLabel18.TabIndex = 8;
            this.metroLabel18.Text = "MetroRadioButton";
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(181, 25);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(112, 19);
            this.metroLabel17.TabIndex = 7;
            this.metroLabel17.Text = "MetroComboBox";
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.Location = new System.Drawing.Point(18, 25);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(102, 19);
            this.metroLabel16.TabIndex = 6;
            this.metroLabel16.Text = "MetroCheckBox";
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Items.AddRange(new object[] {
            "Normal Combobox 1",
            "Normal Combobox 2",
            "Normal Combobox 3",
            "Normal Combobox 4"});
            this.metroComboBox1.Location = new System.Drawing.Point(181, 47);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.PromptText = "Prompted ComboBox";
            this.metroComboBox1.Size = new System.Drawing.Size(197, 29);
            this.metroComboBox1.TabIndex = 5;
            this.metroToolTip.SetToolTip(this.metroComboBox1, "ComboBox Tooltip");
            this.metroComboBox1.UseSelectable = true;
            // 
            // metroRadioButton1
            // 
            this.metroRadioButton1.AutoSize = true;
            this.metroRadioButton1.Location = new System.Drawing.Point(18, 160);
            this.metroRadioButton1.Name = "metroRadioButton1";
            this.metroRadioButton1.Size = new System.Drawing.Size(132, 15);
            this.metroRadioButton1.TabIndex = 4;
            this.metroRadioButton1.TabStop = true;
            this.metroRadioButton1.Text = "Normal Radiobutton";
            this.metroToolTip.SetToolTip(this.metroRadioButton1, "RadioButton Tooltip");
            this.metroRadioButton1.UseSelectable = true;
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Location = new System.Drawing.Point(181, 160);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 17);
            this.metroToggle1.TabIndex = 3;
            this.metroToggle1.Text = "Off";
            this.metroToolTip.SetToolTip(this.metroToggle1, "Toggle Tooltip");
            this.metroToggle1.UseSelectable = true;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(18, 53);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(118, 15);
            this.metroCheckBox1.TabIndex = 2;
            this.metroCheckBox1.Text = "Normal Checkbox";
            this.metroToolTip.SetToolTip(this.metroCheckBox1, "Checkbox Tooltip");
            this.metroCheckBox1.UseSelectable = true;
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.Controls.Add(this.userTable);
            this.metroTabPage5.Controls.Add(this.metroButton12);
            this.metroTabPage5.Controls.Add(this.metroButton11);
            this.metroTabPage5.Controls.Add(this.metroButton10);
            this.metroTabPage5.Controls.Add(this.metroButton9);
            this.metroTabPage5.Controls.Add(this.metroButton8);
            this.metroTabPage5.Controls.Add(this.metroButton7);
            this.metroTabPage5.Controls.Add(this.metroButton6);
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.HorizontalScrollbarSize = 10;
            this.metroTabPage5.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Size = new System.Drawing.Size(918, 400);
            this.metroTabPage5.TabIndex = 5;
            this.metroTabPage5.Text = "Settings";
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            this.metroTabPage5.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.VerticalScrollbarSize = 10;
            // 
            // userTable
            // 
            this.userTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userTable.Location = new System.Drawing.Point(3, 87);
            this.userTable.Name = "userTable";
            this.userTable.Size = new System.Drawing.Size(912, 310);
            this.userTable.TabIndex = 9;
            // 
            // metroButton12
            // 
            this.metroButton12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton12.Location = new System.Drawing.Point(756, 13);
            this.metroButton12.Name = "metroButton12";
            this.metroButton12.Size = new System.Drawing.Size(140, 31);
            this.metroButton12.TabIndex = 8;
            this.metroButton12.Text = "Default";
            this.metroButton12.UseSelectable = true;
            this.metroButton12.Click += new System.EventHandler(this.metroButton12_Click);
            // 
            // metroButton11
            // 
            this.metroButton11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton11.Location = new System.Drawing.Point(318, 12);
            this.metroButton11.Name = "metroButton11";
            this.metroButton11.Size = new System.Drawing.Size(140, 31);
            this.metroButton11.TabIndex = 7;
            this.metroButton11.Text = "Edit User";
            this.metroButton11.UseSelectable = true;
            this.metroButton11.Click += new System.EventHandler(this.metroButton11_Click);
            // 
            // metroButton10
            // 
            this.metroButton10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton10.Location = new System.Drawing.Point(26, 50);
            this.metroButton10.Name = "metroButton10";
            this.metroButton10.Size = new System.Drawing.Size(140, 31);
            this.metroButton10.TabIndex = 6;
            this.metroButton10.Text = "Ok Cancel";
            this.metroButton10.UseSelectable = true;
            this.metroButton10.Click += new System.EventHandler(this.metroButton10_Click);
            // 
            // metroButton9
            // 
            this.metroButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton9.Location = new System.Drawing.Point(464, 12);
            this.metroButton9.Name = "metroButton9";
            this.metroButton9.Size = new System.Drawing.Size(140, 31);
            this.metroButton9.TabIndex = 5;
            this.metroButton9.Text = "Delete User";
            this.metroButton9.UseSelectable = true;
            this.metroButton9.Click += new System.EventHandler(this.metroButton9_Click);
            // 
            // metroButton8
            // 
            this.metroButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton8.Location = new System.Drawing.Point(610, 13);
            this.metroButton8.Name = "metroButton8";
            this.metroButton8.Size = new System.Drawing.Size(140, 31);
            this.metroButton8.TabIndex = 4;
            this.metroButton8.Text = "Add Student";
            this.metroButton8.UseSelectable = true;
            this.metroButton8.Click += new System.EventHandler(this.metroButton8_Click);
            // 
            // metroButton7
            // 
            this.metroButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton7.Location = new System.Drawing.Point(172, 12);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.Size = new System.Drawing.Size(140, 31);
            this.metroButton7.TabIndex = 3;
            this.metroButton7.Text = "Add User";
            this.metroButton7.UseSelectable = true;
            this.metroButton7.Click += new System.EventHandler(this.metroButton7_Click);
            // 
            // metroButton6
            // 
            this.metroButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton6.Location = new System.Drawing.Point(12, 13);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(154, 31);
            this.metroButton6.TabIndex = 2;
            this.metroButton6.Text = "Change Login Credentials";
            this.metroButton6.UseSelectable = true;
            this.metroButton6.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detected Faces";
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToolTip
            // 
            this.metroToolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip.StyleManager = null;
            this.metroToolTip.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.maintenanceToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(144, 120);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.maintenanceToolStripMenuItem.Text = "&Maintenance";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // icons_list
            // 
            this.icons_list.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons_list.ImageStream")));
            this.icons_list.TransparentColor = System.Drawing.Color.Transparent;
            this.icons_list.Images.SetKeyName(0, "about-us.png");
            this.icons_list.Images.SetKeyName(1, "cam4.png");
            this.icons_list.Images.SetKeyName(2, "help.png");
            this.icons_list.Images.SetKeyName(3, "replay1.png");
            this.icons_list.Images.SetKeyName(4, "settings.png");
            this.icons_list.Images.SetKeyName(5, "thief1.png");
            this.icons_list.Images.SetKeyName(6, "wanted1.png");
            // 
            // MainWindow
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::MetroFramework.Demo.Properties.Resources.GitHub_Mark;
            this.BackImagePadding = new System.Windows.Forms.Padding(210, 10, 0, 0);
            this.BackMaxSize = 50;
            this.ClientSize = new System.Drawing.Size(966, 525);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "MainWindow";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.StyleManager = this.metroStyleManager;
            this.Text = "Nkujukira";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.review_footage_image_box)).EndInit();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perpetrator_box)).EndInit();
            this.metroTabPage4.ResumeLayout(false);
            this.metroTabPage4.PerformLayout();
            this.metroTabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion


        #region Controls
        private Controls.MetroTabControl metroTabControl1;
        private Components.MetroStyleManager metroStyleManager;
        private Controls.MetroTabPage metroTabPage1;
        private Components.MetroToolTip metroToolTip;
        private Controls.MetroButton turn_on_button;
        private Controls.MetroTabPage metroTabPage4;
        private Controls.MetroRadioButton metroRadioButton1;
        private Controls.MetroToggle metroToggle1;
        private Controls.MetroCheckBox metroCheckBox1;
        private Controls.MetroTabPage metroTabPage3;
        private Controls.MetroLabel metroLabel3;
        private Controls.MetroLabel metroLabel2;
        private Controls.MetroComboBox metroComboBox1;
        private Controls.MetroLabel metroLabel19;
        private Controls.MetroLabel metroLabel18;
        private Controls.MetroLabel metroLabel17;
        private Controls.MetroLabel metroLabel16;
        private Controls.MetroToggle metroToggle3;
        private Controls.MetroToggle metroToggle2;
        private Controls.MetroRadioButton metroRadioButton3;
        private Controls.MetroRadioButton metroRadioButton2;
        private Controls.MetroCheckBox metroCheckBox3;
        private Controls.MetroCheckBox metroCheckBox2;
        private Controls.MetroComboBox metroComboBox2;
        private Components.MetroStyleExtender metroStyleExtender;
        private Controls.MetroButton metroButton5;
        private Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private Controls.MetroTabPage metroTabPage5;
        private Controls.MetroButton metroButton9;
        private Controls.MetroButton metroButton8;
        private Controls.MetroButton metroButton7;
        private Controls.MetroButton metroButton6;
        private Controls.MetroButton metroButton11;
        private Controls.MetroButton metroButton10;
        private Controls.MetroButton metroButton12;
        private Controls.MetroCheckBox show_detected_faces;
        private Controls.MetroButton stop_button_1;
        public static Emgu.CV.UI.ImageBox live_stream_imageBox;
        #endregion
        private Controls.MetroTabPage metroTabPage2;
        private Controls.MetroButton stop_button_2;
        private Controls.MetroButton pick_video_button;
        private Controls.MetroCheckBox show_detected_faces2;
        private Controls.MetroButton pause_button;
        public static MB.Controls.ColorSlider slider_review_footage;
        public static System.Windows.Forms.Label video_total_time_label;
        public static System.Windows.Forms.Label elapsed_time_label;
        private System.Windows.Forms.ImageList icons_list;
        public static System.Windows.Forms.Panel detected_faces_panel;
        public static Emgu.CV.UI.ImageBox imageBox3;
        public static Emgu.CV.UI.ImageBox imageBox2;
        public static Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox perpetrator_box;
        private Controls.MetroLabel metroLabel4;
        private Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private MB.Controls.ColorSlider colorSlider1;
        private Controls.MetroButton metroButton2;
        private Controls.MetroButton metroButton1;
        private Emgu.CV.UI.ImageBox imageBox4;
        private Controls.MetroLabel metroLabel8;
        private Controls.MetroLabel metroLabel7;
        private Controls.MetroLabel metroLabel6;
        private Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Controls.MetroButton metroButton3;
        private Controls.MetroButton metroButton4;
        private ImageBox review_footage_image_box;
        private System.Windows.Forms.Panel panel_for_detected_faces;
        private MB.Controls.ColorSlider review_footage_color_slider;
        private System.Windows.Forms.Label total_time_label;
        private System.Windows.Forms.Label time_elapsed_label;
        private System.Windows.Forms.DataGridView userTable;
     




    }
}

