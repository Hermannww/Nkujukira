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
            this.panel2 = new System.Windows.Forms.Panel();
            this.live_stream_recognition_panel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.turn_on_button = new MetroFramework.Controls.MetroButton();
            this.imageBox7 = new Emgu.CV.UI.ImageBox();
            this.imageBox6 = new Emgu.CV.UI.ImageBox();
            this.imageBox5 = new Emgu.CV.UI.ImageBox();
            this.imageBox4 = new Emgu.CV.UI.ImageBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.total_time_label = new System.Windows.Forms.Label();
            this.time_elapsed_label = new System.Windows.Forms.Label();
            this.review_footage_color_slider = new MB.Controls.ColorSlider();
            this.panel_for_detected_faces = new System.Windows.Forms.Panel();
            this.label_face_recognition_status = new System.Windows.Forms.Label();
            this.label_separator = new System.Windows.Forms.Label();
            this.review_footage_image_box = new Emgu.CV.UI.ImageBox();
            this.stop_button_2 = new MetroFramework.Controls.MetroButton();
            this.pick_video_button = new MetroFramework.Controls.MetroButton();
            this.show_detected_faces2 = new MetroFramework.Controls.MetroCheckBox();
            this.pause_button = new MetroFramework.Controls.MetroButton();
            this.metroTabPage11 = new MetroFramework.Controls.MetroTabPage();
            this.metroTile9 = new MetroFramework.Controls.MetroTile();
            this.metroTile8 = new MetroFramework.Controls.MetroTile();
            this.metroTile7 = new MetroFramework.Controls.MetroTile();
            this.metroTile6 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroTile5 = new MetroFramework.Controls.MetroTile();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.tile1 = new MetroFramework.Controls.MetroTile();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroToolTip = new MetroFramework.Components.MetroToolTip();
            this.metroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.linkLabel_logout = new System.Windows.Forms.LinkLabel();
            this.icons_list = new System.Windows.Forms.ImageList(this.components);
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.live_stream_recognition_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            this.panel_for_detected_faces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.review_footage_image_box)).BeginInit();
            this.metroTabPage11.SuspendLayout();
            this.metroContextMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage11);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Multiline = true;
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(926, 572);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            this.metroTabControl1.SelectedIndexChanged += new System.EventHandler(this.metroTabControl1_SelectedIndexChanged);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.AutoScroll = true;
            this.metroTabPage1.Controls.Add(this.panel2);
            this.metroTabPage1.Controls.Add(this.panel1);
            this.metroTabPage1.HorizontalScrollbar = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Padding = new System.Windows.Forms.Padding(25);
            this.metroTabPage1.Size = new System.Drawing.Size(918, 527);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Live Stream";
            this.metroTabPage1.VerticalScrollbar = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // panel2
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.panel2, true);
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.live_stream_recognition_panel);
            this.panel2.Location = new System.Drawing.Point(537, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 519);
            this.panel2.TabIndex = 12;
            // 
            // live_stream_recognition_panel
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.live_stream_recognition_panel, true);
            this.live_stream_recognition_panel.AutoScroll = true;
            this.live_stream_recognition_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.live_stream_recognition_panel.Controls.Add(this.label8);
            this.live_stream_recognition_panel.Controls.Add(this.label6);
            this.live_stream_recognition_panel.Location = new System.Drawing.Point(13, 6);
            this.live_stream_recognition_panel.Name = "live_stream_recognition_panel";
            this.live_stream_recognition_panel.Size = new System.Drawing.Size(351, 499);
            this.live_stream_recognition_panel.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(-2, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(335, 2);
            this.label8.TabIndex = 3;
            // 
            // label6
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label6, true);
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(68, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "FACE RECOGNITION PROGRESS";
            // 
            // panel1
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.panel1, true);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.turn_on_button);
            this.panel1.Controls.Add(this.imageBox7);
            this.panel1.Controls.Add(this.imageBox6);
            this.panel1.Controls.Add(this.imageBox5);
            this.panel1.Controls.Add(this.imageBox4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 523);
            this.panel1.TabIndex = 11;
            // 
            // turn_on_button
            // 
            this.turn_on_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.turn_on_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.turn_on_button.Location = new System.Drawing.Point(180, 474);
            this.turn_on_button.Name = "turn_on_button";
            this.turn_on_button.Size = new System.Drawing.Size(178, 44);
            this.turn_on_button.TabIndex = 33;
            this.turn_on_button.Text = "Turn On";
            this.metroToolTip.SetToolTip(this.turn_on_button, "Button Tooltip");
            this.turn_on_button.UseSelectable = true;
            this.turn_on_button.Click += new System.EventHandler(this.turn_on_button_Click);
            // 
            // imageBox7
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.imageBox7, true);
            this.imageBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageBox7.Location = new System.Drawing.Point(262, 260);
            this.imageBox7.Name = "imageBox7";
            this.imageBox7.Size = new System.Drawing.Size(230, 208);
            this.imageBox7.TabIndex = 30;
            this.imageBox7.TabStop = false;
            // 
            // imageBox6
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.imageBox6, true);
            this.imageBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageBox6.Location = new System.Drawing.Point(12, 260);
            this.imageBox6.Name = "imageBox6";
            this.imageBox6.Size = new System.Drawing.Size(230, 208);
            this.imageBox6.TabIndex = 29;
            this.imageBox6.TabStop = false;
            // 
            // imageBox5
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.imageBox5, true);
            this.imageBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageBox5.Location = new System.Drawing.Point(262, 17);
            this.imageBox5.Name = "imageBox5";
            this.imageBox5.Size = new System.Drawing.Size(230, 219);
            this.imageBox5.TabIndex = 28;
            this.imageBox5.TabStop = false;
            // 
            // imageBox4
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.imageBox4, true);
            this.imageBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageBox4.Location = new System.Drawing.Point(12, 17);
            this.imageBox4.Name = "imageBox4";
            this.imageBox4.Size = new System.Drawing.Size(230, 219);
            this.imageBox4.TabIndex = 21;
            this.imageBox4.TabStop = false;
            this.imageBox4.Click += new System.EventHandler(this.imageBox4_Click);
            this.imageBox4.MouseHover += new System.EventHandler(this.imageBox4_MouseHover);
            // 
            // label5
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label5, true);
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(354, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Camera 4";
            // 
            // label4
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label4, true);
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Camera 2";
            // 
            // label3
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label3, true);
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Camera 3";
            // 
            // label2
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label2, true);
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Camera 1";
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.AutoScroll = true;
            this.metroTabPage2.Controls.Add(this.total_time_label);
            this.metroTabPage2.Controls.Add(this.time_elapsed_label);
            this.metroTabPage2.Controls.Add(this.review_footage_color_slider);
            this.metroTabPage2.Controls.Add(this.panel_for_detected_faces);
            this.metroTabPage2.Controls.Add(this.review_footage_image_box);
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
            this.metroTabPage2.Size = new System.Drawing.Size(918, 527);
            this.metroTabPage2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTabPage2.TabIndex = 2;
            this.metroTabPage2.Text = "Review Footage";
            this.metroTabPage2.VerticalScrollbar = true;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            this.metroTabPage2.Visible = false;
            this.metroTabPage2.Click += new System.EventHandler(this.metroTabPage2_Click);
            // 
            // total_time_label
            // 
            this.total_time_label.AutoSize = true;
            this.total_time_label.Location = new System.Drawing.Point(374, 415);
            this.total_time_label.Name = "total_time_label";
            this.total_time_label.Size = new System.Drawing.Size(49, 13);
            this.total_time_label.TabIndex = 25;
            this.total_time_label.Text = "00:00:00";
            // 
            // time_elapsed_label
            // 
            this.time_elapsed_label.AutoSize = true;
            this.time_elapsed_label.Location = new System.Drawing.Point(4, 413);
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
            this.review_footage_color_slider.ElapsedInnerColor = System.Drawing.Color.Turquoise;
            this.review_footage_color_slider.ElapsedOuterColor = System.Drawing.Color.Teal;
            this.review_footage_color_slider.LargeChange = ((uint)(5u));
            this.review_footage_color_slider.Location = new System.Drawing.Point(7, 389);
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
            this.panel_for_detected_faces.AutoScroll = true;
            this.panel_for_detected_faces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_for_detected_faces.Controls.Add(this.label_face_recognition_status);
            this.panel_for_detected_faces.Controls.Add(this.label_separator);
            this.panel_for_detected_faces.Location = new System.Drawing.Point(439, 3);
            this.panel_for_detected_faces.Name = "panel_for_detected_faces";
            this.panel_for_detected_faces.Size = new System.Drawing.Size(372, 520);
            this.panel_for_detected_faces.TabIndex = 22;
            this.panel_for_detected_faces.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_for_detected_faces_Paint);
            // 
            // label_face_recognition_status
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label_face_recognition_status, true);
            this.label_face_recognition_status.AutoSize = true;
            this.label_face_recognition_status.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_face_recognition_status.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_face_recognition_status.Location = new System.Drawing.Point(74, 11);
            this.label_face_recognition_status.Name = "label_face_recognition_status";
            this.label_face_recognition_status.Size = new System.Drawing.Size(205, 19);
            this.label_face_recognition_status.TabIndex = 3;
            this.label_face_recognition_status.Text = "FACE COMPARISON ONGOING";
            // 
            // label_separator
            // 
            this.label_separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_separator.Location = new System.Drawing.Point(19, 39);
            this.label_separator.Name = "label_separator";
            this.label_separator.Size = new System.Drawing.Size(335, 2);
            this.label_separator.TabIndex = 2;
            // 
            // review_footage_image_box
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.review_footage_image_box, true);
            this.review_footage_image_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.review_footage_image_box.Cursor = System.Windows.Forms.Cursors.Hand;
            this.review_footage_image_box.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.review_footage_image_box.Location = new System.Drawing.Point(39, 3);
            this.review_footage_image_box.Name = "review_footage_image_box";
            this.review_footage_image_box.Size = new System.Drawing.Size(372, 372);
            this.review_footage_image_box.TabIndex = 2;
            this.review_footage_image_box.TabStop = false;
            this.review_footage_image_box.Click += new System.EventHandler(this.review_footage_image_box_Click);
            // 
            // stop_button_2
            // 
            this.stop_button_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stop_button_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stop_button_2.Location = new System.Drawing.Point(116, 459);
            this.stop_button_2.Name = "stop_button_2";
            this.stop_button_2.Size = new System.Drawing.Size(103, 64);
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
            this.pick_video_button.Location = new System.Drawing.Point(300, 459);
            this.pick_video_button.Name = "pick_video_button";
            this.pick_video_button.Size = new System.Drawing.Size(123, 64);
            this.pick_video_button.TabIndex = 15;
            this.pick_video_button.Text = "Pick Video";
            this.metroToolTip.SetToolTip(this.pick_video_button, "Button Tooltip");
            this.pick_video_button.UseSelectable = true;
            this.pick_video_button.Click += new System.EventHandler(this.pick_video_button_Click);
            // 
            // show_detected_faces2
            // 
            this.show_detected_faces2.AutoSize = true;
            this.show_detected_faces2.Location = new System.Drawing.Point(7, 429);
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
            this.pause_button.Location = new System.Drawing.Point(7, 459);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(103, 64);
            this.pause_button.TabIndex = 11;
            this.pause_button.Text = "Pause ";
            this.metroToolTip.SetToolTip(this.pause_button, "Button Tooltip");
            this.pause_button.UseSelectable = true;
            this.pause_button.Click += new System.EventHandler(this.pause_button_Click);
            // 
            // metroTabPage11
            // 
            this.metroTabPage11.BackColor = System.Drawing.Color.Silver;
            this.metroTabPage11.Controls.Add(this.metroTile9);
            this.metroTabPage11.Controls.Add(this.metroTile8);
            this.metroTabPage11.Controls.Add(this.metroTile7);
            this.metroTabPage11.Controls.Add(this.metroTile6);
            this.metroTabPage11.Controls.Add(this.metroTile3);
            this.metroTabPage11.Controls.Add(this.metroTile5);
            this.metroTabPage11.Controls.Add(this.metroTile4);
            this.metroTabPage11.Controls.Add(this.metroTile2);
            this.metroTabPage11.Controls.Add(this.metroTile1);
            this.metroTabPage11.Controls.Add(this.tile1);
            this.metroTabPage11.HorizontalScrollbarBarColor = true;
            this.metroTabPage11.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage11.HorizontalScrollbarSize = 10;
            this.metroTabPage11.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage11.Name = "metroTabPage11";
            this.metroTabPage11.Size = new System.Drawing.Size(918, 527);
            this.metroTabPage11.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroTabPage11.TabIndex = 6;
            this.metroTabPage11.Text = "Settings";
            this.metroTabPage11.VerticalScrollbarBarColor = true;
            this.metroTabPage11.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage11.VerticalScrollbarSize = 10;
            // 
            // metroTile9
            // 
            this.metroTile9.ActiveControl = null;
            this.metroTile9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile9.Location = new System.Drawing.Point(105, 22);
            this.metroTile9.Name = "metroTile9";
            this.metroTile9.Size = new System.Drawing.Size(231, 108);
            this.metroTile9.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile9.TabIndex = 12;
            this.metroTile9.Text = "Add New User";
            this.metroTile9.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile9.UseSelectable = true;
            this.metroTile9.UseTileImage = true;
            this.metroTile9.Click += new System.EventHandler(this.metroTile9_Click);
            // 
            // metroTile8
            // 
            this.metroTile8.ActiveControl = null;
            this.metroTile8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile8.Location = new System.Drawing.Point(568, 252);
            this.metroTile8.Name = "metroTile8";
            this.metroTile8.Size = new System.Drawing.Size(225, 108);
            this.metroTile8.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroTile8.TabIndex = 11;
            this.metroTile8.Text = "About Us";
            this.metroTile8.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile8.TileImage")));
            this.metroTile8.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile8.UseSelectable = true;
            this.metroTile8.UseTileImage = true;
            // 
            // metroTile7
            // 
            this.metroTile7.ActiveControl = null;
            this.metroTile7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile7.Location = new System.Drawing.Point(342, 251);
            this.metroTile7.Name = "metroTile7";
            this.metroTile7.Size = new System.Drawing.Size(220, 108);
            this.metroTile7.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroTile7.TabIndex = 10;
            this.metroTile7.Text = "Most Wanted List";
            this.metroTile7.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile7.TileImage")));
            this.metroTile7.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile7.UseSelectable = true;
            this.metroTile7.UseTileImage = true;
            this.metroTile7.Click += new System.EventHandler(this.metroTile7_Click);
            // 
            // metroTile6
            // 
            this.metroTile6.ActiveControl = null;
            this.metroTile6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile6.Location = new System.Drawing.Point(105, 251);
            this.metroTile6.Name = "metroTile6";
            this.metroTile6.Size = new System.Drawing.Size(231, 108);
            this.metroTile6.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTile6.TabIndex = 9;
            this.metroTile6.Text = "Help";
            this.metroTile6.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile6.TileImage")));
            this.metroTile6.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile6.UseSelectable = true;
            this.metroTile6.UseTileImage = true;
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile3.Location = new System.Drawing.Point(568, 137);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(225, 109);
            this.metroTile3.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTile3.TabIndex = 8;
            this.metroTile3.Text = "History";
            this.metroTile3.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile3.TileImage")));
            this.metroTile3.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile3.UseSelectable = true;
            this.metroTile3.UseTileImage = true;
            // 
            // metroTile5
            // 
            this.metroTile5.ActiveControl = null;
            this.metroTile5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile5.Location = new System.Drawing.Point(342, 136);
            this.metroTile5.Name = "metroTile5";
            this.metroTile5.Size = new System.Drawing.Size(220, 109);
            this.metroTile5.Style = MetroFramework.MetroColorStyle.Yellow;
            this.metroTile5.TabIndex = 7;
            this.metroTile5.Text = "DashBoard";
            this.metroTile5.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile5.TileImage")));
            this.metroTile5.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile5.UseSelectable = true;
            this.metroTile5.UseTileImage = true;
            this.metroTile5.Click += new System.EventHandler(this.metroTile5_Click);
            // 
            // metroTile4
            // 
            this.metroTile4.ActiveControl = null;
            this.metroTile4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile4.Location = new System.Drawing.Point(568, 22);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(225, 108);
            this.metroTile4.Style = MetroFramework.MetroColorStyle.Brown;
            this.metroTile4.TabIndex = 6;
            this.metroTile4.Text = "Change User role";
            this.metroTile4.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile4.TileImage")));
            this.metroTile4.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile4.UseSelectable = true;
            this.metroTile4.UseTileImage = true;
            this.metroTile4.Click += new System.EventHandler(this.metroTile4_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile2.Location = new System.Drawing.Point(105, 137);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(231, 108);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroTile2.TabIndex = 4;
            this.metroTile2.Text = "Add Student";
            this.metroTile2.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile2.TileImage")));
            this.metroTile2.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.UseTileImage = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile1.Location = new System.Drawing.Point(342, 22);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(220, 108);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTile1.TabIndex = 3;
            this.metroTile1.Text = "Change Login Credentials";
            this.metroTile1.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile1.TileImage")));
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // tile1
            // 
            this.tile1.ActiveControl = null;
            this.tile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tile1.BackColor = System.Drawing.SystemColors.GrayText;
            this.tile1.ContextMenuStrip = this.metroContextMenu1;
            this.tile1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.tile1.Location = new System.Drawing.Point(-5340, 26);
            this.tile1.Name = "tile1";
            this.tile1.Size = new System.Drawing.Size(231, 0);
            this.tile1.Style = MetroFramework.MetroColorStyle.Blue;
            this.tile1.TabIndex = 2;
            this.tile1.Text = "Add User";
            this.tile1.TileImage = ((System.Drawing.Image)(resources.GetObject("tile1.TileImage")));
            this.tile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tile1.UseSelectable = true;
            this.tile1.UseStyleColors = true;
            this.tile1.UseTileImage = true;
            this.tile1.Click += new System.EventHandler(this.tile1_Click);
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroContextMenu1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.metroToolTip.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // linkLabel_logout
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.linkLabel_logout, true);
            this.linkLabel_logout.AutoSize = true;
            this.linkLabel_logout.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_logout.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabel_logout.Location = new System.Drawing.Point(709, 34);
            this.linkLabel_logout.Name = "linkLabel_logout";
            this.linkLabel_logout.Size = new System.Drawing.Size(126, 23);
            this.linkLabel_logout.TabIndex = 17;
            this.linkLabel_logout.TabStop = true;
            this.linkLabel_logout.Text = "Admin: Log out";
            this.linkLabel_logout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
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
            this.BackImagePadding = new System.Windows.Forms.Padding(210, 10, 0, 0);
            this.BackMaxSize = 50;
            this.ClientSize = new System.Drawing.Size(966, 652);
            this.Controls.Add(this.linkLabel_logout);
            this.Controls.Add(this.metroTabControl1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.StyleManager = this.metroStyleManager;
            this.Text = "Nkujukira";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.live_stream_recognition_panel.ResumeLayout(false);
            this.live_stream_recognition_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.panel_for_detected_faces.ResumeLayout(false);
            this.panel_for_detected_faces.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.review_footage_image_box)).EndInit();
            this.metroTabPage11.ResumeLayout(false);
            this.metroContextMenu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion


        #region Controls
        private Controls.MetroTabControl metroTabControl1;
        private Components.MetroStyleManager metroStyleManager;
        private Controls.MetroTabPage metroTabPage1;
        private Components.MetroToolTip metroToolTip;
        private Components.MetroStyleExtender metroStyleExtender;
        private Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
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
        public static Emgu.CV.UI.ImageBox imageBox3;
        public static Emgu.CV.UI.ImageBox imageBox2;
        public static Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Label label1;
        private ImageBox review_footage_image_box;
        private System.Windows.Forms.Panel panel_for_detected_faces;
        private MB.Controls.ColorSlider review_footage_color_slider;
        private System.Windows.Forms.Label total_time_label;
        private System.Windows.Forms.Label time_elapsed_label;
        private Controls.MetroTabPage metroTabPage11;
        private Controls.MetroTile metroTile8;
        private Controls.MetroTile metroTile7;
        private Controls.MetroTile metroTile6;
        private Controls.MetroTile metroTile3;
        private Controls.MetroTile metroTile5;
        private Controls.MetroTile metroTile4;
        private Controls.MetroTile metroTile2;
        private Controls.MetroTile metroTile1;
        private Controls.MetroTile tile1;
        private System.Windows.Forms.Label label_separator;
        private System.Windows.Forms.Panel panel1;
        private ImageBox imageBox7;
        private ImageBox imageBox6;
        private ImageBox imageBox5;
        private ImageBox imageBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Controls.MetroTile metroTile9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabel_logout;
        private System.Windows.Forms.Label label_face_recognition_status;
        private Controls.MetroButton turn_on_button;
        private System.Windows.Forms.Panel live_stream_recognition_panel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        
     




    }
}

