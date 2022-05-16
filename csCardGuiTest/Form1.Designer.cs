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
            this.lblRevealCardsMessage = new System.Windows.Forms.Label();
            this.btnRevealAll = new System.Windows.Forms.Button();
            this.grpbxAudioControls = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.tbxAudioInfo = new System.Windows.Forms.TextBox();
            this.trkbrAudioVolume = new System.Windows.Forms.TrackBar();
            this.pnlScoring = new System.Windows.Forms.Panel();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.lblOpponentScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPlayerCards = new System.Windows.Forms.Panel();
            this.pnlOpponentCards = new System.Windows.Forms.Panel();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.grpbxAudioControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkbrAudioVolume)).BeginInit();
            this.pnlScoring.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRevealCardsMessage
            // 
            this.lblRevealCardsMessage.AutoSize = true;
            this.lblRevealCardsMessage.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRevealCardsMessage.Location = new System.Drawing.Point(722, 463);
            this.lblRevealCardsMessage.Name = "lblRevealCardsMessage";
            this.lblRevealCardsMessage.Size = new System.Drawing.Size(278, 24);
            this.lblRevealCardsMessage.TabIndex = 4;
            this.lblRevealCardsMessage.Text = "Click To Reveal Your Cards!";
            // 
            // btnRevealAll
            // 
            this.btnRevealAll.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRevealAll.Location = new System.Drawing.Point(732, 412);
            this.btnRevealAll.Name = "btnRevealAll";
            this.btnRevealAll.Size = new System.Drawing.Size(121, 46);
            this.btnRevealAll.TabIndex = 15;
            this.btnRevealAll.Text = "Reveal All";
            this.btnRevealAll.UseVisualStyleBackColor = true;
            this.btnRevealAll.Click += new System.EventHandler(this.btnRevealAll_Click);
            // 
            // grpbxAudioControls
            // 
            this.grpbxAudioControls.BackColor = System.Drawing.Color.CadetBlue;
            this.grpbxAudioControls.Controls.Add(this.button3);
            this.grpbxAudioControls.Controls.Add(this.button2);
            this.grpbxAudioControls.Controls.Add(this.btnPlayPause);
            this.grpbxAudioControls.Controls.Add(this.tbxAudioInfo);
            this.grpbxAudioControls.Controls.Add(this.trkbrAudioVolume);
            this.grpbxAudioControls.Location = new System.Drawing.Point(732, 23);
            this.grpbxAudioControls.Name = "grpbxAudioControls";
            this.grpbxAudioControls.Size = new System.Drawing.Size(259, 163);
            this.grpbxAudioControls.TabIndex = 16;
            this.grpbxAudioControls.TabStop = false;
            this.grpbxAudioControls.Text = "Audio";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(159, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 26);
            this.button3.TabIndex = 4;
            this.button3.Text = "Previous";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(109, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "Next";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Location = new System.Drawing.Point(29, 22);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(74, 26);
            this.btnPlayPause.TabIndex = 2;
            this.btnPlayPause.Text = "Play/Pause";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // tbxAudioInfo
            // 
            this.tbxAudioInfo.BackColor = System.Drawing.Color.Silver;
            this.tbxAudioInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAudioInfo.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.tbxAudioInfo.Location = new System.Drawing.Point(6, 91);
            this.tbxAudioInfo.Multiline = true;
            this.tbxAudioInfo.Name = "tbxAudioInfo";
            this.tbxAudioInfo.ReadOnly = true;
            this.tbxAudioInfo.Size = new System.Drawing.Size(247, 55);
            this.tbxAudioInfo.TabIndex = 1;
            // 
            // trkbrAudioVolume
            // 
            this.trkbrAudioVolume.Location = new System.Drawing.Point(6, 54);
            this.trkbrAudioVolume.Maximum = 100;
            this.trkbrAudioVolume.Name = "trkbrAudioVolume";
            this.trkbrAudioVolume.Size = new System.Drawing.Size(247, 45);
            this.trkbrAudioVolume.TabIndex = 0;
            this.trkbrAudioVolume.ValueChanged += new System.EventHandler(this.trkbrAudioVolume_ValueChanged);
            // 
            // pnlScoring
            // 
            this.pnlScoring.Controls.Add(this.listView2);
            this.pnlScoring.Controls.Add(this.listView1);
            this.pnlScoring.Controls.Add(this.lblPlayerScore);
            this.pnlScoring.Controls.Add(this.lblOpponentScore);
            this.pnlScoring.Location = new System.Drawing.Point(732, 192);
            this.pnlScoring.Name = "pnlScoring";
            this.pnlScoring.Size = new System.Drawing.Size(259, 214);
            this.pnlScoring.TabIndex = 17;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(132, 39);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(121, 172);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(6, 39);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 172);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // lblPlayerScore
            // 
            this.lblPlayerScore.AutoSize = true;
            this.lblPlayerScore.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerScore.Location = new System.Drawing.Point(144, 9);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(91, 27);
            this.lblPlayerScore.TabIndex = 1;
            this.lblPlayerScore.Text = "Player";
            // 
            // lblOpponentScore
            // 
            this.lblOpponentScore.AutoSize = true;
            this.lblOpponentScore.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOpponentScore.Location = new System.Drawing.Point(6, 9);
            this.lblOpponentScore.Name = "lblOpponentScore";
            this.lblOpponentScore.Size = new System.Drawing.Size(121, 27);
            this.lblOpponentScore.TabIndex = 0;
            this.lblOpponentScore.Text = "Opponent";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Magneto", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(129, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 28);
            this.label1.TabIndex = 18;
            this.label1.Text = "Click Below To Reveal Your Cards";
            // 
            // pnlPlayerCards
            // 
            this.pnlPlayerCards.Location = new System.Drawing.Point(27, 271);
            this.pnlPlayerCards.Name = "pnlPlayerCards";
            this.pnlPlayerCards.Size = new System.Drawing.Size(674, 214);
            this.pnlPlayerCards.TabIndex = 19;
            // 
            // pnlOpponentCards
            // 
            this.pnlOpponentCards.Location = new System.Drawing.Point(27, 23);
            this.pnlOpponentCards.Name = "pnlOpponentCards";
            this.pnlOpponentCards.Size = new System.Drawing.Size(674, 214);
            this.pnlOpponentCards.TabIndex = 20;
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPlayAgain.Location = new System.Drawing.Point(864, 412);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(121, 46);
            this.btnPlayAgain.TabIndex = 21;
            this.btnPlayAgain.Text = "Play Again";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1012, 497);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.pnlOpponentCards);
            this.Controls.Add(this.pnlPlayerCards);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlScoring);
            this.Controls.Add(this.grpbxAudioControls);
            this.Controls.Add(this.btnRevealAll);
            this.Controls.Add(this.lblRevealCardsMessage);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "csCardGuiTest";
            this.grpbxAudioControls.ResumeLayout(false);
            this.grpbxAudioControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkbrAudioVolume)).EndInit();
            this.pnlScoring.ResumeLayout(false);
            this.pnlScoring.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblRevealCardsMessage;
        private Button btnRevealAll;
        private GroupBox grpbxAudioControls;
        private TrackBar trkbrAudioVolume;
        private TextBox tbxAudioInfo;
        private Button btnPlayPause;
        private Button button2;
        private Button button3;
        private Panel pnlScoring;
        private Label lblPlayerScore;
        private Label lblOpponentScore;
        private Label label1;
        private Panel pnlPlayerCards;
        private Panel pnlOpponentCards;
        private ListView listView2;
        private ListView listView1;
        private Button btnPlayAgain;
    }
}