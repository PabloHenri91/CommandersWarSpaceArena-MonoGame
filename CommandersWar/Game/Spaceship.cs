using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Hydra;

namespace CommandersWar.Game
{
    public class Spaceship : SKNode
    {
        public Spaceship(SpaceshipData spaceshipData)
        {
        }

        public enum rarity
        {
            common,
            uncommon,
            rare,
            heroic,
            epic,
            legendary,
            supreme
        }

        internal static string[] skins = {
            "spaceship00",
            "spaceship01",
            "spaceship02",
            "spaceship03",
            "spaceship04",
            "spaceship05",
            "spaceship06",
            "spaceship07",
            "spaceship08",
            "spaceship09",
            "spaceship10",
            "spaceship11",
            "spaceship12",
            "spaceship13",
            "spaceship14",
            "spaceship15",
            "spaceship16"
        };

        internal static Color randomColor()
        {
            return Color.Black;
        }
    }
}
