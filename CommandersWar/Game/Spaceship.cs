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

        Mothership.Team team;
        Rarity rarity;

        int baseDamage;
        int baseLife;
        int baseSpeed;
        int baseRange;

        int maxHealth;
        int damage;
        int speedAtribute;
        int weaponRange;

        int level;
        int battleStartLevel;
        int skinIndex;

        public Spaceship(SpaceshipData spaceshipData, bool loadPhysics = false, Mothership.Team team = Mothership.Team.green) : base("")
        {
            this.spaceshipData = spaceshipData;

            rarity = (Rarity)spaceshipData.rarity;

            load(spaceshipData.level, 
                 spaceshipData.baseDamage,
                 spaceshipData.baseLife, 
                 spaceshipData.baseSpeed, 
                 spaceshipData.baseRange, 
                 spaceshipData.skin,
                 new Color(spaceshipData.colorRed, spaceshipData.colorGreen, spaceshipData.colorBlue),
                 loadPhysics, 
                 team);
        }

        void load(int level, 
                  int baseDamage,
                  int baseLife, 
                  int baseSpeed, 
                  int baseRange, 
                  int skinIndex, 
                  Color color, 
                  bool loadPhysics, 
                  Mothership.Team team)
        {
            this.level = level;

            this.baseDamage = baseDamage;
            this.baseLife = baseLife;
            this.baseSpeed = baseSpeed;
            this.baseRange = baseRange;

            battleStartLevel = level;

            this.skinIndex = skinIndex;

            texture2D = SKScene.current.Texture2D(skins[skinIndex]);
            size = texture2D.Bounds.Size.ToVector2();
            setScaleToFit(55, 55);

            this.color = color;
            blendState = BlendState.Additive;

            if (loadPhysics)
            {
                this.loadPhysics();
            }
        }

        void loadPhysics()
        {
            
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
            float red = (float)random.NextDouble();
            float green = (float)random.NextDouble();
            float blue = (float)random.NextDouble();

            Color color = new Color(red, green, blue);

            Element.Type elementType = element(color);
            Color elementTypeColor = Element.types[elementType].color;

            red = (red + elementTypeColor.R / 255.0f) / 2.0f;
            green = (green + elementTypeColor.G / 255.0f) / 2.0f;
            blue = (blue + elementTypeColor.B / 255.0f) / 2.0f;

            if (elementType != Element.Type.darkness)
            {
                float maxColor = 1.0f - Math.Max(Math.Max(red, green), blue);
                red = red + maxColor;
                green = green + maxColor;
                blue = blue + maxColor;
            }

            return new Color(red, green, blue);
        }

        internal static Color randomColor(Element.Type someElement) {
            Color color = randomColor();

            if (element(color) == someElement)
            {
                return color;
            }

            return randomColor(someElement);
        }

        static Element.Type element(Color color)
        {
            float red = color.R / 255.0f;
            float green = color.G / 255.0f;
            float blue = color.B / 255.0f;

            if (red > 0.5f == true && green > 0.5f == false && blue > 0.5f == false)
            {
                return Element.Type.fire;
            }
            if (red > 0.5f == false && green > 0.5f == true && blue > 0.5f == false)
            {
                return Element.Type.earth;
            }
            if (red > 0.5f == false && green > 0.5f == false && blue > 0.5f == true)
            {
                return Element.Type.water;
            }

            if (red > 0.5f == false && green > 0.5f == true && blue > 0.5f == true)
            {
                return Element.Type.ice;
            }
            if (red > 0.5f == true && green > 0.5f == false && blue > 0.5f == true)
            {
                return Element.Type.thunder;
            }
            if (red > 0.5f == true && green > 0.5f == true && blue > 0.5f == false)
            {
                return Element.Type.wind;
            }

            if (red > 0.5f == true && green > 0.5f == true && blue > 0.5f == true)
            {
                return Element.Type.light;
            }

            return Element.Type.darkness;
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
