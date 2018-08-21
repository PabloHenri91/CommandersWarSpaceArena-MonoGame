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
    class ControlMission:Control
    {
        public ControlMission(float x = 71,
                              float y = 507,
                              HorizontalAlignment horizontalAlignment = HorizontalAlignment.center,
                              VerticalAlignment verticalAlignment = VerticalAlignment.center) : base("box_233x89", x, y, horizontalAlignment, verticalAlignment)
        {
            PlayerData playerData = MemoryCard.current.playerData;

            var sector = playerData.botLevel / 10;
            var mission = playerData.botLevel % 10;
            Label label = new Label($"Sector {sector + 1}.{mission + 1}", 151, 44);
            addChild(label);

            Button buttonChooseMission = new Button("button_55x55", 17.0f, 17.0f);
            buttonChooseMission.color = GameColors.controlBlue;
            buttonChooseMission.blendState = BlendState.Additive;
            buttonChooseMission.setIcon("Waypoint Map");
            addChild(buttonChooseMission);
        }
    }
}
