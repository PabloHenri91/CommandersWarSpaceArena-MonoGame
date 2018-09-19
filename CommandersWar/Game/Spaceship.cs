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
using Hydra.Scenes;

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
        internal bool canRespawn;

        SKShapeNode weaponRangeShapeNode;
        SKSpriteNode destinationEffectSpriteNode;

        int emitterNodeParticleBirthRate;
        float lastSecond;
        float deathTime;
        int deaths;
        Label labelRespawn;
        float totalRotationToDestination;
        int defaultEmitterNodeParticleBirthRate;
        float rotationToDestination;
        float maxAngularVelocity = 3.0f;
        float angularImpulse = 0.005f;

        public Spaceship(SpaceshipData spaceshipData, bool loadPhysics = false, Mothership.Team team = Mothership.Team.green) : base("")
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

        void updateWeaponRangeShapeNode()
        {
            if (weaponRangeShapeNode == null) { return; }

            if (health <= 0)
            {
                weaponRangeShapeNode.alpha = 0.0f;
            }
            else
            {
                weaponRangeShapeNode.position = position;

                if (this != selectedSpaceship && weaponRangeShapeNode.alpha > 0.0f)
                {
                    weaponRangeShapeNode.alpha -= 0.06666666667f;
                }
            }
        }

        internal void updateHealthBarPosition()
        {
            if (healthBar == null) { return; }
            healthBar.position = position + healthBar.positionOffset;
        }

        public Spaceship(int level, Rarity rarity, bool loadPhysics = false, Mothership.Team team = Mothership.Team.green, Color? color = null) : base("")
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

        void load(int someLevel, int someBaseDamage, int someBaseLife, int someBaseSpeed, int someBaseRange, int someSkinIndex, Color someColor, bool forceLoadPhysics)
        {
            level = someLevel;
            battleStartLevel = someLevel;

            skinIndex = someSkinIndex;

            texture2D = SKScene.current.Texture2D(skins[skinIndex]);
            size = texture2D.Bounds.Size.ToVector2();
            setScaleToFit(Vector2.One * radius * 2.0f);

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
            force = maxVelocitySquared / 24000.0f;
        }

        internal void loadSetDestinationEffect(GameWorld gameWorld)
        {
            var spriteNode = new SKSpriteNode("Define Location");
            spriteNode.scale = Vector2.One * 0.75f;
            spriteNode.color = color;
            spriteNode.blendState = BlendState.Additive;
            spriteNode.alpha = 0.0f;
            gameWorld.addChild(spriteNode);
            destinationEffectSpriteNode = spriteNode;
        }

        void setDestinationEffect()
        {
            if (team != Mothership.Team.blue ||
                destination == null ||
                destinationEffectSpriteNode == null)
            {
                return;
            }

            destinationEffectSpriteNode.removeAllActions();
            destinationEffectSpriteNode.alpha = 1.0f;
            destinationEffectSpriteNode.position = destination.Value;
        }

        internal void fadeSetDestinationEffect()
        {
            if (team != Mothership.Team.blue ||
                destinationEffectSpriteNode == null)
            {
                return;
            }

            destinationEffectSpriteNode.run(SKAction.fadeAlphaTo(0.0f, 0.5f));
        }

        internal void loadJetEffect(SKNode gameWorld)
        {

        }

        internal void loadLabelRespawn(SKNode gameWorld)
        {

        }

        internal void loadHealthBar()
        {
            healthBar = new SpaceshipHealthBar(level, health, team, rarity);
            healthBar.position = position;
            parent.addChild(healthBar);
            updateHealthBarPosition();
        }

        internal void loadWeaponRangeShapeNode(GameWorld gameWorld)
        {
            SKShapeNode shapeNode = new SKShapeNode(weaponRange);
            shapeNode.position = position;
            shapeNode.alpha = 0.0f;
            gameWorld.addChild(shapeNode);

            weaponRangeShapeNode = shapeNode;
        }

        internal void update(Mothership enemyMothership = null, IEnumerable<Spaceship> enemySpaceships = null, List<Spaceship> allySpaceships = null)
        {
            emitterNodeParticleBirthRate = 0;

            if (health > 0)
            {
                if (destination != null)
                {
                    if (position.distanceTo(destination.Value) <= radius)
                    {
                        if (destination.Value == startingPosition)
                        {
                            resetToStartingPosition();
                        }
                        else
                        {
                            updateBitMasks();
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
                else
                {
                    if (physicsBody != null)
                    {
                        if (physicsBody.BodyType != BodyType.Dynamic)
                        {
                            if ((position - startingPosition).LengthSquared() < 4.0f)
                            {
                                heal();
                            }
                            if (physicsBody.BodyType == BodyType.Dynamic)
                            {
                                rotateTo(new Vector2(position.X, 0));
                                applyForce();
                            }
                        }
                        else
                        {

                            if (targetNode != null)
                            {

                                if (targetNode is Spaceship)
                                {
                                    Spaceship targetSpaceship = (Spaceship)targetNode;
                                    if (targetSpaceship.health <= 0)
                                    {
                                        targetNode = null;
                                    }
                                    else
                                    {
                                        if ((targetSpaceship.position - targetSpaceship.startingPosition).LengthSquared() < 4)
                                        {
                                            targetNode = null;
                                        }
                                        else
                                        {
                                            rotateTo(targetSpaceship.position);

                                            if (position.distanceTo(targetSpaceship.position) > weaponRange + radius)
                                            {
                                                applyForce();
                                            }
                                            else
                                            {
                                                tryToShoot();
                                            }
                                        }
                                    }
                                }

                                if (targetNode is Mothership)
                                {
                                    Mothership targetMothership = (Mothership)targetNode;
                                    if (targetMothership.health <= 0)
                                    {
                                        targetNode = null;
                                    }
                                    else
                                    {
                                        var point = new Vector2(position.X, targetMothership.position.Y);
                                        rotateTo(point);

                                        if (position.distanceTo(point) > weaponRange + 89 / 2)
                                        {
                                            applyForce();
                                        }
                                        else
                                        {
                                            tryToShoot();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Spaceship someTargetNode = nearestSpaceshipInRange(enemySpaceships);
                                if (someTargetNode != null)
                                {
                                    setTarget(someTargetNode);
                                }
                                else
                                {
                                    if (enemyMothership != null)
                                    {
                                        if (isMothershipInRange(enemyMothership))
                                        {
                                            setTarget(enemyMothership);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (canRespawn)
                {
                    if (SKScene.currentTime - lastSecond > 1.0)
                    {
                        lastSecond = SKScene.currentTime;

                        if (SKScene.currentTime - deathTime > (deaths * (rarity.GetHashCode() + 1)))
                        {
                            respawn();
                        }
                        else
                        {
                            if (labelRespawn != null)
                            {
                                Label label = labelRespawn;
                                int text = (deaths * (rarity.GetHashCode() + 1)) - (int)(SKScene.currentTime - deathTime);
                                label.text = $"{text}";
                            }
                        }
                    }
                }
            }

            updateWeaponRangeShapeNode();
            updateHealthBarPosition();
        }

        Spaceship nearestSpaceshipInRange(IEnumerable<Spaceship> enemySpaceships)
        {
            return null;
        }

        void respawn()
        {

        }

        bool isMothershipInRange(Mothership enemyMothership)
        {
            return false;
        }

        void tryToShoot()
        {

        }

        void heal()
        {

        }

        void updateBitMasks()
        {

        }

        void resetToStartingPosition()
        {

        }

        void rotateTo(Vector2 point)
        {
            if (physicsBody != null)
            {
                float dx = point.X - position.X;
                float dy = point.Y - position.Y;

                rotationToDestination = -(float)Math.Atan2(dx, dy) + (float)Math.PI;


                if (Math.Abs(physicsBody.AngularVelocity) < maxAngularVelocity)
                {
                    totalRotationToDestination = rotationToDestination - zRotation;

                    while (totalRotationToDestination < -Math.PI) { totalRotationToDestination += (float)Math.PI * 2.0f; }
                    while (totalRotationToDestination > Math.PI) { totalRotationToDestination -= (float)Math.PI * 2.0f; }

                    physicsBody.ApplyAngularImpulse(totalRotationToDestination * angularImpulse);
                }
            }
        }

        void applyForce()
        {
            var absTotalRotationToDestination = Math.Abs(totalRotationToDestination * 2.0f);
            var multiplier = Math.Max(1 - absTotalRotationToDestination, 0);

            if (multiplier > 0.0f)
            {
                if (physicsBody != null)
                {
                    var velocitySquared = (physicsBody.LinearVelocity.X * physicsBody.LinearVelocity.X) + (physicsBody.LinearVelocity.X * physicsBody.LinearVelocity.Y);

                    if (velocitySquared < maxVelocitySquared)
                    {
                        physicsBody.ApplyForce(new Vector2((float)(Math.Sin(zRotation) * force * multiplier), (float)(-Math.Cos(zRotation) * force * multiplier)));
                    }
                    emitterNodeParticleBirthRate = defaultEmitterNodeParticleBirthRate;
                }
            }
        }

        void updateAttributes()
        {
            maxHealth = GameMath.maxHealth(level, baseLife);
            damage = GameMath.damage(level, baseDamage);
            speedAtribute = GameMath.speed(level, baseSpeed);
            weaponRange = GameMath.range(level, baseRange);
        }

        void showWeaponRangeShapeNode()
        {
            weaponRangeShapeNode.alpha = 1.0f;
        }

        internal void touchUp(Touch touch)
        {
            if (parent == null)
            {
                return;
            }

            Vector2 point = touch.locationIn(parent);

            if (this == selectedSpaceship)
            {
                targetNode = null;

                if (contains(point))
                {
                    if (destination != null)
                    {
                        fadeSetDestinationEffect();
                    }
                }
                else
                {
                    physicsBody.BodyType = BodyType.Dynamic;
                    destination = point;
                    setDestinationEffect();
                }
            }
            else if (contains(point))
            {
                setSelected(this);
            }

        }

        internal override bool contains(Vector2 somePosition)
        {
            return position.distanceTo(somePosition) <= radius;
        }

        internal void setTarget(Spaceship spaceship)
        {
            fadeSetDestinationEffect();
        }

        internal void setTarget(Mothership mothership)
        {
            fadeSetDestinationEffect();
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

        static void setSelected(Spaceship spaceship)
        {
            selectedSpaceship = spaceship;
            spaceship?.showWeaponRangeShapeNode();
        }

        internal static float radius = 55.0f / 2.0f;

        internal static Spaceship selectedSpaceship;

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
