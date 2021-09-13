namespace BGNtoEUR
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
            this.labelChange = new System.Windows.Forms.Label();
            this.labelBGNtoEUR = new System.Windows.Forms.Label();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.labelResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // labelChange
            // 
            this.labelChange.AutoSize = true;
            this.labelChange.Location = new System.Drawing.Point(13, 39);
            this.labelChange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChange.Name = "labelChange";
            this.labelChange.Size = new System.Drawing.Size(64, 20);
            this.labelChange.TabIndex = 0;
            this.labelChange.Text = "Convert";
            // 
            // labelBGNtoEUR
            // 
            this.labelBGNtoEUR.AutoSize = true;
            this.labelBGNtoEUR.Location = new System.Drawing.Point(248, 35);
            this.labelBGNtoEUR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBGNtoEUR.Name = "labelBGNtoEUR";
            this.labelBGNtoEUR.Size = new System.Drawing.Size(101, 20);
            this.labelBGNtoEUR.TabIndex = 1;
            this.labelBGNtoEUR.Text = "BGN to EUR";
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.DecimalPlaces = 2;
            this.numericUpDownAmount.Location = new System.Drawing.Point(85, 33);
            this.numericUpDownAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(146, 26);
            this.numericUpDownAmount.TabIndex = 2;
            this.numericUpDownAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAmount.ValueChanged += new System.EventHandler(this.numericUpDownAmount_ValueChanged);
            // 
            // labelResult
            // 
            this.labelResult.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelResult.Location = new System.Drawing.Point(13, 79);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(336, 33);
            this.labelResult.TabIndex = 3;
            this.labelResult.Text = "3500leva = 4800 evra";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 161);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.labelBGNtoEUR);
            this.Controls.Add(this.labelChange);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "BGN to EUR ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChange;
        private System.Windows.Forms.Label labelBGNtoEUR;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
        private System.Windows.Forms.Label labelResult;
    }
}

