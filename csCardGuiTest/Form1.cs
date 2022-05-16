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
        private bool isGameScoredAlready = false;
        public Form1()
        {
            InitializeComponent();
            ChooseCardbackSetting();
            BuildCards();
            //assign cardbacks and hide or reveal
            AssignCardbacks();
            LoadMusicFiles();
            AddWinCheckCallbacks();
        }

        //assign cardbacks and hide or reveal
        private void AssignCardbacks()
        {
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

        /// <summary> Clears the cards on the board. </summary>
        private void ClearCards()
        {
            pnlPlayerCards.Controls.Clear();
            pnlOpponentCards.Controls.Clear();
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
            WinCheckHands();
            foreach (Control c in pnlPlayerCards.Controls)
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
            //local func for updating the score boxes
            void UpdateScoreBox(int opponentScore, Color oppColor, int playerScore, Color playerColor)
            {
                Font bigFont = new(FontFamily.GenericMonospace, 12.0f);
                listView1.Items.Add(opponentScore.ToString());
                listView1.Items[^1].ForeColor = oppColor; // ^1 is called an index from end expression
                listView1.Items[^1].Font = bigFont;
                listView2.Items.Add(playerScore.ToString());
                listView2.Items[^1].ForeColor = playerColor;
                listView2.Items[^1].Font = bigFont;
            }

            //local func for checking if all are revealed
            bool AreAllRevealed()
            {
                bool b = true;
                //check for all cards revealed
                foreach (Control c in pnlPlayerCards.Controls)
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
            if (!areAllRevealed)
                isGameScoredAlready = false;
            //if all cards are face up, run scoring logic
            if (areAllRevealed && !isGameScoredAlready)
            {
                PokerFiveCard pfc = new(OtherSettings.NumCardsInHand);
                BuildHands(out var opponentCards, out var playerCards);
                bool isOpponentFlush = pfc.IsFlush(opponentCards);
                bool isPlayerFlush = pfc.IsFlush(playerCards);
                //check for player scoring a flush, with no opponent flush
                if (isPlayerFlush && !isOpponentFlush)
                {
                    RunPlayerWinMessage();
                }
                //tally up the scores otherwise...
                int opponentScore = 0;
                int playerScore = 0;
                foreach (Card opponentCard in opponentCards)
                    opponentScore += opponentCard.IntegerValue;
                foreach (Card playerCard in playerCards)
                    playerScore += playerCard.IntegerValue;
                if (opponentScore != playerScore)
                {
                    Color oppColor = opponentScore > playerScore ? Color.RebeccaPurple : Color.Black;
                    Color playerColor = opponentScore < playerScore ? Color.RebeccaPurple : Color.Black;
                    UpdateScoreBox(opponentScore, oppColor, playerScore, playerColor);
                }
                else
                {
                    //we have a tie
                    Color bothColor = Color.Gold;
                    UpdateScoreBox(opponentScore, bothColor, playerScore, bothColor);
                }

                isGameScoredAlready = true;
            }
        }

        /// <summary> Builds the lists of cards for each hand. </summary>
        /// <param name="opponentCards"></param>
        /// <param name="playerCards"></param>
        private void BuildHands(out List<Card> opponentCards, out List<Card> playerCards)
        {
            opponentCards = new();
            playerCards = new();
            foreach (Control pc in pnlPlayerCards.Controls)
            {
                if (pc is CardPictureBox cpb)
                {
                    playerCards.Add(cpb.CardElement);
                }
            }
            foreach (Control pc in pnlOpponentCards.Controls)
            {
                if (pc is CardPictureBox cpb)
                {
                    opponentCards.Add(cpb.CardElement);
                }
            }
        }
        private void RunPlayerWinMessage()
        {
            MessageBox.Show("WINNER! Flush on player cards!", "Flush, takes the game.");
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            //reset game
            if (isGameScoredAlready)
            {
                ClearCards();
                BuildCards();
                AssignCardbacks();
                AddWinCheckCallbacks();
                WinCheckHands();
            }
        }
    }
}