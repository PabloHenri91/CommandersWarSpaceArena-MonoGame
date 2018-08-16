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

        float battleBeginTime;
        float maxBattleDuration = 60.0f * 3.0f;

        float lastBotUpdate;

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

        internal override void update()
        {
            base.update();

            if (state == nextState)
            {
                switch (state)
                {
                    case State.battle:
                        updateBattle();
                        break;
                }
            }
            else
            {
                state = nextState;
                switch (state)
                {
                    case State.battle:
                        loadBattle();
                        break;
                    case State.mainMenu:
                        presentScene(new MainMenuScene());
                        break;
                }
            }
        }

        void loadBattle()
        {
            if (battleBeginTime.Equals(0.0f))
            {
                battleBeginTime = currentTime;
            }
        }

        void updateBattle()
        {
            if (mothership.health <= 0 || botMothership.health <=0)
            {
                nextState = State.battleEnd;
            }

            mothership.update(botMothership, botMothership.spaceships);
            botMothership.update(mothership, mothership.spaceships);

            if (currentTime - lastBotUpdate > 1.0f)
            {
                lastBotUpdate = currentTime;

                int health = 0;
                foreach (var spaceship in mothership.spaceships)
                {
                    health += spaceship.health;
                }
                if (health <= 0 || currentTime - battleBeginTime > maxBattleDuration)
                {
                    mothership.health -= mothership.maxHealth / 10;
                    mothership.updateHealthBar(mothership.health, mothership.maxHealth);
                    if (mothership.health <= 0)
                    {
                        mothership.die();
                    }
                    else
                    {
                        run(mothership.explosionAction());
                    }
                }

                health = 0;
                foreach (var spaceship in botMothership.spaceships)
                {
                    health += spaceship.health;
                }
                if (health <= 0 || currentTime - battleBeginTime > maxBattleDuration)
                {
                    botMothership.health -= botMothership.maxHealth / 10;
                    botMothership.updateHealthBar(botMothership.health, botMothership.maxHealth);
                    if (botMothership.health <= 0)
                    {
                        botMothership.die();
                    }
                    else
                    {
                        run(botMothership.explosionAction());
                    }
                }

                List<Spaceship> aliveBotSpaceships = botMothership.spaceships.Where(x => {
                    return x.health > 0; // TODO:
                }).ToList();

                if (aliveBotSpaceships.Count() > 0)
                {
                    Spaceship botSpaceship = aliveBotSpaceships[random.Next(aliveBotSpaceships.Count())];

                    var aliveSpaceships = mothership.spaceships.Where(x =>
                    {
                        return x.health > 0;  // TODO:
                    }).OrderByDescending(x => {
                        return x.health;  // TODO:
                    });
                }
            }
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
