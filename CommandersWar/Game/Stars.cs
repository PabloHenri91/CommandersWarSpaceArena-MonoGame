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
    public class Stars : SKNode
    {
        public Stars()
        {
            updateSize();
        }

        internal void updateSize()
        {
            Texture2D texture2D = SKScene.current.Texture2D("stars");

            removeAllChildren();

            int xMax = (int)(SKScene.currentSize.X / texture2D.Bounds.Size.X);
            int yMax = (int)(SKScene.currentSize.Y / texture2D.Bounds.Size.Y);

            for (int x = 0; x <= xMax; x++)
            {
                for (int y = 0; y <= yMax; y++)
                {
                    SKSpriteNode spriteNode = new SKSpriteNode(texture2D);
                    spriteNode.position = new Vector2(
                        texture2D.Bounds.Size.X * x,
                        texture2D.Bounds.Size.Y * y
                    );
                    addChild(spriteNode);

                    //spriteNode.zRotation = MathHelper.PiOver2 * (int)(MathHelper.ToDegrees((float)(random.NextDouble() * MathHelper.TwoPi)) / 90.0f);
                }
            }

            Vector2 size = new Vector2(
                texture2D.Bounds.Size.X * xMax,
                texture2D.Bounds.Size.Y * yMax
            );

            position = new Vector2(
                -size.X / 2.0f,
                -size.Y / 2.0f
            );
        }
    }
}
