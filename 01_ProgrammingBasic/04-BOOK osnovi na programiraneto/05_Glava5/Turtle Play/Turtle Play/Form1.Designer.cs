namespace Turtle_Play
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
            this.Draw = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.Hide_Turtle = new System.Windows.Forms.Button();
            this.Hexagon = new System.Windows.Forms.Button();
            this.Star = new System.Windows.Forms.Button();
            this.Spiral = new System.Windows.Forms.Button();
            this.Sun = new System.Windows.Forms.Button();
            this.Triangle = new System.Windows.Forms.Button();
            this.Cristmas_Tree = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Draw
            // 
            this.Draw.Location = new System.Drawing.Point(38, 37);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(116, 61);
            this.Draw.TabIndex = 0;
            this.Draw.Text = "Draw";
            this.Draw.UseVisualStyleBackColor = true;
            this.Draw.Click += new System.EventHandler(this.Draw_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(39, 105);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(114, 57);
            this.Reset.TabIndex = 1;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Hide_Turtle
            // 
            this.Hide_Turtle.Location = new System.Drawing.Point(41, 178);
            this.Hide_Turtle.Name = "Hide_Turtle";
            this.Hide_Turtle.Size = new System.Drawing.Size(111, 49);
            this.Hide_Turtle.TabIndex = 2;
            this.Hide_Turtle.Text = "Hide Turtle";
            this.Hide_Turtle.UseVisualStyleBackColor = true;
            this.Hide_Turtle.Click += new System.EventHandler(this.Hide_Turtle_Click);
            // 
            // Hexagon
            // 
            this.Hexagon.Location = new System.Drawing.Point(42, 247);
            this.Hexagon.Name = "Hexagon";
            this.Hexagon.Size = new System.Drawing.Size(109, 58);
            this.Hexagon.TabIndex = 3;
            this.Hexagon.Text = "Hexagon";
            this.Hexagon.UseVisualStyleBackColor = true;
            this.Hexagon.Click += new System.EventHandler(this.Hexagon_Click);
            // 
            // Star
            // 
            this.Star.Location = new System.Drawing.Point(41, 322);
            this.Star.Name = "Star";
            this.Star.Size = new System.Drawing.Size(110, 58);
            this.Star.TabIndex = 4;
            this.Star.Text = "Star";
            this.Star.UseVisualStyleBackColor = true;
            this.Star.Click += new System.EventHandler(this.Star_Click);
            // 
            // Spiral
            // 
            this.Spiral.Location = new System.Drawing.Point(43, 392);
            this.Spiral.Name = "Spiral";
            this.Spiral.Size = new System.Drawing.Size(109, 51);
            this.Spiral.TabIndex = 5;
            this.Spiral.Text = "Spiral";
            this.Spiral.UseVisualStyleBackColor = true;
            this.Spiral.Click += new System.EventHandler(this.Spiral_Click);
            // 
            // Sun
            // 
            this.Sun.Location = new System.Drawing.Point(44, 455);
            this.Sun.Name = "Sun";
            this.Sun.Size = new System.Drawing.Size(106, 55);
            this.Sun.TabIndex = 6;
            this.Sun.Text = "Sun";
            this.Sun.UseVisualStyleBackColor = true;
            this.Sun.Click += new System.EventHandler(this.Sun_Click);
            // 
            // Triangle
            // 
            this.Triangle.Location = new System.Drawing.Point(47, 521);
            this.Triangle.Name = "Triangle";
            this.Triangle.Size = new System.Drawing.Size(102, 50);
            this.Triangle.TabIndex = 7;
            this.Triangle.Text = "Triangle";
            this.Triangle.UseVisualStyleBackColor = true;
            this.Triangle.Click += new System.EventHandler(this.Triangle_Click);
            // 
            // Cristmas_Tree
            // 
            this.Cristmas_Tree.Location = new System.Drawing.Point(47, 583);
            this.Cristmas_Tree.Name = "Cristmas_Tree";
            this.Cristmas_Tree.Size = new System.Drawing.Size(101, 45);
            this.Cristmas_Tree.TabIndex = 8;
            this.Cristmas_Tree.Text = "Cristmas Tree";
            this.Cristmas_Tree.UseVisualStyleBackColor = true;
            this.Cristmas_Tree.Click += new System.EventHandler(this.Cristmas_Tree_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 666);
            this.Controls.Add(this.Cristmas_Tree);
            this.Controls.Add(this.Triangle);
            this.Controls.Add(this.Sun);
            this.Controls.Add(this.Spiral);
            this.Controls.Add(this.Star);
            this.Controls.Add(this.Hexagon);
            this.Controls.Add(this.Hide_Turtle);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Draw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Draw;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Hide_Turtle;
        private System.Windows.Forms.Button Hexagon;
        private System.Windows.Forms.Button Star;
        private System.Windows.Forms.Button Spiral;
        private System.Windows.Forms.Button Sun;
        private System.Windows.Forms.Button Triangle;
        private System.Windows.Forms.Button Cristmas_Tree;
    }
}

