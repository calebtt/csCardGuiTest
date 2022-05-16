using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csBasicDeck;

namespace csCardGuiTest
{
    /// <summary>Uses free assets from Kenney boardgame pack, attribution not req. but appreciated.
    /// Uses a static shared BasicDeck to draw cards from. </summary>
    public partial class CardPictureBox : PictureBox
    {
        private const int YPopupDefault = 20;
        private readonly Card representedCard;
        private int ypopup_adjust = YPopupDefault;
        private string? propCardbackResourceName;
        private Rectangle originalRectangle;
        //the unholy mixture of gui logic and program logic
        //a bit of a value association between CardId and the static deck instance.
        private static csBasicDeck.BasicDeck deck = new();

        //delegate for custom event
        public delegate void OnClickCheck(object sender, EventArgs e);
        //custom event
        public event OnClickCheck OnClickCheckCustomEvent;

        /// <summary> Popup Adjustment adjusts how much the card raises up when the user
        /// hovers over it. </summary>
        public int YPopupAdjust
        {
            get => ypopup_adjust;
            set
            {
                if (!IsActivated) 
                    ypopup_adjust = value;
                else
                    throw new Exception("Editing the YPopupAdjust now would be an error. IsActivated = true");
            }
        }
        /// <summary> IsActivated denotes whether or not the card is in the "Activated"
        /// position or in other words, being hovered over and "raised up" in Y. </summary>
        public bool IsActivated { get; set; } = false;

        /// <summary> IsRevealed denotes that the card's face value is currently being revealed. </summary>
        public bool IsRevealed { get; set; } = false;

        /// <summary> CardbackResourceName holds the name of the card back image resource. </summary>
        public string? CardbackResourceName
        {
            get
            {
                return propCardbackResourceName;
            }
            set
            {
                propCardbackResourceName = value;
                LoadImageResourceByName(value);
            }
        }

        /// <summary> CardValueResourceName holds the string value of the card image resource. </summary>
        public string CardValueResourceName => representedCard.StringValue;

        /// <summary> Getter property for Card info. </summary>
        public Card CardElement => representedCard;

        /// <summary> The CTOR will draw it's own card from the deck upon construction. If the deck runs out of cards,
        /// creating a new CardPictureBox will throw an exception. </summary>
        public CardPictureBox()
        {
            InitializeComponent();
            YPopupAdjust = YPopupDefault;
            originalRectangle = this.ClientRectangle;
            representedCard = deck.RemoveFromTop();
        }

        /// <summary> Called to replenish the cards in the shared deck. </summary>
        public static void BuildNewDeck()
        {
            deck.BuildNewDeck();
        }

        /// <summary> Replaces the image with either cardback resource, or null. </summary>
        public void HideCard()
        {
            IsRevealed = false;
            if (CardbackResourceName != null)
            {
                LoadImageResourceByName(CardbackResourceName);
            }
            else
            {
                this.BackgroundImage = null;
            }
        }

        /// <summary> Reveals the card's information and updates the graphic. </summary>
        public void RevealCard()
        {
            IsRevealed = true;
            LoadImageResourceByName(representedCard.ToString());
        }

        /// <summary>Takes the unaltered card name from the BasicDeck/Card classes and loads the appropriate background image for that card.</summary>
        private void LoadImageResourceByName(string? name)
        {
            if (name == null) return;
            this.BackgroundImage = System.Drawing.Image.FromFile(OtherSettings.CardDir + name + OtherSettings.CardExtensionString);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        /// <summary>Overriding these members of the base class is apparently the preferred way to handle
        /// these events in a derived class, as opposed to adding event handlers per the docs.</summary>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!IsActivated)
            {
                this.Location = new Point(this.Location.X, this.Location.Y - YPopupAdjust);
                this.IsActivated = true;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            //TODO make sure the mouse cursor is outside of the ORIGINAL rectangle of the card, not the adjusted one. and update the rectangle if the control is moved.
            if (IsActivated)
            {
                this.Location = new Point(this.Location.X, this.Location.Y + YPopupAdjust);
                this.IsActivated = false;
            }
        }

        /// <summary> Event handler for onclick event for this custom card control, will reveal
        /// the card. </summary>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if(!IsRevealed)
            {
                this.RevealCard();
            }
            //invoke our callback event
            OnClickCheckCustomEvent?.Invoke(this, e);
        }
    }
}
