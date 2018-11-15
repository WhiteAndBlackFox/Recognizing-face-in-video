namespace MultiFaceRec
{
    partial class filtredCam
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.checkRetinexSSR = new System.Windows.Forms.CheckBox();
            this.checkqual = new System.Windows.Forms.CheckBox();
            this.checkGaussian = new System.Windows.Forms.CheckBox();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.checkMedian = new System.Windows.Forms.CheckBox();
            this.checkBinariz = new System.Windows.Forms.CheckBox();
            this.trackBar7 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBar8 = new System.Windows.Forms.TrackBar();
            this.checkCanny = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.trackBar9 = new System.Windows.Forms.TrackBar();
            this.trackBar10 = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.trackBar11 = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.trackBar12 = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.checkSobel = new System.Windows.Forms.CheckBox();
            this.checkRetinexHSV = new System.Windows.Forms.CheckBox();
            this.checkRetinexColors = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(128, 12);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Minimum = -255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(409, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Яркость = 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Контраст = 1";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(128, 63);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Minimum = 1;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(409, 45);
            this.trackBar2.TabIndex = 3;
            this.trackBar2.Value = 1;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(128, 248);
            this.trackBar3.Minimum = 2;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(409, 45);
            this.trackBar3.TabIndex = 7;
            this.trackBar3.Value = 2;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Сигма = 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Гауссиан = 0";
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(128, 197);
            this.trackBar4.Maximum = 100;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(409, 45);
            this.trackBar4.TabIndex = 4;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // checkRetinexSSR
            // 
            this.checkRetinexSSR.AutoSize = true;
            this.checkRetinexSSR.Location = new System.Drawing.Point(12, 161);
            this.checkRetinexSSR.Name = "checkRetinexSSR";
            this.checkRetinexSSR.Size = new System.Drawing.Size(81, 17);
            this.checkRetinexSSR.TabIndex = 8;
            this.checkRetinexSSR.Text = "Retinex msr";
            this.checkRetinexSSR.UseVisualStyleBackColor = true;
            this.checkRetinexSSR.CheckedChanged += new System.EventHandler(this.checkRetinexSSR_CheckedChanged);
            // 
            // checkqual
            // 
            this.checkqual.AutoSize = true;
            this.checkqual.Location = new System.Drawing.Point(15, 114);
            this.checkqual.Name = "checkqual";
            this.checkqual.Size = new System.Drawing.Size(93, 17);
            this.checkqual.TabIndex = 10;
            this.checkqual.Text = "Эквализация";
            this.checkqual.UseVisualStyleBackColor = true;
            // 
            // checkGaussian
            // 
            this.checkGaussian.AutoSize = true;
            this.checkGaussian.Location = new System.Drawing.Point(12, 316);
            this.checkGaussian.Name = "checkGaussian";
            this.checkGaussian.Size = new System.Drawing.Size(104, 17);
            this.checkGaussian.TabIndex = 11;
            this.checkGaussian.Text = "Фильтр Гаусса";
            this.checkGaussian.UseVisualStyleBackColor = true;
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(128, 340);
            this.trackBar5.Maximum = 13;
            this.trackBar5.Minimum = 5;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(409, 45);
            this.trackBar5.TabIndex = 12;
            this.trackBar5.Value = 5;
            this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Сигма = 5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Сигма = 5";
            // 
            // trackBar6
            // 
            this.trackBar6.Location = new System.Drawing.Point(128, 413);
            this.trackBar6.Maximum = 13;
            this.trackBar6.Minimum = 5;
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(409, 45);
            this.trackBar6.TabIndex = 15;
            this.trackBar6.Value = 5;
            this.trackBar6.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // checkMedian
            // 
            this.checkMedian.AutoSize = true;
            this.checkMedian.Location = new System.Drawing.Point(12, 389);
            this.checkMedian.Name = "checkMedian";
            this.checkMedian.Size = new System.Drawing.Size(125, 17);
            this.checkMedian.TabIndex = 14;
            this.checkMedian.Text = "Медианный фильтр";
            this.checkMedian.UseVisualStyleBackColor = true;
            // 
            // checkBinariz
            // 
            this.checkBinariz.AutoSize = true;
            this.checkBinariz.Location = new System.Drawing.Point(12, 464);
            this.checkBinariz.Name = "checkBinariz";
            this.checkBinariz.Size = new System.Drawing.Size(150, 17);
            this.checkBinariz.TabIndex = 17;
            this.checkBinariz.Text = "Пороговая бинаризация";
            this.checkBinariz.UseVisualStyleBackColor = true;
            // 
            // trackBar7
            // 
            this.trackBar7.Location = new System.Drawing.Point(128, 489);
            this.trackBar7.Maximum = 255;
            this.trackBar7.Minimum = 1;
            this.trackBar7.Name = "trackBar7";
            this.trackBar7.Size = new System.Drawing.Size(400, 45);
            this.trackBar7.TabIndex = 18;
            this.trackBar7.Value = 1;
            this.trackBar7.Scroll += new System.EventHandler(this.trackBar7_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 500);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Max Порог = 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 551);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Min Порог = 1";
            // 
            // trackBar8
            // 
            this.trackBar8.Location = new System.Drawing.Point(128, 540);
            this.trackBar8.Maximum = 255;
            this.trackBar8.Minimum = 1;
            this.trackBar8.Name = "trackBar8";
            this.trackBar8.Size = new System.Drawing.Size(400, 45);
            this.trackBar8.TabIndex = 20;
            this.trackBar8.Value = 1;
            this.trackBar8.Scroll += new System.EventHandler(this.trackBar8_Scroll);
            // 
            // checkCanny
            // 
            this.checkCanny.AutoSize = true;
            this.checkCanny.Location = new System.Drawing.Point(18, 610);
            this.checkCanny.Name = "checkCanny";
            this.checkCanny.Size = new System.Drawing.Size(57, 17);
            this.checkCanny.TabIndex = 22;
            this.checkCanny.Text = "Канни";
            this.checkCanny.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 634);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Max Границы = 180";
            // 
            // trackBar9
            // 
            this.trackBar9.Location = new System.Drawing.Point(128, 634);
            this.trackBar9.Maximum = 200;
            this.trackBar9.Minimum = 10;
            this.trackBar9.Name = "trackBar9";
            this.trackBar9.Size = new System.Drawing.Size(400, 45);
            this.trackBar9.TabIndex = 24;
            this.trackBar9.Value = 180;
            this.trackBar9.Scroll += new System.EventHandler(this.trackBar9_Scroll);
            // 
            // trackBar10
            // 
            this.trackBar10.Location = new System.Drawing.Point(128, 685);
            this.trackBar10.Maximum = 200;
            this.trackBar10.Minimum = 10;
            this.trackBar10.Name = "trackBar10";
            this.trackBar10.Size = new System.Drawing.Size(400, 45);
            this.trackBar10.TabIndex = 26;
            this.trackBar10.Value = 80;
            this.trackBar10.Scroll += new System.EventHandler(this.trackBar10_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 685);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Min Границы = 80";
            // 
            // trackBar11
            // 
            this.trackBar11.Location = new System.Drawing.Point(128, 807);
            this.trackBar11.Maximum = 200;
            this.trackBar11.Minimum = 10;
            this.trackBar11.Name = "trackBar11";
            this.trackBar11.Size = new System.Drawing.Size(400, 45);
            this.trackBar11.TabIndex = 31;
            this.trackBar11.Value = 80;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 807);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Min Границы = 80";
            // 
            // trackBar12
            // 
            this.trackBar12.Location = new System.Drawing.Point(128, 756);
            this.trackBar12.Maximum = 200;
            this.trackBar12.Minimum = 10;
            this.trackBar12.Name = "trackBar12";
            this.trackBar12.Size = new System.Drawing.Size(400, 45);
            this.trackBar12.TabIndex = 29;
            this.trackBar12.Value = 180;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 756);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Max Границы = 180";
            // 
            // checkSobel
            // 
            this.checkSobel.AutoSize = true;
            this.checkSobel.Location = new System.Drawing.Point(18, 732);
            this.checkSobel.Name = "checkSobel";
            this.checkSobel.Size = new System.Drawing.Size(68, 17);
            this.checkSobel.TabIndex = 27;
            this.checkSobel.Text = "Роберта";
            this.checkSobel.UseVisualStyleBackColor = true;
            // 
            // checkRetinexHSV
            // 
            this.checkRetinexHSV.AutoSize = true;
            this.checkRetinexHSV.Location = new System.Drawing.Point(116, 161);
            this.checkRetinexHSV.Name = "checkRetinexHSV";
            this.checkRetinexHSV.Size = new System.Drawing.Size(87, 17);
            this.checkRetinexHSV.TabIndex = 32;
            this.checkRetinexHSV.Text = "Retinex HSV";
            this.checkRetinexHSV.UseVisualStyleBackColor = true;
            this.checkRetinexHSV.CheckedChanged += new System.EventHandler(this.checkRetinexHSV_CheckedChanged);
            // 
            // checkRetinexColors
            // 
            this.checkRetinexColors.AutoSize = true;
            this.checkRetinexColors.Location = new System.Drawing.Point(214, 161);
            this.checkRetinexColors.Name = "checkRetinexColors";
            this.checkRetinexColors.Size = new System.Drawing.Size(94, 17);
            this.checkRetinexColors.TabIndex = 33;
            this.checkRetinexColors.Text = "Retinex Colors";
            this.checkRetinexColors.UseVisualStyleBackColor = true;
            this.checkRetinexColors.CheckedChanged += new System.EventHandler(this.checkRetinexColors_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(314, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Количество прогулов";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(436, 161);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(92, 20);
            this.numericUpDown1.TabIndex = 36;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // filtredCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 891);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.checkRetinexColors);
            this.Controls.Add(this.checkRetinexHSV);
            this.Controls.Add(this.trackBar11);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.trackBar12);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.checkSobel);
            this.Controls.Add(this.trackBar10);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.trackBar9);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.checkCanny);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.trackBar8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.trackBar7);
            this.Controls.Add(this.checkBinariz);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackBar6);
            this.Controls.Add(this.checkMedian);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBar5);
            this.Controls.Add(this.checkGaussian);
            this.Controls.Add(this.checkqual);
            this.Controls.Add(this.checkRetinexSSR);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Name = "filtredCam";
            this.Text = "Фильтры";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar4;
        public System.Windows.Forms.CheckBox checkRetinexSSR;
        public System.Windows.Forms.CheckBox checkqual;
        public System.Windows.Forms.CheckBox checkGaussian;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBar6;
        public System.Windows.Forms.CheckBox checkMedian;
        private System.Windows.Forms.TrackBar trackBar7;
        public System.Windows.Forms.CheckBox checkBinariz;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackBar8;
        public System.Windows.Forms.CheckBox checkCanny;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trackBar9;
        private System.Windows.Forms.TrackBar trackBar10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackBar11;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trackBar12;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.CheckBox checkSobel;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Windows.Forms.CheckBox checkRetinexHSV;
        public System.Windows.Forms.CheckBox checkRetinexColors;
    }
}