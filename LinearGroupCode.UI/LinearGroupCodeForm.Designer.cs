namespace LinearGroupCode.UI
{
    partial class LinearGroupCodeForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.AlphabeticLengthTextbox = new System.Windows.Forms.TextBox();
            this.GetGeneratingMatrixButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.GeneratingMatrixTextBox = new System.Windows.Forms.TextBox();
            this.SourceCodeTextBox = new System.Windows.Forms.TextBox();
            this.VectorCodeTextBox = new System.Windows.Forms.TextBox();
            this.GetVectorCodeButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SendVectorTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RecivedVectorTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SyndromTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NumberErrorBitTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CorrectRecivedVectorTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GetSendVectorButton = new System.Windows.Forms.Button();
            this.DetectedAndCorrectErrorButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.DetectedCheckBox = new System.Windows.Forms.CheckBox();
            this.FixCheckBox = new System.Windows.Forms.CheckBox();
            this.RankFixNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ProcessDetectedTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ShowExecutionCheckBox = new System.Windows.Forms.CheckBox();
            this.RankDetectedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RankFixNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RankDetectedNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Объем алфавита (N):";
            // 
            // AlphabeticLengthTextbox
            // 
            this.AlphabeticLengthTextbox.Location = new System.Drawing.Point(129, 12);
            this.AlphabeticLengthTextbox.Name = "AlphabeticLengthTextbox";
            this.AlphabeticLengthTextbox.Size = new System.Drawing.Size(78, 20);
            this.AlphabeticLengthTextbox.TabIndex = 1;
            this.AlphabeticLengthTextbox.Text = "16";
            this.AlphabeticLengthTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlphabeticLengthTextboxKeyPress);
            // 
            // GetGeneratingMatrixButton
            // 
            this.GetGeneratingMatrixButton.Location = new System.Drawing.Point(13, 119);
            this.GetGeneratingMatrixButton.Name = "GetGeneratingMatrixButton";
            this.GetGeneratingMatrixButton.Size = new System.Drawing.Size(194, 35);
            this.GetGeneratingMatrixButton.TabIndex = 2;
            this.GetGeneratingMatrixButton.Text = "Расчитать G";
            this.GetGeneratingMatrixButton.UseVisualStyleBackColor = true;
            this.GetGeneratingMatrixButton.Click += new System.EventHandler(this.GetGeneratingMatrixButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Производящая матрица (G):";
            // 
            // GeneratingMatrixTextBox
            // 
            this.GeneratingMatrixTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GeneratingMatrixTextBox.Location = new System.Drawing.Point(225, 36);
            this.GeneratingMatrixTextBox.Multiline = true;
            this.GeneratingMatrixTextBox.Name = "GeneratingMatrixTextBox";
            this.GeneratingMatrixTextBox.ReadOnly = true;
            this.GeneratingMatrixTextBox.Size = new System.Drawing.Size(185, 116);
            this.GeneratingMatrixTextBox.TabIndex = 22;
            // 
            // SourceCodeTextBox
            // 
            this.SourceCodeTextBox.Location = new System.Drawing.Point(25, 185);
            this.SourceCodeTextBox.Name = "SourceCodeTextBox";
            this.SourceCodeTextBox.Size = new System.Drawing.Size(143, 20);
            this.SourceCodeTextBox.TabIndex = 5;
            this.SourceCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PressZeroOrOneKeyPress);
            // 
            // VectorCodeTextBox
            // 
            this.VectorCodeTextBox.Location = new System.Drawing.Point(293, 186);
            this.VectorCodeTextBox.Name = "VectorCodeTextBox";
            this.VectorCodeTextBox.Size = new System.Drawing.Size(143, 20);
            this.VectorCodeTextBox.TabIndex = 7;
            // 
            // GetVectorCodeButton
            // 
            this.GetVectorCodeButton.Enabled = false;
            this.GetVectorCodeButton.Location = new System.Drawing.Point(187, 183);
            this.GetVectorCodeButton.Name = "GetVectorCodeButton";
            this.GetVectorCodeButton.Size = new System.Drawing.Size(96, 23);
            this.GetVectorCodeButton.TabIndex = 6;
            this.GetVectorCodeButton.Text = "Получить->";
            this.GetVectorCodeButton.UseVisualStyleBackColor = true;
            this.GetVectorCodeButton.Click += new System.EventHandler(this.GetVectorCodeButtonClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Исходный код:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Кодовый вектор:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Переданный код:";
            // 
            // SendVectorTextBox
            // 
            this.SendVectorTextBox.Location = new System.Drawing.Point(15, 39);
            this.SendVectorTextBox.Name = "SendVectorTextBox";
            this.SendVectorTextBox.Size = new System.Drawing.Size(140, 20);
            this.SendVectorTextBox.TabIndex = 10;
            this.SendVectorTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SendVectorTextBoxKeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Полученный код:";
            // 
            // RecivedVectorTextBox
            // 
            this.RecivedVectorTextBox.Location = new System.Drawing.Point(280, 39);
            this.RecivedVectorTextBox.Name = "RecivedVectorTextBox";
            this.RecivedVectorTextBox.Size = new System.Drawing.Size(143, 20);
            this.RecivedVectorTextBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Синдром:";
            // 
            // SyndromTextBox
            // 
            this.SyndromTextBox.Location = new System.Drawing.Point(15, 92);
            this.SyndromTextBox.Name = "SyndromTextBox";
            this.SyndromTextBox.ReadOnly = true;
            this.SyndromTextBox.Size = new System.Drawing.Size(67, 20);
            this.SyndromTextBox.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(139, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Номер ошибочного бита:";
            // 
            // NumberErrorBitTextBox
            // 
            this.NumberErrorBitTextBox.Location = new System.Drawing.Point(183, 92);
            this.NumberErrorBitTextBox.Name = "NumberErrorBitTextBox";
            this.NumberErrorBitTextBox.ReadOnly = true;
            this.NumberErrorBitTextBox.Size = new System.Drawing.Size(51, 20);
            this.NumberErrorBitTextBox.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(277, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Коррекция результата:";
            // 
            // CorrectRecivedVectorTextBox
            // 
            this.CorrectRecivedVectorTextBox.Location = new System.Drawing.Point(280, 92);
            this.CorrectRecivedVectorTextBox.Name = "CorrectRecivedVectorTextBox";
            this.CorrectRecivedVectorTextBox.ReadOnly = true;
            this.CorrectRecivedVectorTextBox.Size = new System.Drawing.Size(143, 20);
            this.CorrectRecivedVectorTextBox.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GetSendVectorButton);
            this.groupBox1.Controls.Add(this.DetectedAndCorrectErrorButton);
            this.groupBox1.Controls.Add(this.SendVectorTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CorrectRecivedVectorTextBox);
            this.groupBox1.Controls.Add(this.RecivedVectorTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NumberErrorBitTextBox);
            this.groupBox1.Controls.Add(this.SyndromTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(13, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 124);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обнаружение и исправление одиночной ошибки:";
            // 
            // GetSendVectorButton
            // 
            this.GetSendVectorButton.Enabled = false;
            this.GetSendVectorButton.Location = new System.Drawing.Point(113, 23);
            this.GetSendVectorButton.Name = "GetSendVectorButton";
            this.GetSendVectorButton.Size = new System.Drawing.Size(39, 13);
            this.GetSendVectorButton.TabIndex = 22;
            this.GetSendVectorButton.UseVisualStyleBackColor = true;
            this.GetSendVectorButton.Click += new System.EventHandler(this.GetSendVectorButtonClick);
            // 
            // DetectedAndCorrectErrorButton
            // 
            this.DetectedAndCorrectErrorButton.Enabled = false;
            this.DetectedAndCorrectErrorButton.Location = new System.Drawing.Point(174, 36);
            this.DetectedAndCorrectErrorButton.Name = "DetectedAndCorrectErrorButton";
            this.DetectedAndCorrectErrorButton.Size = new System.Drawing.Size(96, 23);
            this.DetectedAndCorrectErrorButton.TabIndex = 14;
            this.DetectedAndCorrectErrorButton.Text = "Проверить";
            this.DetectedAndCorrectErrorButton.UseVisualStyleBackColor = true;
            this.DetectedAndCorrectErrorButton.Click += new System.EventHandler(this.DetectedAndCorrectErrorButtonClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Ранг ошибки, которую необходимо:";
            // 
            // DetectedCheckBox
            // 
            this.DetectedCheckBox.AutoSize = true;
            this.DetectedCheckBox.Location = new System.Drawing.Point(12, 64);
            this.DetectedCheckBox.Name = "DetectedCheckBox";
            this.DetectedCheckBox.Size = new System.Drawing.Size(88, 17);
            this.DetectedCheckBox.TabIndex = 23;
            this.DetectedCheckBox.Text = "Обнаружить";
            this.DetectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // FixCheckBox
            // 
            this.FixCheckBox.AutoSize = true;
            this.FixCheckBox.Location = new System.Drawing.Point(12, 88);
            this.FixCheckBox.Name = "FixCheckBox";
            this.FixCheckBox.Size = new System.Drawing.Size(81, 17);
            this.FixCheckBox.TabIndex = 24;
            this.FixCheckBox.Text = "Исправить";
            this.FixCheckBox.UseVisualStyleBackColor = true;
            // 
            // RankFixNumericUpDown
            // 
            this.RankFixNumericUpDown.Location = new System.Drawing.Point(128, 88);
            this.RankFixNumericUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RankFixNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RankFixNumericUpDown.Name = "RankFixNumericUpDown";
            this.RankFixNumericUpDown.ReadOnly = true;
            this.RankFixNumericUpDown.Size = new System.Drawing.Size(78, 20);
            this.RankFixNumericUpDown.TabIndex = 25;
            this.RankFixNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ProcessDetectedTextBox
            // 
            this.ProcessDetectedTextBox.Location = new System.Drawing.Point(454, 36);
            this.ProcessDetectedTextBox.Multiline = true;
            this.ProcessDetectedTextBox.Name = "ProcessDetectedTextBox";
            this.ProcessDetectedTextBox.ReadOnly = true;
            this.ProcessDetectedTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ProcessDetectedTextBox.Size = new System.Drawing.Size(271, 306);
            this.ProcessDetectedTextBox.TabIndex = 26;
            this.ProcessDetectedTextBox.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(451, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Процесс выполнения:";
            this.label11.Visible = false;
            // 
            // ShowExecutionCheckBox
            // 
            this.ShowExecutionCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ShowExecutionCheckBox.Location = new System.Drawing.Point(416, 36);
            this.ShowExecutionCheckBox.Name = "ShowExecutionCheckBox";
            this.ShowExecutionCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowExecutionCheckBox.Size = new System.Drawing.Size(29, 118);
            this.ShowExecutionCheckBox.TabIndex = 28;
            this.ShowExecutionCheckBox.Text = ">>";
            this.ShowExecutionCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ShowExecutionCheckBox.UseVisualStyleBackColor = true;
            this.ShowExecutionCheckBox.CheckedChanged += new System.EventHandler(this.ShowExecutionCheckBoxCheckedChanged);
            // 
            // RankDetectedNumericUpDown
            // 
            this.RankDetectedNumericUpDown.Location = new System.Drawing.Point(129, 59);
            this.RankDetectedNumericUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.RankDetectedNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RankDetectedNumericUpDown.Name = "RankDetectedNumericUpDown";
            this.RankDetectedNumericUpDown.ReadOnly = true;
            this.RankDetectedNumericUpDown.Size = new System.Drawing.Size(78, 20);
            this.RankDetectedNumericUpDown.TabIndex = 29;
            this.RankDetectedNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LinearGroupCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 354);
            this.Controls.Add(this.RankDetectedNumericUpDown);
            this.Controls.Add(this.ShowExecutionCheckBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ProcessDetectedTextBox);
            this.Controls.Add(this.RankFixNumericUpDown);
            this.Controls.Add(this.FixCheckBox);
            this.Controls.Add(this.DetectedCheckBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GetVectorCodeButton);
            this.Controls.Add(this.VectorCodeTextBox);
            this.Controls.Add(this.SourceCodeTextBox);
            this.Controls.Add(this.GeneratingMatrixTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GetGeneratingMatrixButton);
            this.Controls.Add(this.AlphabeticLengthTextbox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LinearGroupCodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №2. Линейные групповые коды";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RankFixNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RankDetectedNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AlphabeticLengthTextbox;
        private System.Windows.Forms.Button GetGeneratingMatrixButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GeneratingMatrixTextBox;
        private System.Windows.Forms.TextBox SourceCodeTextBox;
        private System.Windows.Forms.TextBox VectorCodeTextBox;
        private System.Windows.Forms.Button GetVectorCodeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SendVectorTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RecivedVectorTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox SyndromTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NumberErrorBitTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CorrectRecivedVectorTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DetectedAndCorrectErrorButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox DetectedCheckBox;
        private System.Windows.Forms.CheckBox FixCheckBox;
        private System.Windows.Forms.NumericUpDown RankFixNumericUpDown;
        private System.Windows.Forms.TextBox ProcessDetectedTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox ShowExecutionCheckBox;
        private System.Windows.Forms.Button GetSendVectorButton;
        private System.Windows.Forms.NumericUpDown RankDetectedNumericUpDown;
    }
}