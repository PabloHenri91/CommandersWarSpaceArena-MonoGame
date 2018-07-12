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

using Realms;

using CommandersWar.Game;

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

        internal void addToSpaceships(SpaceshipData spaceshipData)
        {
            spaceshipData.parentPlayer = this;
        }
    }

    public class MothershipData : RealmObject
    {
        [Backlink(nameof(MothershipSlotData.parentMothership))]
        public IQueryable<MothershipSlotData> slots { get; }

        internal void addToSlots(MothershipSlotData mothershipSlotData)
        {
            mothershipSlotData.parentMothership = this;
        }
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

    public static class MemoryCardExtension
    {

        public static PlayerData newPlayerData(this MemoryCard memoryCard)
        {
            PlayerData playerData = memoryCard.insert<PlayerData>();

            playerData.botLevel = 0;
            playerData.deviceName = "deviceName";
            playerData.maxBotLevel = 0;
            playerData.maxBotRarity = 0;
            playerData.maxSpaceshipLevel = 10;
            playerData.modelVersion = 0;
            playerData.music = true;
            playerData.name = "name";
            playerData.points = 10000;
            playerData.premiumPoints = 256;
            playerData.sound = true;

            MothershipData mothershipData = memoryCard.newMothershipData();
            playerData.mothership = mothershipData;

            Element.Type[] elements = {
                Element.Type.water,
                Element.Type.fire,
                Element.Type.ice,
                Element.Type.wind
            };

            for (int i = 0; i < 4; i++)
            {
                MothershipSlotData mothershipSlotData = memoryCard.newMothershipSlotData();
                mothershipSlotData.index = i;

                SpaceshipData spaceshipData = memoryCard.newSpaceshipData(Spaceship.Rarity.common, Element.types[elements[i]].color);
                mothershipSlotData.spaceship = spaceshipData;
                mothershipData.addToSlots(mothershipSlotData);
            }

            return playerData;
        }

        public static MothershipData newMothershipData(this MemoryCard memoryCard)
        {
            MothershipData mothershipData = memoryCard.insert<MothershipData>();
            return mothershipData;
        }

        public static MothershipSlotData newMothershipSlotData(this MemoryCard memoryCard)
        {
            MothershipSlotData mothershipSlotData = memoryCard.insert<MothershipSlotData>();
            return mothershipSlotData;
        }

        internal static SpaceshipData newSpaceshipData(this MemoryCard memoryCard, Spaceship.Rarity rarity, Color? color = null)
        {
            SpaceshipData spaceshipData = memoryCard.insert<SpaceshipData>();

            if (color == null)
            {
                color = Spaceship.randomColor();
            }

            spaceshipData.colorRed = color.Value.R;
            spaceshipData.colorGreen = color.Value.G;
            spaceshipData.colorBlue = color.Value.B;
            spaceshipData.baseDamage = GameMath.randomBaseDamage(rarity);
            spaceshipData.level = 1;
            spaceshipData.baseLife = GameMath.randomBaseLife(rarity);
            spaceshipData.baseRange = GameMath.randomBaseRange(rarity);
            spaceshipData.baseSpeed = GameMath.randomBaseSpeed(rarity);
            spaceshipData.rarity = rarity.GetHashCode();

            spaceshipData.skin = SKNode.random.Next(Spaceship.skins.Count());
            spaceshipData.xp = 0;

            return spaceshipData;
        }
    }
}
