using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using FarseerPhysics;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Dynamics;

using Hydra;


namespace CommandersWar.Game
{
    class Mothership : SKSpriteNode
    {
        Team team;

        internal List<Spaceship> spaceships = new List<Spaceship>(4);

        internal int maxHealth = 5800; // ???
        internal int health = 5800; // ???

        public Mothership(Team team) : base("mothership")
        {
            blendState = BlendState.Additive;

            this.team = team;

            switch (team)
            {
                case Team.blue:
                    color = GameColors.blueTeam;
                    position = new Vector2(0, 289);
                    break;
                case Team.red:
                    color = GameColors.redTeam;
                    position = new Vector2(0, -289);
                    zRotation = MathHelper.Pi;
                    break;
            }

            loadPhysics(size);
        }

        void loadPhysics(Vector2 size)
        {
            physicsBody = new SKPhysicsBody(size, ShapeType.Circle);
            physicsBody.BodyType = BodyType.Static;
            physicsBody.UserData = this;
        }

        internal void loadHealthBar(GameWorld gameWorld)
        {

        }

        internal void loadSpaceships(GameWorld gameWorld)
        {
            int i = 0;
            foreach (Spaceship spaceship in spaceships)
            {
                loadSpaceship(spaceship, gameWorld, i++);
            }
        }

        void loadSpaceship(Spaceship spaceship, GameWorld gameWorld, int i)
        {
            spaceship.team = team;

            Vector2 spaceshipPosition = Vector2.Zero;

            switch (i)
            {
                case 0:
                    spaceshipPosition = new Vector2(-129, 0);
                    break;
                case 1:
                    spaceshipPosition = new Vector2(-43, 0);
                    break;
                case 2:
                    spaceshipPosition = new Vector2(43, 0);
                    break;
                case 3:
                    spaceshipPosition = new Vector2(129, 0);
                    break;
            }

            SKSpriteNode spriteNode = new SKSpriteNode("mothershipSlot");
            spriteNode.position = spaceshipPosition;
            spriteNode.color = color;
            spriteNode.blendState = blendState;
            addChild(spriteNode);

            spaceship.position = spriteNode.positionInNode(gameWorld);
            spaceship.zRotation = zRotation;
            gameWorld.addChild(spaceship);

            spaceship.loadWeaponRangeShapeNode(gameWorld);
            spaceship.loadHealthBar(gameWorld);
            spaceship.loadLabelRespawn(gameWorld);
            spaceship.loadJetEffect(gameWorld);
            spaceship.loadSetDestinationEffect(gameWorld);

            spaceship.startingPosition = spaceship.position;

            spaceship.loadHealthBar();
        }

        internal void updateMaxHealth(List<Spaceship> spaceships)
        {
            foreach (Spaceship spaceship in spaceships)
            {

            }
        }

        internal override void removeFromParent()
        {
            base.removeFromParent();

            if (physicsBody != null)
            {
                physicsBody.UserData = null;
            }
        }

        internal void update(Mothership enemyMothership = null, IEnumerable<Spaceship> enemySpaceships = null)
        {
            foreach (Spaceship spaceship in spaceships)
            {
                spaceship.update(enemyMothership, enemySpaceships, spaceships);
            }
        }

        internal void updateHealthBar(int health, int maxHealth)
        {

        }

        internal void die()
        {

        }

        internal SKAction explosionAction()
        {
            return new SKAction(0);
        }

        internal void endBattle()
        {

        }

        public enum Team
        {
            red,
            green,
            blue
        }
    }
}
