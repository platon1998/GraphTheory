namespace LineG
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.Number = new System.Windows.Forms.TextBox();
            this.Size = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChooseColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.Apply = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dfs = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 259);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(352, 93);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 20);
            this.button4.TabIndex = 4;
            this.button4.Text = "tex";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Number
            // 
            this.Number.Location = new System.Drawing.Point(352, 12);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(87, 20);
            this.Number.TabIndex = 11;
            this.Number.TextChanged += new System.EventHandler(this.number_TextChanged);
            // 
            // Size
            // 
            this.Size.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Size.Location = new System.Drawing.Point(352, 38);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(87, 20);
            this.Size.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Radius/Weight";
            // 
            // ChooseColor
            // 
            this.ChooseColor.Location = new System.Drawing.Point(495, 8);
            this.ChooseColor.Name = "ChooseColor";
            this.ChooseColor.Size = new System.Drawing.Size(57, 20);
            this.ChooseColor.TabIndex = 16;
            this.ChooseColor.Text = "Color";
            this.ChooseColor.UseVisualStyleBackColor = true;
            this.ChooseColor.Click += new System.EventHandler(this.ChooseColor_Click);
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(398, 64);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(41, 23);
            this.Apply.TabIndex = 17;
            this.Apply.Text = "Apply";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(351, 64);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(41, 23);
            this.delete.TabIndex = 18;
            this.delete.Text = "del";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(445, 64);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 23);
            this.button5.TabIndex = 19;
            this.button5.Text = "Tex(pdf)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // dfs
            // 
            this.dfs.Location = new System.Drawing.Point(445, 93);
            this.dfs.Name = "dfs";
            this.dfs.Size = new System.Drawing.Size(40, 20);
            this.dfs.TabIndex = 20;
            this.dfs.Text = "dfs";
            this.dfs.UseVisualStyleBackColor = true;
            this.dfs.Click += new System.EventHandler(this.dfs_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 283);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dfs);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.ChooseColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Size);
            this.Controls.Add(this.Number);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Number;
        private System.Windows.Forms.MaskedTextBox Size;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ChooseColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button dfs;
        private System.Windows.Forms.Button button1;
    }
}

