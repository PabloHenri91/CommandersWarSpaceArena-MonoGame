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

namespace Hydra.Scenes
{
    public class MainMenuScene : SKScene
    {
		internal override void load()
		{
            base.load();

            MothershipSlots mothershipSlots = new MothershipSlots(0, 289, HorizontalAlignment.center, VerticalAlignment.center);



            addChild(mothershipSlots);

            var buttonPlay = new Button("button_233x55", 71, 604, HorizontalAlignment.center, VerticalAlignment.bottom);
            buttonPlay.setIcon("Play");
            buttonPlay.set(GameColors.controlRed, BlendState.Additive);
            addChild(buttonPlay);

            buttonPlay.touchUpEvent = (sender, e) => {
                
            };
		}
	}
}
