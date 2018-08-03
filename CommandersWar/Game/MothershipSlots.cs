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
    public class MothershipSlots : Control
    {
        List<MothershipSlot> mothershipSlots = new List<MothershipSlot>();

        public MothershipSlots(float x, float y,
                               HorizontalAlignment horizontalAlignment = HorizontalAlignment.left,
                               VerticalAlignment verticalAlignment = VerticalAlignment.top) : base("", x, y, horizontalAlignment, verticalAlignment)
        {
            mothershipSlots.Add(new MothershipSlot(0, 0));
            mothershipSlots.Add(new MothershipSlot(95, 0));
            mothershipSlots.Add(new MothershipSlot(191, 0));
            mothershipSlots.Add(new MothershipSlot(286, 0));

            foreach (MothershipSlot mothershipSlot in mothershipSlots)
            {
                addChild(mothershipSlot);
            }
        }

        internal void load(IEnumerable<MothershipSlotData> slots)
        {
            foreach (MothershipSlotData mothershipSlotData in slots.OrderBy(i => i.index))
            {
                mothershipSlots[mothershipSlotData.index].load(mothershipSlotData.spaceship);
            }
        }
    }
}
