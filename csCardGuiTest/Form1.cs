using System.Configuration;
using csBasicDeck;
using IrrKlang;

namespace csCardGuiTest
{
    public partial class Form1 : Form
    {
        private const float DefaultMusicVolume = 0.25f;
        private string? chosenCardback;
        private readonly ISoundEngine soundEngine = new();
        private bool isSoundPaused = false;
        private readonly Size CardSize = new Size(135, 185);
        private const int CardLift = 20;
        public Form1()
        {
            InitializeComponent();
            ChooseCardbackSetting();
            BuildCards();
            //assign cardbacks and hide or reveal
            foreach (Control c in pnlOpponentCards.Controls)
            {
                if (c is CardPictureBox cpb)
                {
                    cpb.CardbackResourceName = chosenCardback;
                    cpb.RevealCard();
                }
            }
            foreach (Control c in pnlPlayerCards.Controls)
            {
                if (c is CardPictureBox cpb)
                {
                    cpb.CardbackResourceName = chosenCardback;
                    cpb.HideCard();
                }

            }
            RevealOpponentCards();
            LoadMusicFiles();
            AddWinCheckCallbacks();
        }

        /// <summary> Builds the cards used to play the game. </summary>
        private void BuildCards()
        {
            //build opponent cards
            for (int i = 0; i < OtherSettings.NumCardsInHand; i++)
            {
                pnlOpponentCards.Controls.Add(new CardPictureBox()
                {
                    Location = new(CardSize.Width * i, CardLift),
                    Size = CardSize,
                    Anchor = AnchorStyles.Left,
                    Padding = new(100),
                    Margin = new(100)
                });
            }

            //build player cards
            for (int i = 0; i < OtherSettings.NumCardsInHand; i++)
            {
                pnlPlayerCards.Controls.Add(new CardPictureBox()
                {
                    Location = new(CardSize.Width * i, CardLift),
                    Size = CardSize,
                    Anchor = AnchorStyles.Left,
                    Padding = new(100),
                    Margin = new(100)
                });
            }
        }

        /// <summary> Adds callbacks to each card on the container to check for all
        /// cards visible and time for scoring. </summary>
        private void AddWinCheckCallbacks()
        {
            foreach (Control c in pnlPlayerCards.Controls)
                if (c is CardPictureBox pb)
                    pb.OnClickCheckCustomEvent += (sender, args) => WinCheckHands();
        }

        /// <summary> Loads a list of music file paths from the musicdir,
        /// inits the audio engine. </summary>
        private void LoadMusicFiles()
        {
            List<string> musicList = MusicLoader.GetMusicInDir(OtherSettings.MusicDir);
            if (musicList.Count > 0)
            {
                soundEngine.SoundVolume = DefaultMusicVolume;
                trkbrAudioVolume.Value = (int)(DefaultMusicVolume*100);
                soundEngine.Play2D(musicList[0], true);
                //add to audio info textbox
                foreach (string s in musicList)
                {
                    this.tbxAudioInfo.Text += Path.GetFileName(s) + Environment.NewLine;
                }
            }
        }

        /// <summary> Reveals the 5 cards of the opponent's hand to the player. </summary>
        private void RevealOpponentCards()
        {
            //this.cardPictureBox1.RevealCard();
            //this.cardPictureBox2.RevealCard();
            //this.cardPictureBox3.RevealCard();
            //this.cardPictureBox4.RevealCard();
            //this.cardPictureBox5.RevealCard();
        }

        /// <summary> Assigns the cardback chosen value in chosenCardback to each CardPictureBox on the main form. </summary>
        private void AssignCardbacks(System.Windows.Forms.Control.ControlCollection cc)
        {
            foreach (Control c in cc)
            {
                if (c is CardPictureBox pb)
                {
                    pb.CardbackResourceName = chosenCardback ?? String.Empty;
                }
            }
        }

        /// <summary> Assigns a random cardback resource from the settings file to the data member chosenCardback. </summary>
        void ChooseCardbackSetting()
        {
            //potential error message strings
            const string NoConfigBody = "Config file error or not located, please check for App.config in the dir. ExtraInfo:";
            const string NoConfigTitle = "Configuration file error.";
            const string NoSettingsMessage = "Config file contains no settings!";
            try
            {
                //try reading settings
                var aps = ConfigurationManager.AppSettings;
                if (aps.Count == 0)
                    throw new ConfigurationErrorsException(NoSettingsMessage);
                //assign a random cardback
                Random r = new();
                int randVal = r.Next(0, aps.Count-1);
                chosenCardback = aps.Get(randVal) ?? string.Empty;
            }
            catch (ConfigurationErrorsException e)
            {
                MessageBox.Show(NoConfigBody + e.Message, NoConfigTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary> Event handler for the music volume track bar control. </summary>
        private void trkbrAudioVolume_ValueChanged(object sender, EventArgs e)
        {
            this.soundEngine.SoundVolume = trkbrAudioVolume.Value / 100.0f;
        }

        /// <summary> Event handler for the reveal all button's click event. </summary>
        private void btnRevealAll_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is CardPictureBox {IsRevealed: false} pb) 
                    pb.RevealCard();
            }
        }

        /// <summary> Event handler for play/pause button click, pauses or resumes playing the music. </summary>
        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            isSoundPaused = !isSoundPaused;
            soundEngine.SetAllSoundsPaused(isSoundPaused);
        }

        private void WinCheckHands()
        {
            //local func for checking if all are revealed
            bool AreAllRevealed()
            {
                bool b = true;
                //check for all cards revealed and winner
                foreach (Control c in this.Controls)
                {
                    if (c is CardPictureBox pb)
                    {
                        if (!pb.IsRevealed)
                        {
                            b = false;
                            break;
                        }
                    }
                }
                return b;
            }

            bool areAllRevealed = AreAllRevealed();
            //if all cards are face up, run scoring logic
            //if (areAllRevealed)
            //{
            //    PokerFiveCard pfc = new(OtherSettings.NumCardsInHand);
            //    BuildHands(out var opponentCards, out var playerCards);
            //    bool isOpponentFlush = pfc.IsFlush(opponentCards);
            //    bool isPlayerFlush = pfc.IsFlush(playerCards);
            //    //check for player scoring a flush, with no opponent flush
            //    if (isPlayerFlush && !isOpponentFlush)
            //    {
            //        RunPlayerWinMessage();
            //    }
            //    //tally up the scores otherwise...
            //    int opponentScore = 0;
            //    int playerScore = 0;
            //    foreach (Card opponentCard in opponentCards)
            //        opponentScore += opponentCard.IntegerValue;
            //    foreach (Card playerCard in playerCards)
            //        playerScore += playerCard.IntegerValue;
            //    if (opponentScore != playerScore)
            //    {
            //        Font bigFont = new(FontFamily.GenericMonospace, 26.0f);
            //        Color oppColor = opponentScore > playerScore ? Color.RebeccaPurple : Color.Black;
            //        Color playerColor = opponentScore < playerScore ? Color.RebeccaPurple : Color.Black;
            //        //lsvOpponentScores.Items.Add(opponentScore.ToString());
            //        //lsvOpponentScores.Items[^1].ForeColor = oppColor; // ^1 is called an index from end expression
            //        //lsvOpponentScores.Items[^1].Font = bigFont;
            //        //lsvPlayerScores.Items.Add(playerScore.ToString());
            //        //lsvPlayerScores.Items[^1].ForeColor = playerColor;
            //        //lsvPlayerScores.Items[^1].Font = bigFont;
            //    }
            //    else
            //    {
            //        //we have a tie
            //        Color bothColor = Color.Gold;
            //    }
            //}
        }

        //private void BuildHands(out List<Card> opponentCards, out List<Card> playerCards)
        //{
        //    //build hands
        //    opponentCards = new();
        //    opponentCards.Add(this.cardPictureBox1.CardElement);
        //    opponentCards.Add(this.cardPictureBox2.CardElement);
        //    opponentCards.Add(this.cardPictureBox3.CardElement);
        //    opponentCards.Add(this.cardPictureBox4.CardElement);
        //    opponentCards.Add(this.cardPictureBox5.CardElement);
        //    playerCards = new();
        //    playerCards.Add(this.cardPictureBox6.CardElement);
        //    playerCards.Add(this.cardPictureBox7.CardElement);
        //    playerCards.Add(this.cardPictureBox8.CardElement);
        //    playerCards.Add(this.cardPictureBox9.CardElement);
        //    playerCards.Add(this.cardPictureBox10.CardElement);
        //}

        private void RunPlayerWinMessage()
        {

        }
    }
}