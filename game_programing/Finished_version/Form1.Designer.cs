namespace OopLecture
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button_start = new System.Windows.Forms.Button();
            this.button_end = new System.Windows.Forms.Button();
            this.button_loop = new System.Windows.Forms.Button();
            this.button_loop_end = new System.Windows.Forms.Button();
            this.button_if = new System.Windows.Forms.Button();
            this.button_if_end = new System.Windows.Forms.Button();
            this.comboBox_if = new System.Windows.Forms.ComboBox();
            this.button_right = new System.Windows.Forms.Button();
            this.button_walk = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button_left = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_stage10 = new System.Windows.Forms.Button();
            this.button_stage9 = new System.Windows.Forms.Button();
            this.button_stage8 = new System.Windows.Forms.Button();
            this.button_stage7 = new System.Windows.Forms.Button();
            this.button_stage6 = new System.Windows.Forms.Button();
            this.button_stage5 = new System.Windows.Forms.Button();
            this.button_stage4 = new System.Windows.Forms.Button();
            this.button_stage3 = new System.Windows.Forms.Button();
            this.button_execution = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_stage2 = new System.Windows.Forms.Button();
            this.button_stage1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1183, 43);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 19);
            this.numericUpDown1.TabIndex = 16;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.numericUpDown1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.numericUpDown1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_start
            // 
            this.button_start.BackgroundImage = global::OopLecture.Properties.Resources.start;
            this.button_start.Location = new System.Drawing.Point(844, 12);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(100, 60);
            this.button_start.TabIndex = 19;
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            this.button_start.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_start.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_start.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_end
            // 
            this.button_end.BackgroundImage = global::OopLecture.Properties.Resources.end;
            this.button_end.Location = new System.Drawing.Point(844, 78);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(100, 60);
            this.button_end.TabIndex = 20;
            this.button_end.UseVisualStyleBackColor = true;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            this.button_end.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_end.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_end.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_loop
            // 
            this.button_loop.BackgroundImage = global::OopLecture.Properties.Resources._for;
            this.button_loop.Location = new System.Drawing.Point(1154, 12);
            this.button_loop.Name = "button_loop";
            this.button_loop.Size = new System.Drawing.Size(100, 60);
            this.button_loop.TabIndex = 21;
            this.button_loop.UseVisualStyleBackColor = true;
            this.button_loop.Click += new System.EventHandler(this.button_loop_Click);
            this.button_loop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_loop.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_loop.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_loop_end
            // 
            this.button_loop_end.BackgroundImage = global::OopLecture.Properties.Resources.forend;
            this.button_loop_end.Location = new System.Drawing.Point(1154, 78);
            this.button_loop_end.Name = "button_loop_end";
            this.button_loop_end.Size = new System.Drawing.Size(100, 60);
            this.button_loop_end.TabIndex = 22;
            this.button_loop_end.UseVisualStyleBackColor = true;
            this.button_loop_end.Click += new System.EventHandler(this.button_loop_end_Click);
            this.button_loop_end.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_loop_end.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_loop_end.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_if
            // 
            this.button_if.BackgroundImage = global::OopLecture.Properties.Resources._if;
            this.button_if.Location = new System.Drawing.Point(1000, 12);
            this.button_if.Name = "button_if";
            this.button_if.Size = new System.Drawing.Size(100, 60);
            this.button_if.TabIndex = 23;
            this.button_if.UseVisualStyleBackColor = true;
            this.button_if.Click += new System.EventHandler(this.button_if_Click);
            this.button_if.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_if.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_if.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_if_end
            // 
            this.button_if_end.BackgroundImage = global::OopLecture.Properties.Resources.ifend;
            this.button_if_end.Location = new System.Drawing.Point(1000, 78);
            this.button_if_end.Name = "button_if_end";
            this.button_if_end.Size = new System.Drawing.Size(100, 60);
            this.button_if_end.TabIndex = 24;
            this.button_if_end.UseVisualStyleBackColor = true;
            this.button_if_end.Click += new System.EventHandler(this.button_if_end_Click);
            this.button_if_end.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_if_end.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_if_end.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // comboBox_if
            // 
            this.comboBox_if.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_if.FormattingEnabled = true;
            this.comboBox_if.Location = new System.Drawing.Point(1008, 41);
            this.comboBox_if.Name = "comboBox_if";
            this.comboBox_if.Size = new System.Drawing.Size(83, 20);
            this.comboBox_if.TabIndex = 25;
            this.comboBox_if.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.comboBox_if.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.comboBox_if.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_right
            // 
            this.button_right.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_right.BackgroundImage")));
            this.button_right.Location = new System.Drawing.Point(1014, 144);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(75, 75);
            this.button_right.TabIndex = 26;
            this.button_right.UseVisualStyleBackColor = true;
            this.button_right.Click += new System.EventHandler(this.button_right_Click);
            this.button_right.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_right.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_right.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_walk
            // 
            this.button_walk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_walk.BackgroundImage")));
            this.button_walk.Location = new System.Drawing.Point(1167, 144);
            this.button_walk.Name = "button_walk";
            this.button_walk.Size = new System.Drawing.Size(75, 75);
            this.button_walk.TabIndex = 27;
            this.button_walk.UseVisualStyleBackColor = true;
            this.button_walk.Click += new System.EventHandler(this.button_walk_Click);
            this.button_walk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_walk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_walk.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_back
            // 
            this.button_back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_back.BackgroundImage")));
            this.button_back.Location = new System.Drawing.Point(933, 144);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 75);
            this.button_back.TabIndex = 28;
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            this.button_back.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_back.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_back.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_left
            // 
            this.button_left.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_left.BackgroundImage")));
            this.button_left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_left.Location = new System.Drawing.Point(852, 144);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(75, 75);
            this.button_left.TabIndex = 29;
            this.button_left.UseVisualStyleBackColor = true;
            this.button_left.Click += new System.EventHandler(this.button_left_Click);
            this.button_left.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_left.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_left.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(846, 224);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(445, 382);
            this.listBox1.TabIndex = 39;
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.listBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.listBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_stage10
            // 
            this.button_stage10.BackgroundImage = global::OopLecture.Properties.Resources.stage10;
            this.button_stage10.Location = new System.Drawing.Point(593, 12);
            this.button_stage10.Name = "button_stage10";
            this.button_stage10.Size = new System.Drawing.Size(55, 55);
            this.button_stage10.TabIndex = 38;
            this.button_stage10.UseVisualStyleBackColor = true;
            this.button_stage10.Click += new System.EventHandler(this.button_stage10_Click);
            this.button_stage10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_stage10.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_stage10.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_stage9
            // 
            this.button_stage9.BackgroundImage = global::OopLecture.Properties.Resources.stage9;
            this.button_stage9.Location = new System.Drawing.Point(532, 12);
            this.button_stage9.Name = "button_stage9";
            this.button_stage9.Size = new System.Drawing.Size(55, 55);
            this.button_stage9.TabIndex = 37;
            this.button_stage9.UseVisualStyleBackColor = true;
            this.button_stage9.Click += new System.EventHandler(this.button_stage9_Click);
            this.button_stage9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_stage9.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_stage9.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_stage8
            // 
            this.button_stage8.BackgroundImage = global::OopLecture.Properties.Resources.stage8;
            this.button_stage8.Location = new System.Drawing.Point(471, 12);
            this.button_stage8.Name = "button_stage8";
            this.button_stage8.Size = new System.Drawing.Size(55, 55);
            this.button_stage8.TabIndex = 36;
            this.button_stage8.UseVisualStyleBackColor = true;
            this.button_stage8.Click += new System.EventHandler(this.button_stage8_Click);
            this.button_stage8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_stage8.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_stage8.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_stage7
            // 
            this.button_stage7.BackgroundImage = global::OopLecture.Properties.Resources.stage7;
            this.button_stage7.Location = new System.Drawing.Point(410, 12);
            this.button_stage7.Name = "button_stage7";
            this.button_stage7.Size = new System.Drawing.Size(55, 55);
            this.button_stage7.TabIndex = 35;
            this.button_stage7.UseVisualStyleBackColor = true;
            this.button_stage7.Click += new System.EventHandler(this.button_stage7_Click);
            this.button_stage7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_stage7.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_stage7.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_stage6
            // 
            this.button_stage6.BackgroundImage = global::OopLecture.Properties.Resources.stage6;
            this.button_stage6.Location = new System.Drawing.Point(349, 12);
            this.button_stage6.Name = "button_stage6";
            this.button_stage6.Size = new System.Drawing.Size(55, 55);
            this.button_stage6.TabIndex = 34;
            this.button_stage6.UseVisualStyleBackColor = true;
            this.button_stage6.Click += new System.EventHandler(this.button_stage6_Click);
            this.button_stage6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_stage6.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_stage6.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_stage5
            // 
            this.button_stage5.BackgroundImage = global::OopLecture.Properties.Resources.stage5;
            this.button_stage5.Location = new System.Drawing.Point(288, 12);
            this.button_stage5.Name = "button_stage5";
            this.button_stage5.Size = new System.Drawing.Size(55, 55);
            this.button_stage5.TabIndex = 33;
            this.button_stage5.UseVisualStyleBackColor = true;
            this.button_stage5.Click += new System.EventHandler(this.button_stage5_Click);
            this.button_stage5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_stage5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_stage5.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_stage4
            // 
            this.button_stage4.BackgroundImage = global::OopLecture.Properties.Resources.stage4;
            this.button_stage4.Location = new System.Drawing.Point(227, 12);
            this.button_stage4.Name = "button_stage4";
            this.button_stage4.Size = new System.Drawing.Size(55, 55);
            this.button_stage4.TabIndex = 32;
            this.button_stage4.UseVisualStyleBackColor = true;
            this.button_stage4.Click += new System.EventHandler(this.button_stage4_Click);
            this.button_stage4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_stage4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_stage4.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_stage3
            // 
            this.button_stage3.BackgroundImage = global::OopLecture.Properties.Resources.stage3;
            this.button_stage3.Location = new System.Drawing.Point(166, 12);
            this.button_stage3.Name = "button_stage3";
            this.button_stage3.Size = new System.Drawing.Size(55, 55);
            this.button_stage3.TabIndex = 31;
            this.button_stage3.UseVisualStyleBackColor = true;
            this.button_stage3.Click += new System.EventHandler(this.button_stage3_Click);
            this.button_stage3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_stage3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_stage3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_execution
            // 
            this.button_execution.BackgroundImage = global::OopLecture.Properties.Resources.done;
            this.button_execution.Location = new System.Drawing.Point(881, 618);
            this.button_execution.Name = "button_execution";
            this.button_execution.Size = new System.Drawing.Size(150, 60);
            this.button_execution.TabIndex = 30;
            this.button_execution.UseVisualStyleBackColor = true;
            this.button_execution.Click += new System.EventHandler(this.button_execution_Click);
            this.button_execution.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_execution.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_execution.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_delete
            // 
            this.button_delete.BackgroundImage = global::OopLecture.Properties.Resources.delete;
            this.button_delete.Location = new System.Drawing.Point(1108, 618);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(150, 60);
            this.button_delete.TabIndex = 17;
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            this.button_delete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_delete.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_delete.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_stage2
            // 
            this.button_stage2.BackgroundImage = global::OopLecture.Properties.Resources.stage2;
            this.button_stage2.Location = new System.Drawing.Point(107, 12);
            this.button_stage2.Name = "button_stage2";
            this.button_stage2.Size = new System.Drawing.Size(55, 55);
            this.button_stage2.TabIndex = 5;
            this.button_stage2.UseVisualStyleBackColor = true;
            this.button_stage2.Click += new System.EventHandler(this.button_stage2_Click);
            this.button_stage2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_stage2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_stage2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_stage1
            // 
            this.button_stage1.BackgroundImage = global::OopLecture.Properties.Resources.stage1;
            this.button_stage1.Location = new System.Drawing.Point(46, 12);
            this.button_stage1.Name = "button_stage1";
            this.button_stage1.Size = new System.Drawing.Size(55, 55);
            this.button_stage1.TabIndex = 4;
            this.button_stage1.UseVisualStyleBackColor = true;
            this.button_stage1.Click += new System.EventHandler(this.button_stage1_Click);
            this.button_stage1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.button_stage1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.button_stage1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer3
            // 
            this.timer3.Interval = 200;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OopLecture.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1334, 681);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_stage10);
            this.Controls.Add(this.button_stage9);
            this.Controls.Add(this.button_stage8);
            this.Controls.Add(this.button_stage7);
            this.Controls.Add(this.button_stage6);
            this.Controls.Add(this.button_stage5);
            this.Controls.Add(this.button_stage4);
            this.Controls.Add(this.button_stage3);
            this.Controls.Add(this.button_execution);
            this.Controls.Add(this.button_left);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_walk);
            this.Controls.Add(this.button_right);
            this.Controls.Add(this.comboBox_if);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button_if_end);
            this.Controls.Add(this.button_if);
            this.Controls.Add(this.button_loop_end);
            this.Controls.Add(this.button_loop);
            this.Controls.Add(this.button_end);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_stage2);
            this.Controls.Add(this.button_stage1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "Form1";
            this.Text = "ゲームで学ぶプログラミング -勇者の大脱出-";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_stage1;
        private System.Windows.Forms.Button button_stage2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_end;
        private System.Windows.Forms.Button button_loop;
        private System.Windows.Forms.Button button_loop_end;
        private System.Windows.Forms.Button button_if;
        private System.Windows.Forms.Button button_if_end;
        private System.Windows.Forms.ComboBox comboBox_if;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Button button_walk;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Button button_execution;
        private System.Windows.Forms.Button button_stage3;
        private System.Windows.Forms.Button button_stage4;
        private System.Windows.Forms.Button button_stage5;
        private System.Windows.Forms.Button button_stage6;
        private System.Windows.Forms.Button button_stage7;
        private System.Windows.Forms.Button button_stage8;
        private System.Windows.Forms.Button button_stage9;
        private System.Windows.Forms.Button button_stage10;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer3;
    }
}

