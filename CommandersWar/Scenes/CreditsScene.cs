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

using CommandersWar.Game;
using CommandersWar.Boxes;

namespace CommandersWar.Scenes
{
    class CreditsScene : SKScene
    {
        internal override void load()
        {
            base.load();

            Music.sharedInstance.play(GameMusic.MusicType.battle);
        }
    }
}
