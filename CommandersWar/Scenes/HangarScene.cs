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

using CommandersWar.Game;

namespace CommandersWar.Scenes
{
    public class HangarScene : SKScene
    {
        State state = State.hangar;
        State nextState = State.hangar;

        Button buttonBack;

        internal override void load()
        {
            base.load();

            gameWorld.loadStars();

            PlayerData playerData = MemoryCard.current.playerData;

            buttonBack = new Button("button_55x55", 8, 604, HorizontalAlignment.center, VerticalAlignment.bottom);
            buttonBack.setIcon("Back");
            buttonBack.set(GameColors.controlBlue, BlendState.Additive);
            addChild(buttonBack);

            ControlPremiumPoints controlPremiumPoints = new ControlPremiumPoints(8, 15);
            controlPremiumPoints.setLabelText(playerData.premiumPoints);
            addChild(controlPremiumPoints);

            ControlPoints controlPoints = new ControlPoints(223, 15);
            controlPoints.setLabelText(playerData.points);
            addChild(controlPoints);
        }

        internal override void update()
        {
            base.update();

            if (state == nextState)
            {
                switch (state)
                {
                    case State.hangar:
                        break;
                }
            }
            else
            {
                state = nextState;
                switch (state)
                {
                    case State.mainMenu:
                        presentScene(new MainMenuScene());
                        break;
                }
            }
        }

        internal override void touchUp(Touch touch)
        {
            base.touchUp(touch);

            if (state == nextState)
            {
                switch (state)
                {
                    case State.hangar:
                        if (buttonBack.contains(touch.locationIn(buttonBack.parent)))
                        {
                            nextState = State.mainMenu;
                            return;
                        }
                        break;
                }
            }
        }

        enum State
        {
            hangar,
            mainMenu
        }
    }
}
