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
    /// <summary>Uses free assets from Kenney boardgame pack, attribution not req. but appreciated.</summary>
    public partial class CardPictureBox : PictureBox
    {
        private const int YPopupDefault = 20;
        private const string PathToResources = "assets\\cards\\";
        private const string ImageExtension = ".png";
        private readonly Card representedCard;
        private int ypopup_adjust = YPopupDefault;
        private Rectangle originalRectangle;
        //the unholy mixture of gui logic and program logic
        //a bit of a value association between CardId and the static deck instance.
        private static csBasicDeck.BasicDeck deck = new();

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
        public bool IsActivated { get; set; } = false;
        public CardPictureBox()
        {
            InitializeComponent();
            YPopupAdjust = YPopupDefault;
            originalRectangle = this.ClientRectangle;
            representedCard = deck.RemoveFromTop();
        }

        public void HideCard()
        {

        }
        public void RevealCard()
        {
            LoadImageResourceByName(representedCard.ToString());
        }
        /// <summary>Takes the unaltered card name from the BasicDeck/Card classes and loads the appropriate background image for that card.</summary>
        private void LoadImageResourceByName(string name)
        {
            this.BackgroundImage = System.Drawing.Image.FromFile(PathToResources + name + ImageExtension);
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
    }
}
