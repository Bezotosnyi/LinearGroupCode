// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinearGroupCodeForm.cs" company="DNU">
//   Dima Bezotosnyi
// </copyright>
// <summary>
//   Defines the LinearGroupCodeForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LinearGroupCode.UI
{
    using System;
    using System.Windows.Forms;
    using BLL;

    /// <summary>
    /// Форма для работы с линейными групповыми кодами
    /// </summary>
    public partial class LinearGroupCodeForm : Form
    {
        private readonly LinearGroupCodeLogic linearGroupCodeLogic;

        public LinearGroupCodeForm()
        {
            this.InitializeComponent();
            this.Width = 473;
            this.linearGroupCodeLogic = new LinearGroupCodeLogic();
        }

        // получение G матрицы
        private void GetGeneratingMatrixButtonClick(object sender, EventArgs e)
        {
            if (!this.FixCheckBox.Checked && !this.DetectedCheckBox.Checked)
            {
                MessageBox.Show(@"Выберите ранг ошибки", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                int alphabeticSize = int.Parse(this.AlphabeticLengthTextbox.Text);
                int rankDetect = 0;
                int rankFix = 0;
                if (this.DetectedCheckBox.Checked)
                    rankDetect = int.Parse(this.RankDetectedNumericUpDown.Text);
                if (this.FixCheckBox.Checked)
                    rankFix = int.Parse(this.RankFixNumericUpDown.Text);

                // запись в G в textbox
                this.GeneratingMatrixTextBox.Text =
                    this.linearGroupCodeLogic.GetGeneratingMatrix(alphabeticSize, rankDetect, rankFix).BinaryArrayToString(" ");

                this.ProcessDetectedTextBox.AppendText("Получение производящей матрицы.\n");
                this.ProcessDetectedTextBox.AppendText(this.linearGroupCodeLogic.ProcessDetected.AppendLine().ToString());
                this.ProcessDetectedTextBox.SelectionStart = this.ProcessDetectedTextBox.TextLength;
                this.linearGroupCodeLogic.ProcessDetected.Clear();

                this.GetVectorCodeButton.Enabled = true;
                this.DetectedAndCorrectErrorButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.linearGroupCodeLogic.ProcessDetected.Clear();
            }
        }

        // кодовый вектор
        private void GetVectorCodeButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.VectorCodeTextBox.Text =
                    this.linearGroupCodeLogic.GetVectorCode(this.SourceCodeTextBox.Text).ArrayToString();

                this.ProcessDetectedTextBox.AppendText("Получение кодового вектора.\n");
                this.ProcessDetectedTextBox.AppendText(this.linearGroupCodeLogic.ProcessDetected.AppendLine().ToString());
                this.ProcessDetectedTextBox.SelectionStart = this.ProcessDetectedTextBox.TextLength;
                this.linearGroupCodeLogic.ProcessDetected.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.linearGroupCodeLogic.ProcessDetected.Clear();
            }
        }

        // обнаружение одиночной ошибки
        private void DetectedAndCorrectErrorButtonClick(object sender, EventArgs e)
        {
            if (this.SendVectorTextBox.TextLength != this.RecivedVectorTextBox.TextLength)
            {
                MessageBox.Show(
                    @"Разная длина переданного и полученого сообщения", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // запись в структуру результата обнаружения
                var result = this.linearGroupCodeLogic.DetectedAndCorrectError(this.RecivedVectorTextBox.Text);

                this.SyndromTextBox.Text = result.Syndrome.ArrayToString();
                this.NumberErrorBitTextBox.Text = result.NumberErrorBit.ToString();
                this.CorrectRecivedVectorTextBox.Text = result.NumberErrorBit == 0 ? @"не нужна" : result.CorrectRecivedVector.ArrayToString();

                this.ProcessDetectedTextBox.AppendText("Обнаружение и исправление ошибок.\n");
                this.ProcessDetectedTextBox.AppendText(this.linearGroupCodeLogic.ProcessDetected.AppendLine().ToString());
                this.ProcessDetectedTextBox.SelectionStart = this.ProcessDetectedTextBox.TextLength;
                this.linearGroupCodeLogic.ProcessDetected.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.linearGroupCodeLogic.ProcessDetected.Clear();
            }
        }

        // отображение "консоли"
        private void ShowExecutionCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (this.ShowExecutionCheckBox.Checked)
            {
                this.Width = 753;
                this.ProcessDetectedTextBox.Visible = true;
                this.label11.Visible = true;
                this.ShowExecutionCheckBox.Text = @"<<";
            }
            else
            {
                this.Width = 473;
                this.ProcessDetectedTextBox.Visible = false;
                this.label11.Visible = false;
                this.ShowExecutionCheckBox.Text = @">>";
            }
        }

        // получение вектора (для переданного вектора, маленькая кнопочка)
        private void GetSendVectorButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.SendVectorTextBox.Text =
                    this.linearGroupCodeLogic.GetVectorCode(this.SendVectorTextBox.Text).ArrayToString();

                this.ProcessDetectedTextBox.AppendText("Получение кодового вектора.\n");
                this.ProcessDetectedTextBox.AppendText(this.linearGroupCodeLogic.ProcessDetected.AppendLine().ToString());
                this.ProcessDetectedTextBox.SelectionStart = this.ProcessDetectedTextBox.TextLength;
                this.linearGroupCodeLogic.ProcessDetected.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.linearGroupCodeLogic.ProcessDetected.Clear();
            }
        }

        private void SendVectorTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            this.GetSendVectorButton.Enabled = this.SendVectorTextBox.TextLength == LinearGroupCodeLogic.k;
        }

        // вводить 0 либо 1
        private void PressZeroOrOneKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 49) && e.KeyChar != 8)
                e.Handled = true;
        }

        // вводить только цифры
        private void AlphabeticLengthTextboxKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}