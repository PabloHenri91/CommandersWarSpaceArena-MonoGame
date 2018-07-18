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
using CommandersWar.Boxes;

namespace CommandersWar.Game
{
    public class ControlPremiumPoints : Control
    {
        internal static ControlPremiumPoints current;

        public ControlPremiumPoints(float x,
                                    float y,
                                    HorizontalAlignment horizontalAlignment = HorizontalAlignment.left,
                                    VerticalAlignment verticalAlignment = VerticalAlignment.top) : base("box_144x55", x, y, horizontalAlignment, verticalAlignment)
        {
            color = GameColors.premiumPoints;



            current = this;
        }

        internal void setLabelText(int premiumPoints)
        {

        }
    }
}
