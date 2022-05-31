using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using MyGame.Model;

namespace MyGame.View
{
    public static class ViewGraphics
    {
        public static int SpriteRectangleSize = 32;
        public static int ArtillerySpriteHeight = 100;
        public static int ArtillerySpriteWidth = 60;
        public static int ExplosiveSpriteRectangleSize = 60;
        public static Image FriendlyUnitSprite = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\AllySoldierSpriteSheet.png"));
        public static Image AllyGunnerSpriteList = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\AllyGunnerSpriteList.png"));
        public static Image EnemyUnitSprite = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\EnemySoldierSpriteSheet.png"));
        public static Image LittleRiflemanSquadImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\LittleRiflemanSqad.png"));
        public static Image LittleGunnerSquadImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\LittleGunnerSqad.png"));
        public static Image MiddleRiflemanSquadImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\MiddleRiflemanSqad.png"));
        public static Image LargeRiflemanSquadImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\LargeRiflemanSqad.png"));
        public static Image MoneyImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\Money.png"));
        public static Image DocumentsImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\Documents.png"));
        public static Image AttackButtonImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\Attack.png"));
        public static Image FallBackButtonImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\FallBack.png"));
        public static Image ToMainTrenchImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\ToMainTrench.png"));
        public static Image XPosChangeImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\XPosChange.png"));
        public static Image ExplosiveSpriteSheet = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\ExplosiveSheet.png"));
        public static Image ArtillerySpriteSheet = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\ArtillerySpriteSheett.png"));
        public static Image ArtilleryOneShoot = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\ArtilleryShoot.png"));
        public static Image ArtilleryThreeShoots = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\ArtilleryShoots.png"));
        public static Image LargeGunnerSquad = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\LargeGunnerSqad.png"));
        public static Image SecondFormImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\SecondForm.png"));
        public static Image PlayButtonImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\PlayButton.png"));
        public static Image StudingButtonImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\StudingButton.png"));
        public static Image SettingsButtonImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\SettingsButton.png"));
        public static Image TrainingButtonImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\TrainingButton.png"));
        public static Image BackButtonImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\BackButton.png"));
        public static Image MovieButtonImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\Movie.png"));
        public static Image LittleBackButtonImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\LittleBackButton.png"));
        public static Image AdvancedImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\AdvancedButton.png"));
        public static Image SimpleImage = new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\SimpleButton.png"));
        public static string FullVideo = Path.Combine(Interface.CurrentDirectory, "Sprites\\FullVersion.wmv");
        public static string WinVideo = Path.Combine(Interface.CurrentDirectory, "Sprites\\Win.mp4");
        public static string LostVideo = Path.Combine(Interface.CurrentDirectory, "Sprites\\NotWin.mp4");

        public static Image[] Slides =
        {
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\M1.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\M2.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\M3.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\S1.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\S2.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G1.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G2.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G3.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G4.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G5.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G6.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G7.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G8.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G9.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G10.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G11.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G12.png")),
            new Bitmap(Path.Combine(Interface.CurrentDirectory, "Sprites\\G13.png"))
    };
    }
}
