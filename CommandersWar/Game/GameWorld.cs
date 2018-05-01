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

namespace Hydra
{
    public class GameWorld : SKNode
    {
        internal void load()
        {
            SKSpriteNode border = new SKSpriteNode(SKScene.current.Texture2D("gameWorld"));
            addChild(border);
        }
    }
}
