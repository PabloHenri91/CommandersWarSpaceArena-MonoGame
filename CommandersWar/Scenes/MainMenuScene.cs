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

using CommandersWar.Controls;
using CommandersWar.Boxes;
using CommandersWar.Game;

namespace CommandersWar.Scenes
{
    public class MainMenuScene : SKScene
    {
        State state = State.mainMenu;
        State nextState = State.mainMenu;

        Button buttonPlay;
        Button buttonShips;
        Button buttonSettings;

        BoxSettings boxSettings;

        Control control;

        MothershipSlots mothershipSlots;

        internal override void load()
        {
            base.load();

            Music.sharedInstance.play(GameMusic.MusicType.menu);

            gameWorld.loadStars();

            PlayerData playerData = MemoryCard.current.playerData;

            mothershipSlots = new MothershipSlots(0, 289, HorizontalAlignment.center, VerticalAlignment.center);
            mothershipSlots.load(playerData.mothership.slots);
            addChild(mothershipSlots);

            buttonPlay = new Button("button_233x55", 71, 604, HorizontalAlignment.center, VerticalAlignment.bottom);
            buttonPlay.setIcon("Play");
            buttonPlay.set(GameColors.controlRed, BlendState.Additive);
            addChild(buttonPlay);

            Button buttonBuy = new Button("button_55x55", 312, 604, HorizontalAlignment.center, VerticalAlignment.bottom);
            buttonBuy.setIcon("Add Shopping Cart");
            buttonBuy.set(GameColors.controlYellow, BlendState.Additive);
            addChild(buttonBuy);
            buttonBuy.isHidden = true;

            buttonShips = new Button("button_55x55", 8, 604, HorizontalAlignment.left, VerticalAlignment.bottom);
            buttonShips.setIcon("Rocket");
            buttonShips.set(GameColors.controlBlue, BlendState.Additive);
            addChild(buttonShips);


            Button buttonPlayOnline = new Button("button_55x55", 249, 95, HorizontalAlignment.right, VerticalAlignment.top);
            buttonPlayOnline.setIcon("Bluetooth");
            buttonPlayOnline.set(GameColors.controlRed, BlendState.Additive);
            addChild(buttonPlayOnline);

            buttonSettings = new Button("button_55x55", 312, 95, HorizontalAlignment.right, VerticalAlignment.top);
            buttonSettings.setIcon("Settings");
            buttonSettings.set(GameColors.controlBlue, BlendState.Additive);
            addChild(buttonSettings);

            Button buttonGameCenter = new Button("button_55x55", 312, 158, HorizontalAlignment.right, VerticalAlignment.top);
            buttonGameCenter.setIcon("Game Center");
            buttonGameCenter.set(GameColors.controlBlue, BlendState.Additive);
            addChild(buttonGameCenter);
            buttonGameCenter.isHidden = true;

            Button buttonFacebook = new Button("button_55x55", 312, 221, HorizontalAlignment.right, VerticalAlignment.top);
            buttonFacebook.setIcon("Facebook");
            buttonFacebook.set(GameColors.controlBlue, BlendState.Additive);
            addChild(buttonFacebook);
            buttonFacebook.isHidden = true;

            ControlMission controlMission = new ControlMission();
            addChild(controlMission);


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
                    case State.mainMenu:
                        break;
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
                    case State.hangar:
                        presentScene(new HangarScene());
                        break;
                    case State.settings:
                        boxSettings = new BoxSettings();
                        addChild(boxSettings);
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
                    case State.mainMenu:
                        if (buttonPlay.contains(touch.locationIn(buttonPlay.parent)))
                        {
                            nextState = State.battle;
                            return;
                        }

                        if (buttonShips.contains(touch.locationIn(buttonShips.parent)) ||
                            mothershipSlots.contains(touch.locationIn(mothershipSlots.parent)))
                        {
                            nextState = State.hangar;
                            return;
                        }

                        if (buttonSettings.contains(touch.locationIn(buttonSettings.parent)))
                        {
                            nextState = State.settings;
                            return;
                        }
                        break;

                    case State.settings:
                        if (!boxSettings.contains(touch.locationIn(boxSettings.parent)))
                        {
                            boxSettings.removeFromParent();
                            boxSettings = null;
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
            mainMenu,
            battle,
            hangar,
            chooseMission,
            settings
        }
    }
}
