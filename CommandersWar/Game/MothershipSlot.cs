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

namespace CommandersWar.Game
{
    class MothershipSlot : Control
    {
        Spaceship spaceship;

        public MothershipSlot(int x, int y,
                              HorizontalAlignment horizontalAlignment = HorizontalAlignment.left,
                              VerticalAlignment verticalAlignment = VerticalAlignment.top)
            : base("box_89x89", x, y, horizontalAlignment, verticalAlignment)
        {
            blendState = BlendState.Additive;
        }

        internal void load(SpaceshipData spaceshipData)
        {
            load(new Spaceship(spaceshipData));
        }

        internal void load(Spaceship someSpaceship)
        {
            spaceship = someSpaceship;
            spaceship.position = new Vector2(size.X / 2, size.Y / 2);
            spaceship.setScaleToFit(new Vector2(size.X - 16, size.Y - 16));
            addChild(spaceship);
        }

        internal void loadHealthBar()
        {
            if (spaceship == null) { return; }
            spaceship.loadHealthBar();
            spaceship.healthBar.positionOffset = new Vector2(4.0f, (size.X / 2.0f) + 9.0f);
            spaceship.updateHealthBarPosition();
        }
    }
}
