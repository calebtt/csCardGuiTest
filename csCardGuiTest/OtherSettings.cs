using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csCardGuiTest
{
    /// <summary> Contains other settings that are intended to be less
    /// user configurable than the ones in App.config </summary>
    internal static class OtherSettings
    {
        public const string MusicDir = "assets\\music\\";
        public const string CardDir = "assets\\cards\\";
        public const string CardExtensionString = ".png";
        public const string BackgroundMusicAsset = "music.ogg";
        public const int NumCardsInHand = 5;
    }
}
