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
    public class GameScene : SKScene
    {
        public GameScene()
        {
            backgroundColor = GameColors.backgroundColor;
            defaultSize = new Vector2(375, 667);

            Label.defaultFontName = FontName.kenPixel;
            Label.defaultColor = GameColors.fontWhite;
            Label.defaultFontSize = FontSize.size16;
        }

		internal override void load()
		{
            base.load();

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
