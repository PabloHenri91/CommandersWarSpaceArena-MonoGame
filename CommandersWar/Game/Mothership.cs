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
    public class Mothership : SKSpriteNode
    {
        internal List<Spaceship> spaceships = new List<Spaceship>(4);

        public Mothership(Team team) : base("mothership")
        {
            switch (team)
            {
                case Team.blue:
                    color = GameColors.blueTeam;
                    position = new Vector2(0, 289);
                    break;
                case Team.red:
                    color = GameColors.redTeam;
                    position = new Vector2(0, -289);
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
            foreach (Spaceship spaceship in spaceships)
            {

            }
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

        public enum Team
        {
            red,
            green,
            blue
        }
    }
}
