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

using CommandersWar.Scenes;

using CommandersWar.Game;
using CommandersWar.Boxes;

namespace Hydra.Scenes
{
    class GameScene : SKScene
    {
        public GameScene()
        {
            backgroundColor = GameColors.backgroundColor;
            defaultSize = new Vector2(375, 667);

            Label.defaultFontName = FontName.kenpixel;
            Label.defaultFontSize = FontSize.size16;

            //Game1.samplerState = SamplerState.PointClamp;
        }

		internal override void load()
		{
            base.load();

            Music.sharedInstance.play(GameMusic.MusicType.battle);

            gameWorld.load();

            Control title = new Control("title", 9, 281, HorizontalAlignment.center, VerticalAlignment.center);
            title.blendState = BlendState.Additive;
            addChild(title);

            addChild(new Label("TOUCH TO START", 187, 620, HorizontalAlignment.center, VerticalAlignment.center));
		}

		internal override void touchUp(Touch touch)
		{
            base.touchUp(touch);

            presentScene(new MainMenuScene());
		}

        internal override void updateSize()
        {
            base.updateSize();
            gameWorld?.updateSize();
        }
    }
}
