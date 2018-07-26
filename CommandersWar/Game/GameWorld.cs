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

using CommandersWar.Game;

namespace Hydra
{
    public class GameWorld : SKNode
    {
        Stars stars;

        internal void load()
        {
            loadStars();

            SKSpriteNode border = new SKSpriteNode(SKScene.current.Texture2D("gameWorld"));
            addChild(border);

            loadPhysics();
            loadSoundEffect();
        }

        internal void loadStars()
        {
            stars = new Stars();
            addChild(stars);
        }

        void loadSoundEffect()
        {
            
        }

        void loadPhysics()
        {
            
        }

        internal void updateSize()
        {
            stars.updateSize();
        }
    }
}
