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
    class Shot : SKSpriteNode
    {
        static List<Shot> list = new List<Shot>();

        internal Spaceship shooter;
        internal int damage;
        internal Element element;

        int rangeSquared;
        Vector2 startingPosition;
        SKEmitterNode emitterNode;

        public Shot(Spaceship shooter, Element element) : base("spark")
        {
            this.shooter = shooter;
            this.element = element;

            color = element.color;
            blendState = BlendState.Additive;

            damage = shooter.damage;
            rangeSquared = shooter.weaponRange * shooter.weaponRange;
            startingPosition = shooter.position;

            position = startingPosition;
            zRotation = shooter.zRotation;

            loadPhysics();
            loadEmitterNode();

            list.Add(this);
        }

        internal static void updateAll()
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                list[i].update();
            }
        }

        void update()
        {
            if ((position - startingPosition).LengthSquared() > rangeSquared)
            {
                removeFromParent();
            }
            else
            {
                emitterNode.position = position;
            }
        }




        void loadPhysics()
        {
            physicsBody = new SKPhysicsBody(size, ShapeType.Circle);

            physicsBody.LinearDamping = 0;
            physicsBody.AngularDamping = 0;

            float speed = 4.0f;

            physicsBody.LinearVelocity = new Vector2((float)(Math.Sin(zRotation) * speed), (float)(-Math.Cos(zRotation) * speed));

            if (shooter.physicsBody != null)
            {
                physicsBody.IgnoreCollisionWith(shooter.physicsBody);
                physicsBody.LinearVelocity += shooter.physicsBody.LinearVelocity;
            }

            physicsBody.OnCollision += PhysicsBody_OnCollision;

            physicsBody.UserData = this;
        }

        bool PhysicsBody_OnCollision(Fixture fixtureA, Fixture fixtureB, FarseerPhysics.Dynamics.Contacts.Contact contact)
        {
            Shot shot = (Shot)fixtureA.Body.UserData;

            if (fixtureB.Body.UserData is Mothership)
            {
                Mothership mothership = (Mothership)fixtureB.Body.UserData;
                mothership?.getHitBy(shot);
                return false;
            }

            if (fixtureB.Body.UserData is Spaceship)
            {
                Spaceship spaceship = (Spaceship)fixtureB.Body.UserData;
                spaceship?.getHitBy(shot);
                return false;
            }

            return false;
        }

        void loadEmitterNode()
        {
            emitterNode = new SKEmitterNode(60);
            emitterNode.texture2D = SKScene.current.Texture2D("spark8x8");
            //emitterNode.particleSize = new Vector2(8, 8);
            emitterNode.particleBirthRate = 60.0f;
            emitterNode.particleLifetime = 1.0f;
            emitterNode.particleAlpha = 1.0f;
            emitterNode.particleAlphaSpeed = -4.0f;
            emitterNode.particleScale = 1.0f;
            emitterNode.particleScaleSpeed = -1.0f;
            emitterNode.particleColorBlendFactor = 1.0f;
            emitterNode.particleColor = color;

            emitterNode.particleBlendMode = BlendState.Additive;

            emitterNode.particlePositionRange = new Vector2(8.0f, 8.0f);

            shooter.parent.addChild(emitterNode);

            update();
        }

        internal override void removeFromParent()
        {
            base.removeFromParent();

            if (damage <= 0)
            {
                explosionEffect();
            }

            list.Remove(this);
            shooter.canShoot = true;

            emitterNode.particleBirthRate = 0;
            emitterNode.run(SKAction.sequence(new[] { // TODO: SKAction.removeFromParentAfterDelay(1.0f)
                SKAction.waitForDuration(1.0f),
                SKAction.removeFromParent()
            }));
        }

        void explosionEffect()
        {

        }
    }
}
