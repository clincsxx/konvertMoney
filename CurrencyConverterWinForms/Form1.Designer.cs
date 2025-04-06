using System;
using System.Windows.Forms;

namespace CurrencyConverterWinForms
{
    partial class Form1
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
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.convertButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.fromCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.toCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сумма";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(28, 38);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 20);
            this.amountTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Из валюты";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "В валюту";
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(178, 106);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(104, 29);
            this.convertButton.TabIndex = 6;
            this.convertButton.Text = "Конвертировать";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(288, 114);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(35, 13);
            this.resultLabel.TabIndex = 7;
            this.resultLabel.Text = "label4";
            // 
            // fromCurrencyComboBox
            // 
            this.fromCurrencyComboBox.FormattingEnabled = true;
            this.fromCurrencyComboBox.Location = new System.Drawing.Point(28, 89);
            this.fromCurrencyComboBox.Name = "fromCurrencyComboBox";
            this.fromCurrencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.fromCurrencyComboBox.TabIndex = 8;
            // 
            // toCurrencyComboBox
            // 
            this.toCurrencyComboBox.FormattingEnabled = true;
            this.toCurrencyComboBox.Location = new System.Drawing.Point(28, 138);
            this.toCurrencyComboBox.Name = "toCurrencyComboBox";
            this.toCurrencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.toCurrencyComboBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toCurrencyComboBox);
            this.Controls.Add(this.fromCurrencyComboBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Конвертер валют";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.ComboBox fromCurrencyComboBox;
        private System.Windows.Forms.ComboBox toCurrencyComboBox;
    }
}
