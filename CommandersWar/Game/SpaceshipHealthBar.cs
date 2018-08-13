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
    public class SpaceshipHealthBar : SKSpriteNode
    {
        public SpaceshipHealthBar(int level, int health, Mothership.Team team, Spaceship.Rarity rarity) : base("spaceshipHealthBarBackground")
        {
            
        }
    }
}
