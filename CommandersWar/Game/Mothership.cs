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
            physicsBody.IsStatic = true;
        }

        public enum Team
        {
            red,
            green,
            blue
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
    }
}
