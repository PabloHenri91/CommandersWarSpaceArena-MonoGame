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
    public class Mission
    {
        internal int level;
        internal IEnumerable<Spaceship.Rarity> rarities;
        internal Color color;

        public Mission(int level, IEnumerable<Spaceship.Rarity> rarities, Color color)
        {
            this.level = level;
            this.rarities = rarities;
            this.color = color;
        }

        internal static Mission[] types =
        {
            new Mission(1, new[]{Spaceship.Rarity.common, Spaceship.Rarity.common, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(1.0f, 0.3f, 0.3f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.uncommon, Spaceship.Rarity.common, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.2f, 1.0f, 1.0f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(1.0f, 0.9f, 0.1f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.rare, Spaceship.Rarity.common, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.2f, 1.0f, 0.2f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(0.9f, 0.3f, 1.0f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.3f, 0.3f, 1.0f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(0.9f, 0.9f, 1.0f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(0.5f, 0.3f, 0.5f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.common, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(1.0f, 0.3f, 0.1f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.4f, 1.0f, 1.0f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.9f, 0.0f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.1f, 1.0f, 0.2f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(1.0f, 0.2f, 0.8f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(0.4f, 0.3f, 1.0f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.8f, 1.0f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.3f, 0.4f, 0.5f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(1.0f, 0.2f, 0.1f, 1.0f)),
            new Mission(1, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(0.1f, 1.0f, 1.0f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.common, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.9f, 1.0f, 0.2f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(0.3f, 1.0f, 0.4f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(0.8f, 0.1f, 1.0f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.uncommon, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.3f, 0.5f, 1.0f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(0.9f, 1.0f, 0.9f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.5f, 0.3f, 0.3f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(1.0f, 0.4f, 0.3f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(0.2f, 1.0f, 0.9f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(1.0f, 0.9f, 0.2f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.1f, 1.0f, 0.3f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(1.0f, 0.3f, 1.0f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(0.2f, 0.2f, 1.0f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.8f, 0.9f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(0.5f, 0.3f, 0.3f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.1f, 0.2f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(0.2f, 0.8f, 1.0f, 1.0f)),
            new Mission(2, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(1.0f, 0.9f, 0.2f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(0.2f, 1.0f, 0.2f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.9f, 0.2f, 1.0f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.common, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.4f, 0.3f, 1.0f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.9f, 1.0f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(0.5f, 0.4f, 0.4f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(1.0f, 0.3f, 0.3f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.uncommon, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.2f, 1.0f, 0.8f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(0.9f, 1.0f, 0.2f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.common}, new Color(0.4f, 1.0f, 0.4f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(0.8f, 0.2f, 1.0f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(0.4f, 0.3f, 1.0f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(1.0f, 1.0f, 1.0f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(0.3f, 0.4f, 0.5f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.rare, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(1.0f, 0.1f, 0.1f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon}, new Color(0.1f, 1.0f, 1.0f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(1.0f, 1.0f, 0.2f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(0.3f, 1.0f, 0.2f, 1.0f)),
            new Mission(3, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(1.0f, 0.3f, 0.9f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(0.3f, 0.3f, 1.0f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(0.8f, 1.0f, 1.0f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare}, new Color(0.4f, 0.4f, 0.5f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(1.0f, 0.4f, 0.1f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(0.2f, 0.9f, 1.0f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(1.0f, 1.0f, 0.1f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.common}, new Color(0.2f, 1.0f, 0.3f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(0.9f, 0.2f, 1.0f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(0.3f, 0.3f, 1.0f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(1.0f, 1.0f, 1.0f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(0.4f, 0.3f, 0.5f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.1f, 0.1f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(0.1f, 1.0f, 0.9f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.8f, 0.2f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic}, new Color(0.3f, 1.0f, 0.4f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.2f, 0.9f, 1.0f)),
            new Mission(4, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(0.4f, 0.2f, 1.0f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.common, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.9f, 1.0f, 0.9f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare}, new Color(0.3f, 0.3f, 0.5f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(1.0f, 0.1f, 0.2f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(0.2f, 1.0f, 0.9f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.common}, new Color(1.0f, 1.0f, 0.3f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.uncommon, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.3f, 1.0f, 0.2f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.9f, 0.1f, 1.0f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(0.2f, 0.1f, 1.0f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(0.9f, 0.8f, 1.0f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon}, new Color(0.3f, 0.4f, 0.4f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(1.0f, 0.5f, 0.4f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(0.3f, 0.9f, 1.0f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.rare, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.9f, 1.0f, 0.3f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic}, new Color(0.3f, 1.0f, 0.5f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.common}, new Color(0.9f, 0.2f, 1.0f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(0.2f, 0.3f, 1.0f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(0.9f, 1.0f, 0.8f, 1.0f)),
            new Mission(5, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(0.4f, 0.5f, 0.4f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(1.0f, 0.3f, 0.2f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare}, new Color(0.1f, 1.0f, 0.9f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(1.0f, 1.0f, 0.2f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon}, new Color(0.4f, 1.0f, 0.4f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.common}, new Color(1.0f, 0.2f, 0.9f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(0.1f, 0.0f, 1.0f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(0.9f, 1.0f, 1.0f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.4f, 0.4f, 0.3f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(1.0f, 0.2f, 0.2f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare}, new Color(0.2f, 1.0f, 1.0f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.9f, 0.2f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.common}, new Color(0.1f, 1.0f, 0.3f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(1.0f, 0.2f, 1.0f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic}, new Color(0.4f, 0.3f, 1.0f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(1.0f, 1.0f, 1.0f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(0.4f, 0.4f, 0.3f, 1.0f)),
            new Mission(6, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.3f, 0.4f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(0.2f, 0.9f, 1.0f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon}, new Color(0.9f, 1.0f, 0.1f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.rare}, new Color(0.2f, 1.0f, 0.3f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(1.0f, 0.1f, 1.0f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(0.4f, 0.4f, 1.0f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic}, new Color(0.8f, 1.0f, 1.0f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.rare, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(0.5f, 0.3f, 0.3f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.3f, 0.4f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.2f, 1.0f, 0.9f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(1.0f, 0.9f, 0.3f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(0.1f, 1.0f, 0.3f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare}, new Color(1.0f, 0.3f, 0.9f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(0.4f, 0.3f, 1.0f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.common}, new Color(1.0f, 1.0f, 1.0f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.heroic}, new Color(0.3f, 0.4f, 0.3f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.2f, 0.2f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.common}, new Color(0.2f, 0.9f, 1.0f, 1.0f)),
            new Mission(7, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(1.0f, 1.0f, 0.2f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(0.1f, 1.0f, 0.2f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.uncommon}, new Color(0.8f, 0.1f, 1.0f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon}, new Color(0.4f, 0.3f, 1.0f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.common}, new Color(1.0f, 0.9f, 1.0f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(0.4f, 0.4f, 0.2f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic}, new Color(1.0f, 0.2f, 0.2f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(0.2f, 0.9f, 1.0f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.rare}, new Color(1.0f, 1.0f, 0.4f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(0.4f, 1.0f, 0.2f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon}, new Color(0.8f, 0.2f, 1.0f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare}, new Color(0.5f, 0.5f, 1.0f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.epic}, new Color(1.0f, 0.8f, 1.0f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.3f, 0.3f, 0.5f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.common}, new Color(1.0f, 0.2f, 0.3f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.rare}, new Color(0.4f, 0.9f, 1.0f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(0.9f, 1.0f, 0.2f, 1.0f)),
            new Mission(8, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(0.2f, 1.0f, 0.3f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.3f, 0.9f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.heroic}, new Color(0.5f, 0.4f, 1.0f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.common}, new Color(0.9f, 1.0f, 0.8f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic}, new Color(0.4f, 0.4f, 0.4f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.1f, 0.3f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.uncommon}, new Color(0.2f, 1.0f, 1.0f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.rare}, new Color(0.9f, 1.0f, 0.2f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic}, new Color(0.2f, 1.0f, 0.1f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(1.0f, 0.2f, 1.0f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.common}, new Color(0.4f, 0.2f, 1.0f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(1.0f, 1.0f, 0.9f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.rare}, new Color(0.3f, 0.4f, 0.3f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.epic}, new Color(1.0f, 0.3f, 0.3f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.uncommon}, new Color(0.2f, 0.9f, 1.0f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.common}, new Color(1.0f, 0.8f, 0.1f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic}, new Color(0.2f, 1.0f, 0.1f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(0.8f, 0.1f, 1.0f, 1.0f)),
            new Mission(9, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon}, new Color(0.2f, 0.1f, 1.0f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.rare}, new Color(0.8f, 1.0f, 1.0f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.heroic}, new Color(0.3f, 0.5f, 0.3f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.common}, new Color(1.0f, 0.3f, 0.2f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.uncommon}, new Color(0.1f, 1.0f, 0.8f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.common, Spaceship.Rarity.common}, new Color(0.9f, 1.0f, 0.1f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.rare}, new Color(0.2f, 1.0f, 0.4f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.common}, new Color(1.0f, 0.2f, 1.0f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.heroic}, new Color(0.3f, 0.4f, 1.0f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.uncommon, Spaceship.Rarity.common}, new Color(0.8f, 1.0f, 0.9f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.rare}, new Color(0.4f, 0.4f, 0.5f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.epic}, new Color(1.0f, 0.3f, 0.1f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.uncommon}, new Color(0.1f, 1.0f, 0.8f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.uncommon, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.9f, 0.1f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.rare, Spaceship.Rarity.common}, new Color(0.4f, 1.0f, 0.4f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic}, new Color(1.0f, 0.2f, 0.9f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.rare, Spaceship.Rarity.uncommon}, new Color(0.4f, 0.4f, 1.0f, 1.0f)),
            new Mission(10, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.rare}, new Color(1.0f, 1.0f, 1.0f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.heroic}, new Color(0.4f, 0.4f, 0.3f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.epic, Spaceship.Rarity.epic}, new Color(1.0f, 0.2f, 0.3f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.common}, new Color(0.3f, 1.0f, 0.9f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.rare, Spaceship.Rarity.rare}, new Color(1.0f, 0.9f, 0.3f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.heroic}, new Color(0.4f, 1.0f, 0.4f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.common}, new Color(1.0f, 0.2f, 0.9f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.uncommon}, new Color(0.4f, 0.3f, 1.0f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.uncommon}, new Color(0.8f, 1.0f, 0.9f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.epic}, new Color(0.3f, 0.3f, 0.4f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.rare}, new Color(1.0f, 0.3f, 0.3f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.common}, new Color(0.1f, 1.0f, 1.0f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.rare}, new Color(0.8f, 1.0f, 0.2f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.epic, Spaceship.Rarity.epic}, new Color(0.1f, 1.0f, 0.3f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.uncommon}, new Color(1.0f, 0.2f, 0.9f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.heroic, Spaceship.Rarity.heroic}, new Color(0.2f, 0.4f, 1.0f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.heroic}, new Color(1.0f, 1.0f, 0.9f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.rare}, new Color(0.3f, 0.5f, 0.4f, 1.0f)),
            new Mission(11, new[]{Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary}, new Color(1.0f, 0.5f, 0.4f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.heroic}, new Color(0.2f, 1.0f, 0.9f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.common}, new Color(1.0f, 0.9f, 0.1f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.epic}, new Color(0.1f, 1.0f, 0.2f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.uncommon}, new Color(0.9f, 0.1f, 1.0f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.rare}, new Color(0.2f, 0.2f, 1.0f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.epic, Spaceship.Rarity.epic}, new Color(1.0f, 1.0f, 1.0f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.heroic}, new Color(0.4f, 0.5f, 0.3f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary}, new Color(1.0f, 0.3f, 0.3f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.common}, new Color(0.3f, 0.8f, 1.0f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.epic}, new Color(1.0f, 1.0f, 0.1f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.uncommon}, new Color(0.2f, 1.0f, 0.2f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.rare}, new Color(0.9f, 0.4f, 1.0f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.heroic}, new Color(0.2f, 0.3f, 1.0f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.legendary, Spaceship.Rarity.legendary}, new Color(1.0f, 0.9f, 0.9f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.epic}, new Color(0.4f, 0.3f, 0.3f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.legendary}, new Color(1.0f, 0.2f, 0.3f, 1.0f)),
            new Mission(12, new[]{Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.supreme, Spaceship.Rarity.supreme}, new Color(0.2f, 1.0f, 0.9f, 1.0f))
        };
    }
}