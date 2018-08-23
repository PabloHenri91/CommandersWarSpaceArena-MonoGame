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

namespace CommandersWar.Boxes
{
    class BoxSettings : Box
    {
        public BoxSettings() : base("box_233x610")
        {
            PlayerData playerData = MemoryCard.current.playerData;

            Label labelMusic = new Label("Music", 43.0f, 69.0f - 6.0f);
            labelMusic.anchorPoint = new Vector2(0.0f, 1.0f);
            addChild(labelMusic);

            Button buttonMusic = new Button("button_55x55", 43.0f, 69.0f);
            buttonMusic.color = GameColors.controlBlue;
            buttonMusic.blendState = BlendState.Additive;
            buttonMusic.setIcon(playerData.music ? "Musical Notes 1" : "Musical Notes 0");
            addChild(buttonMusic);

            Label labelSound = new Label("Sound Effects", 43.0f, 190.0f - 6.0f);
            labelSound.anchorPoint = new Vector2(0.0f, 1.0f);
            addChild(labelSound);

            Button buttonSound = new Button("button_55x55", 43.0f, 190.0f);
            buttonSound.color = GameColors.controlBlue;
            buttonSound.blendState = BlendState.Additive;
            buttonSound.setIcon(playerData.sound ? "High Volume 1" : "High Volume 0");
            addChild(buttonSound);

            Label labelCredits = new Label("Credits", 43.0f, 312.0f - 6.0f);
            labelCredits.anchorPoint = new Vector2(0.0f, 1.0f);
            addChild(labelCredits);

            Button buttonCredits = new Button("button_55x55", 43.0f, 312.0f);
            buttonCredits.color = GameColors.controlBlue;
            buttonCredits.blendState = BlendState.Additive;
            buttonCredits.setIcon("About");
            addChild(buttonCredits);

            Label labelReset = new Label("Reset Data", 43.0f, 434.0f - 6.0f);
            labelReset.anchorPoint = new Vector2(0.0f, 1.0f);
            addChild(labelReset);

            Button buttonReset = new Button("button_55x55", 43.0f, 434.0f);
            buttonReset.color = GameColors.controlBlue;
            buttonReset.blendState = BlendState.Additive;
            buttonReset.setIcon("Waste");
            addChild(buttonReset);

            Button buttonOK = new Button("button_89x34", 72.0f, 554.0f);
            buttonOK.setLabel(new Label("OK"));
            buttonOK.color = GameColors.controlBlue;
            buttonOK.blendState = BlendState.Additive;
            addChild(buttonOK);
        }
    }
}
