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

namespace CommandersWar.Controls
{
    public class ControlPoints : Control
    {
        internal static ControlPoints current;

        Label label;

        public ControlPoints(float x,
                             float y,
                             HorizontalAlignment horizontalAlignment = HorizontalAlignment.right,
                             VerticalAlignment verticalAlignment = VerticalAlignment.top) : base("box_144x55", x, y, horizontalAlignment, verticalAlignment)
        {
            color = GameColors.points;
            blendState = BlendState.Additive;

            Control icon = new Control("Coins");
            icon.size = new Vector2(55, 55);
            icon.color = GameColors.points;
            icon.blendState = BlendState.Additive;
            addChild(icon);

            label = new Label("?", 97, 27);
            label.color = color;
            addChild(label);

            current = this;
        }

        internal void setLabelText(int points)
        {
            label.text = $"{points}";
        }
    }
}
