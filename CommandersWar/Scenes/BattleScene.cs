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

namespace CommandersWar.Scenes
{
    public class BattleScene : SKScene
    {
        State state = State.loading;
        State nextState = State.loading;

        Mothership mothership;
        Mothership botMothership;

        internal override void load()
        {
            base.load();

            Music.sharedInstance.play(GameMusic.MusicType.battle);

            PlayerData playerData = MemoryCard.current.playerData;

            gameWorld.load();
            physicsWorld.Gravity = Vector2.Zero;

            mothership = new Mothership(Mothership.Team.blue);
            mothership.loadHealthBar(gameWorld);
            gameWorld.addChild(mothership);

            foreach (MothershipSlotData mothershipSlotData in playerData.mothership.slots.OrderBy(i => i.index))
            {
                Spaceship spaceship = new Spaceship(mothershipSlotData.spaceship, true);
                mothership.spaceships.Add(spaceship);
            }

            mothership.loadSpaceships(gameWorld);


            botMothership = new Mothership(Mothership.Team.red);
            botMothership.loadHealthBar(gameWorld);
            gameWorld.addChild(botMothership);

            Mission mission = Mission.types[playerData.botLevel];

            foreach (Spaceship.Rarity rarity in mission.rarities)
            {
                Spaceship spaceship = new Spaceship(MathHelper.Clamp((mission.level + random.Next(-2, 0)), 1, 10),
                                                    rarity, 
                                                    true, 
                                                    Mothership.Team.red, mission.color);
                botMothership.spaceships.Add(spaceship);
            }

            botMothership.loadSpaceships(gameWorld);

            mothership.updateMaxHealth(botMothership.spaceships);
            botMothership.updateMaxHealth(mothership.spaceships);

            nextState = State.battle;
        }

        enum State
        {
            loading,

            battle,

            battleEnd,
            battleEndInterval,
            showBattleResult,

            mainMenu,
            credits
        }
    }
}
