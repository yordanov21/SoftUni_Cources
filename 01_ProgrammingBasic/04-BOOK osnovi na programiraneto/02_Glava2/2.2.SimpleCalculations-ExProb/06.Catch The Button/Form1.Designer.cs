﻿namespace _06.Catch_The_Button
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
            this.buttonCatheMe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCatheMe
            // 
            this.buttonCatheMe.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCatheMe.Location = new System.Drawing.Point(59, 124);
            this.buttonCatheMe.Name = "buttonCatheMe";
            this.buttonCatheMe.Size = new System.Drawing.Size(105, 70);
            this.buttonCatheMe.TabIndex = 1;
            this.buttonCatheMe.Text = "Catch Me!";
            this.buttonCatheMe.UseVisualStyleBackColor = true;
            this.buttonCatheMe.Click += new System.EventHandler(this.buttonCatheMe_Click);
            this.buttonCatheMe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonCatheMe_MouseClick);
            this.buttonCatheMe.MouseEnter += new System.EventHandler(this.buttonCatheMe_MouseEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 267);
            this.Controls.Add(this.buttonCatheMe);
            this.Name = "Form1";
            this.Text = "Catch the Button!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCatheMe;
    }
}

