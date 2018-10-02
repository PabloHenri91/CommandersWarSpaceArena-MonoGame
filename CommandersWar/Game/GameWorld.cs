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

using FarseerPhysics.Collision.Shapes;

namespace Hydra
{
    class GameWorld : SKNode
    {
        Stars stars;

        internal void load()
        {
            loadStars();

            SKSpriteNode border = new SKSpriteNode(SKScene.current.Texture2D("gameWorld"));
            border.blendState = BlendState.Additive;
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
            SKPhysicsBody somePhysicsBody = new SKPhysicsBody(SKScene.defaultSize, ShapeType.Chain);

            somePhysicsBody.BodyType = FarseerPhysics.Dynamics.BodyType.Static;

            physicsBody = somePhysicsBody;
        }

        internal void updateSize()
        {
            stars.updateSize();
        }
    }
}
