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
        enum State
        {
            mainMenu,
            battle,
            hangar,
            chooseMission
        }

        State state = State.mainMenu;
        State nextState = State.mainMenu;

        Control buttonPlay;

		internal override void load()
		{
            base.load();

            PlayerData playerData = MemoryCard.current.playerData;

            MothershipSlots mothershipSlots = new MothershipSlots(0, 289, HorizontalAlignment.center, VerticalAlignment.center);
            //mothershipSlots.load(playerData.mothership.slots);
            addChild(mothershipSlots);

            buttonPlay = new Control("button_233x55", 0, 0, HorizontalAlignment.center, VerticalAlignment.center);//Button("button_233x55", 71, 604, HorizontalAlignment.center, VerticalAlignment.bottom);
            scale = new Vector2(0.5f);
            //buttonPlay.setIcon("Play");
            //buttonPlay.set(GameColors.controlRed, BlendState.Additive);
            addChild(buttonPlay);

            //buttonPlay.touchUpAction = () => {
            //    //nextState = State.battle;
            //};
		}

        internal override void update()
        {
            base.update();

            if (state == nextState)
            {
                switch (state)
                {
                }
            }
            else
            {
                state = nextState;
                switch (state)
                {
                    case State.battle:
                        presentScene(new BattleScene());
                        break;
                }
            }
        }

        internal override void touchMoved(Touch touch)
        {
            base.touchMoved(touch);

            buttonPlay.position = touch.locationIn(buttonPlay.parent);
        }
    }
}
