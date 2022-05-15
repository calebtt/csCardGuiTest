namespace csCardGuiTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.cardPictureBox1 = new csCardGuiTest.CardPictureBox();
            this.cardPictureBox2 = new csCardGuiTest.CardPictureBox();
            this.cardPictureBox3 = new csCardGuiTest.CardPictureBox();
            this.cardPictureBox4 = new csCardGuiTest.CardPictureBox();
            this.cardPictureBox5 = new csCardGuiTest.CardPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(496, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // cardPictureBox1
            // 
            this.cardPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cardPictureBox1.IsActivated = false;
            this.cardPictureBox1.Location = new System.Drawing.Point(169, 23);
            this.cardPictureBox1.Name = "cardPictureBox1";
            this.cardPictureBox1.Size = new System.Drawing.Size(125, 200);
            this.cardPictureBox1.TabIndex = 5;
            this.cardPictureBox1.TabStop = false;
            this.cardPictureBox1.YPopupAdjust = 25;
            this.cardPictureBox1.Click += new System.EventHandler(this.pictureBox2_Click);
            this.cardPictureBox1.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.cardPictureBox1.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // cardPictureBox2
            // 
            this.cardPictureBox2.IsActivated = false;
            this.cardPictureBox2.Location = new System.Drawing.Point(38, 23);
            this.cardPictureBox2.Name = "cardPictureBox2";
            this.cardPictureBox2.Size = new System.Drawing.Size(125, 200);
            this.cardPictureBox2.TabIndex = 6;
            this.cardPictureBox2.TabStop = false;
            this.cardPictureBox2.YPopupAdjust = 25;
            // 
            // cardPictureBox3
            // 
            this.cardPictureBox3.IsActivated = false;
            this.cardPictureBox3.Location = new System.Drawing.Point(300, 23);
            this.cardPictureBox3.Name = "cardPictureBox3";
            this.cardPictureBox3.Size = new System.Drawing.Size(125, 200);
            this.cardPictureBox3.TabIndex = 7;
            this.cardPictureBox3.TabStop = false;
            this.cardPictureBox3.YPopupAdjust = 25;
            // 
            // cardPictureBox4
            // 
            this.cardPictureBox4.IsActivated = false;
            this.cardPictureBox4.Location = new System.Drawing.Point(431, 23);
            this.cardPictureBox4.Name = "cardPictureBox4";
            this.cardPictureBox4.Size = new System.Drawing.Size(125, 200);
            this.cardPictureBox4.TabIndex = 8;
            this.cardPictureBox4.TabStop = false;
            this.cardPictureBox4.YPopupAdjust = 25;
            // 
            // cardPictureBox5
            // 
            this.cardPictureBox5.IsActivated = false;
            this.cardPictureBox5.Location = new System.Drawing.Point(562, 23);
            this.cardPictureBox5.Name = "cardPictureBox5";
            this.cardPictureBox5.Size = new System.Drawing.Size(125, 200);
            this.cardPictureBox5.TabIndex = 9;
            this.cardPictureBox5.TabStop = false;
            this.cardPictureBox5.YPopupAdjust = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(726, 450);
            this.Controls.Add(this.cardPictureBox5);
            this.Controls.Add(this.cardPictureBox4);
            this.Controls.Add(this.cardPictureBox3);
            this.Controls.Add(this.cardPictureBox2);
            this.Controls.Add(this.cardPictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private CardPictureBox cardPictureBox1;
        private CardPictureBox cardPictureBox2;
        private CardPictureBox cardPictureBox3;
        private CardPictureBox cardPictureBox4;
        private CardPictureBox cardPictureBox5;
    }
}