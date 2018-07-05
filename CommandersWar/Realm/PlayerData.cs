using System;
using System.Collections.Generic;
using System.Linq;

using Realms;

namespace Hydra
{
    public class PlayerData : RealmObject
    {
        public int botLevel { get; set; }
        public string deviceName { get; set; }
        public int maxBotLevel { get; set; }
        public int maxBotRarity { get; set; }
        public int maxSpaceshipLevel { get; set; }
        public int modelVersion { get; set; }
        public bool music { get; set; }
        public string name { get; set; }
        public int points { get; set; }
        public int premiumPoints { get; set; }
        public bool sound { get; set; }

        public MothershipData mothership { get; set; }

        [Backlink(nameof(SpaceshipData.parentPlayer))]
        public IQueryable<SpaceshipData> spaceships { get; }

        public PlayerData()
        {
            //mothership = ???
        }
    }

    public class MothershipData : RealmObject
    {
        [Backlink(nameof(MothershipSlotData.parentMothership))]
        public IQueryable<MothershipSlotData> slots { get; }
    }

    public class MothershipSlotData : RealmObject
    {
        public int index { get; set; }

        public MothershipData parentMothership { get; set; }
        public SpaceshipData spaceship { get; set; }
    }

    public class SpaceshipData : RealmObject
    {
        public int baseDamage { get; set; }
        public int baseLife { get; set; }
        public int baseRange { get; set; }
        public int baseSpeed { get; set; }
        public float colorBlue { get; set; }
        public float colorGreen { get; set; }
        public float colorRed { get; set; }
        public int level { get; set; }
        public int rarity { get; set; }
        public int skin { get; set; }
        public int xp { get; set; }

        public PlayerData parentPlayer { get; set; }
    }
}
