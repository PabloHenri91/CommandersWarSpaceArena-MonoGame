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
    public class Spaceship : SKSpriteNode
    {
        SpaceshipData spaceshipData;

        Rarity rarity;

        public Spaceship(SpaceshipData spaceshipData, bool loadPhysics = false, Mothership.Team team = Mothership.Team.green) : base("")
        {
            this.spaceshipData = spaceshipData;
            rarity = (Rarity)spaceshipData.rarity;

            Color color = new Color(spaceshipData.colorRed, spaceshipData.colorGreen, spaceshipData.colorBlue);

            load(spaceshipData.level, 
                 spaceshipData.baseDamage,
                 spaceshipData.baseLife, 
                 spaceshipData.baseSpeed, 
                 spaceshipData.baseRange, 
                 spaceshipData.skin,
                 loadPhysics, 
                 team);
        }

        void load(int level, int baseDamage, int baseLife, int baseSpeed, int baseRange, int skinIndex, bool loadPhysics, Mothership.Team team)
        {
            this.level = level;
            battleStartLevel = level;
            this.skinIndex = skinIndex;
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
        private int level;
        private int battleStartLevel;
        private int skinIndex;

        internal static Color randomColor()
        {
            return Color.White;
        }

        public enum Rarity
        {
            common,
            uncommon,
            rare,
            heroic,
            epic,
            legendary,
            supreme
        }
    }
}
