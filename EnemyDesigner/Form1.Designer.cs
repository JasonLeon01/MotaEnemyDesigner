﻿namespace EnemyDesigner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            listBox1 = new ListBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            textBox7 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            comboBox1 = new ComboBox();
            checkedListBox1 = new CheckedListBox();
            label9 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label10 = new Label();
            textBox8 = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button5 = new Button();
            comboBox2 = new ComboBox();
            label11 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(130, 276);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(148, 12);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 1;
            label1.Text = "敌人名字";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(216, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(111, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(161, 186);
            label2.Name = "label2";
            label2.Size = new Size(32, 17);
            label2.TabIndex = 3;
            label2.Text = "生命";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(206, 183);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(62, 23);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(282, 186);
            label3.Name = "label3";
            label3.Size = new Size(32, 17);
            label3.TabIndex = 5;
            label3.Text = "攻击";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(327, 183);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(62, 23);
            textBox3.TabIndex = 6;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(327, 219);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(62, 23);
            textBox4.TabIndex = 10;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(282, 222);
            label4.Name = "label4";
            label4.Size = new Size(32, 17);
            label4.TabIndex = 9;
            label4.Text = "连击";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(206, 219);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(62, 23);
            textBox5.TabIndex = 8;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(161, 222);
            label5.Name = "label5";
            label5.Size = new Size(32, 17);
            label5.TabIndex = 7;
            label5.Text = "防御";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(327, 255);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(62, 23);
            textBox6.TabIndex = 14;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(282, 258);
            label6.Name = "label6";
            label6.Size = new Size(32, 17);
            label6.TabIndex = 13;
            label6.Text = "金币";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(206, 255);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(62, 23);
            textBox7.TabIndex = 12;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(161, 258);
            label7.Name = "label7";
            label7.Size = new Size(32, 17);
            label7.TabIndex = 11;
            label7.Text = "经验";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(161, 298);
            label8.Name = "label8";
            label8.Size = new Size(56, 17);
            label8.TabIndex = 16;
            label8.Text = "动画编号";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(221, 295);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(153, 25);
            comboBox1.TabIndex = 17;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(436, 12);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(66, 274);
            checkedListBox1.TabIndex = 18;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(398, 12);
            label9.Name = "label9";
            label9.Size = new Size(32, 17);
            label9.TabIndex = 19;
            label9.Text = "属性";
            // 
            // button1
            // 
            button1.Location = new Point(12, 292);
            button1.Name = "button1";
            button1.Size = new Size(130, 23);
            button1.TabIndex = 20;
            button1.Text = "新建";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 321);
            button2.Name = "button2";
            button2.Size = new Size(130, 23);
            button2.TabIndex = 21;
            button2.Text = "删除";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(436, 292);
            button3.Name = "button3";
            button3.Size = new Size(66, 23);
            button3.TabIndex = 22;
            button3.Text = "新建";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(436, 321);
            button4.Name = "button4";
            button4.Size = new Size(66, 23);
            button4.TabIndex = 23;
            button4.Text = "删除";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(520, 12);
            label10.Name = "label10";
            label10.Size = new Size(32, 17);
            label10.TabIndex = 24;
            label10.Text = "描述";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(571, 12);
            textBox8.Multiline = true;
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(170, 279);
            textBox8.TabIndex = 25;
            textBox8.TextChanged += textBox8_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonShadow;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Location = new Point(161, 47);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ButtonShadow;
            pictureBox2.Location = new Point(305, 47);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 27;
            pictureBox2.TabStop = false;
            // 
            // button5
            // 
            button5.Location = new Point(12, 350);
            button5.Name = "button5";
            button5.Size = new Size(130, 23);
            button5.TabIndex = 28;
            button5.Text = "保存";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "0", "1", "2", "3" });
            comboBox2.Location = new Point(305, 108);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(58, 25);
            comboBox2.TabIndex = 29;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(306, 86);
            label11.Name = "label11";
            label11.Size = new Size(32, 17);
            label11.TabIndex = 30;
            label11.Text = "位置";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // button6
            // 
            button6.Location = new Point(436, 350);
            button6.Name = "button6";
            button6.Size = new Size(66, 23);
            button6.TabIndex = 31;
            button6.Text = "改名";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(755, 394);
            Controls.Add(button6);
            Controls.Add(label11);
            Controls.Add(comboBox2);
            Controls.Add(button5);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(textBox8);
            Controls.Add(label10);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label9);
            Controls.Add(checkedListBox1);
            Controls.Add(comboBox1);
            Controls.Add(label8);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(textBox7);
            Controls.Add(label7);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(listBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "魔塔怪物设计器";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox7;
        private Label label7;
        private Label label8;
        private ComboBox comboBox1;
        private CheckedListBox checkedListBox1;
        private Label label9;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label10;
        private TextBox textBox8;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button5;
        private ComboBox comboBox2;
        private Label label11;
        private System.Windows.Forms.Timer timer1;
        private Button button6;
    }
}