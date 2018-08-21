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

namespace CommandersWar.Boxes
{
    class BoxBattleResult : Box
    {
        public BoxBattleResult(Mothership mothership, Mothership botMothership) : base("box_233x610")
        {
            var playerData = MemoryCard.current.playerData;
        }
    }
}
