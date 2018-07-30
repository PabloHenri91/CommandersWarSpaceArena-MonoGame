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
    public class ControlPremiumPoints : Control
    {
        internal static ControlPremiumPoints current;

        Label label;

        public ControlPremiumPoints(float x,
                                    float y,
                                    HorizontalAlignment horizontalAlignment = HorizontalAlignment.left,
                                    VerticalAlignment verticalAlignment = VerticalAlignment.top) : base("box_144x55", x, y, horizontalAlignment, verticalAlignment)
        {
            color = GameColors.premiumPoints;
            blendState = BlendState.Additive;

            Button buttonBuyMore = new Button("button_55x55", 144, 0);
            buttonBuyMore.setIcon("Plus");
            buttonBuyMore.set(GameColors.premiumPoints, BlendState.Additive);
            addChild(buttonBuyMore);
            buttonBuyMore.isHidden = true;

            Control icon = new Control("Minecraft Diamond");
            icon.size = new Vector2(55, 55);
            icon.color = GameColors.premiumPoints;
            icon.blendState = BlendState.Additive;
            addChild(icon);

            label = new Label("?", 97, 27);
            label.color = color;
            addChild(label);

            current = this;
        }

        internal void setLabelText(int premiumPoints)
        {
            label.text = $"{premiumPoints}";
        }
    }
}
