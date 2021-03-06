﻿using System;
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

using CommandersWar.Controls;
using CommandersWar.Boxes;
using CommandersWar.Game;

namespace CommandersWar.Scenes
{
    class HangarScene : SKScene
    {
        State state = State.hangar;
        State nextState = State.hangar;

        Button buttonBack;

        Control control;

        internal override void load()
        {
            base.load();

            Music.sharedInstance.play(GameMusic.MusicType.menu);

            gameWorld.loadStars();

            PlayerData playerData = MemoryCard.current.playerData;

            buttonBack = new Button("button_55x55", 8, 604, HorizontalAlignment.left, VerticalAlignment.bottom);
            buttonBack.setIcon("Back");
            buttonBack.set(GameColors.controlBlue, BlendState.Additive);
            addChild(buttonBack);


            control = new Control("box_xx89", 0.0f, -2.0f);
            control.size = new Vector2(currentSize.X, control.size.Y);
            addChild(control);

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

        internal override void updateSize()
        {
            base.updateSize();
            gameWorld.updateSize();
            control.size = new Vector2(currentSize.X, control.size.Y);
        }

        enum State
        {
            hangar,
            mainMenu
        }
    }
}
