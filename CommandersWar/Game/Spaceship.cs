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

using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Dynamics;

namespace CommandersWar.Game
{
    class Spaceship : SKSpriteNode
    {
        SpaceshipData spaceshipData;

        internal Element element;

        internal Mothership.Team team;
        Rarity rarity;

        int baseDamage;
        int baseLife;
        int baseSpeed;
        int baseRange;

        int damage;
        internal int maxHealth;
        int speedAtribute;
        internal int weaponRange;

        float maxVelocitySquared;
        float force;

        int level;
        int battleStartLevel;
        int skinIndex;

        internal int health = 1;

        internal Vector2 startingPosition;
        internal Vector2? destination;

        internal SpaceshipHealthBar healthBar;

        internal SKNode targetNode;

        internal bool retreating;

        public Spaceship(SpaceshipData spaceshipData,
                         bool loadPhysics = false,
                         Mothership.Team team = Mothership.Team.green) : base("")
        {
            this.team = team;

            this.spaceshipData = spaceshipData;

            rarity = (Rarity)spaceshipData.rarity;

            load(spaceshipData.level,
                 spaceshipData.baseDamage,
                 spaceshipData.baseLife,
                 spaceshipData.baseSpeed,
                 spaceshipData.baseRange,
                 spaceshipData.skin,
                 new Color(spaceshipData.colorRed, spaceshipData.colorGreen, spaceshipData.colorBlue),
                 loadPhysics);
        }

        internal void loadHealthBar()
        {
            healthBar = new SpaceshipHealthBar(level, health, team, rarity);
            healthBar.position = position;
            parent.addChild(healthBar);
            updateHealthBarPosition();
        }

        internal void updateHealthBarPosition()
        {
            if (healthBar == null) { return; }
            healthBar.position = position + healthBar.positionOffset;
        }

        public Spaceship(int level,
                         Rarity rarity,
                         bool loadPhysics = false,
                         Mothership.Team team = Mothership.Team.green,
                         Color? color = null) : base("")
        {
            this.team = team;

            this.rarity = rarity;

            load(level,
                 GameMath.randomBaseDamage(rarity),
                 GameMath.randomBaseLife(rarity),
                 GameMath.randomBaseSpeed(rarity),
                 GameMath.randomBaseRange(rarity),
                 random.Next(skins.Count()),
                 color ?? randomColor(),
                 loadPhysics);
        }

        void load(int someLevel,
                  int someBaseDamage,
                  int someBaseLife,
                  int someBaseSpeed,
                  int someBaseRange,
                  int someSkinIndex,
                  Color someColor,
                  bool forceLoadPhysics)
        {


            level = someLevel;
            battleStartLevel = someLevel;

            skinIndex = someSkinIndex;

            texture2D = SKScene.current.Texture2D(skins[skinIndex]);
            size = texture2D.Bounds.Size.ToVector2();
            setScaleToFit(Vector2.One * diameter);

            element = Element.types[elementFor(someColor)];

            color = someColor;
            blendState = BlendState.Additive;

            baseDamage = someBaseDamage;
            baseLife = someBaseLife;
            baseSpeed = someBaseSpeed;
            baseRange = someBaseRange;

            updateAttributes();

            health = maxHealth;

            if (forceLoadPhysics)
            {
                loadPhysics();
            }
        }

        void loadPhysics()
        {
            physicsBody = new SKPhysicsBody(size, ShapeType.Circle);

            physicsBody.Mass = 0.0455111116170883f;
            physicsBody.LinearDamping = 2.0f;
            physicsBody.AngularDamping = 5.0f;

            physicsBody.Restitution = 0.9f;

            physicsBody.BodyType = BodyType.Static;

            maxVelocitySquared = GameMath.spaceshipMaxVelocitySquared(speedAtribute);
            force = maxVelocitySquared / 240.0f;
        }

        internal void update(Mothership enemyMothership = null, IEnumerable<Spaceship> enemySpaceships = null, List<Spaceship> allySpaceships = null)
        {
            //enemySpaceships = enemySpaceships ?? new List<Spaceship>();
            //allySpaceships = allySpaceships ?? new List<Spaceship>();

            if (health > 0)
            {
                if (destination != null)
                {
                    if (position.distanceTo(destination.Value) <= diameter / 2.0f)
                    {
                        if (destination == startingPosition)
                        {
                            resetToStartingPosition();
                        }
                        destination = null;
                        fadeSetDestinationEffect();
                    }
                    else
                    {
                        rotateTo(destination.Value);
                        applyForce();
                    }
                }
            }
            else
            {

            }

            updateHealthBarPosition();
        }

        void resetToStartingPosition()
        {

        }

        void fadeSetDestinationEffect()
        {

        }

        void rotateTo(Vector2 destination)
        {

        }

        void applyForce()
        {
            
        }

        void updateAttributes()
        {
            maxHealth = GameMath.maxHealth(level, baseLife);
            damage = GameMath.damage(level, baseDamage);
            speedAtribute = GameMath.speed(level, baseSpeed);
            weaponRange = GameMath.range(level, baseRange);
        }

        internal void touchUp(Touch touch)
        {

        }

        internal void setTarget(Spaceship spaceship)
        {

        }

        internal void setTarget(Mothership mothership)
        {

        }

        internal void retreat()
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

            Element.Type elementType = elementFor(color);
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

        internal static Color randomColorFor(Element.Type someElement)
        {
            Color color = randomColor();

            if (elementFor(color) == someElement)
            {
                return color;
            }

            return randomColorFor(someElement);
        }

        internal static Color colorFor(Rarity rarity)
        {

            Color someColor = Color.Transparent;

            switch (rarity)
            {
                case Rarity.common:
                    someColor = GameColors.common;
                    break;
                case Rarity.uncommon:
                    someColor = GameColors.uncommon;
                    break;
                case Rarity.rare:
                    someColor = GameColors.rare;
                    break;
                case Rarity.heroic:
                    someColor = GameColors.heroic;
                    break;
                case Rarity.epic:
                    someColor = GameColors.epic;
                    break;
                case Rarity.legendary:
                    someColor = GameColors.legendary;
                    break;
                case Rarity.supreme:
                    someColor = GameColors.supreme;
                    break;
            }

            return someColor;
        }

        static Element.Type elementFor(Color color)
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

        internal static float diameter = 55.0f;

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
