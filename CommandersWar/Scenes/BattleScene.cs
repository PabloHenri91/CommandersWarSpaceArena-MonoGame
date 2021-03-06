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

using FarseerPhysics.Dynamics;

namespace CommandersWar.Scenes
{
    class BattleScene : SKScene
    {
        State state = State.loading;
        State nextState = State.loading;

        Mothership mothership;
        Mothership botMothership;

        float battleBeginTime;
        float battleEndTime;
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

            //

            foreach (Spaceship spaceship in mothership.spaceships)
            {
                spaceship.physicsBody.IgnoreCollisionWith(mothership.physicsBody);
            }

            foreach (Spaceship spaceship in botMothership.spaceships)
            {
                spaceship.physicsBody.IgnoreCollisionWith(botMothership.physicsBody);
            }

            //

            nextState = State.battle;
        }

        internal override void update()
        {
            base.update();

            if (state == nextState)
            {
                switch (state)
                {
                    case State.loading:
                        break;
                    case State.battle:
                        updateBattle();
                        break;
                    case State.battleEndInterval:
                        updateBattleEndInterval();
                        break;
                    default:
                        updateDefault();
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
                    case State.battleEnd:
                        loadBattleEnd();
                        break;
                    case State.showBattleResult:
                        loadShowBattleResult();
                        break;
                    case State.mainMenu:
                        loadMainMenu();
                        break;
                    case State.credits:
                        presentScene(new CreditsScene());
                        break;
                }
            }
        }

        internal override void didSimulatePhysics()
        {
            base.didSimulatePhysics();

            Shot.updateAll();
        }

        void loadBattle()
        {
            if (battleBeginTime.Equals(0.0f))
            {
                battleBeginTime = currentTime;
            }
        }

        void loadBattleEnd()
        {
            mothership.endBattle();
            botMothership.endBattle();
            battleEndTime = currentTime;
            nextState = State.battleEndInterval;
        }

        void loadShowBattleResult()
        {
            // TODO:
            var boxBattleResult = new BoxBattleResult(mothership, botMothership);
        }

        void loadMainMenu() {
            presentScene(new MainMenuScene());
        }

        void updateBattle()
        {
            if (mothership.health <= 0 || botMothership.health <= 0)
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

                List<Spaceship> aliveBotSpaceships = botMothership.spaceships.Where(spaceship => {
                    if (spaceship.destination != null)
                    {
                        if (spaceship.destination == spaceship.startingPosition)
                        {
                            return false;
                        }
                    }

                    if ((spaceship.position - spaceship.startingPosition).LengthSquared() < 4.0f)
                    {
                        return spaceship.health >= spaceship.maxHealth;
                    }

                    return spaceship.health > 0;
                }).ToList();

                if (aliveBotSpaceships.Count() > 0)
                {
                    Spaceship botSpaceship = aliveBotSpaceships[random.Next(aliveBotSpaceships.Count())];

                    var aliveSpaceships = mothership.spaceships.Where(spaceship =>
                    {
                        return spaceship.health > 0;
                    }).OrderByDescending(spaceship => {
                        float value = spaceship.health;

                        if (spaceship.element.weakness == botSpaceship.element.type)
                        {
                            value /= Element.damageMultiplier;
                        }

                        if (spaceship.element.strength == botSpaceship.element.type)
                        {
                            value *= Element.damageMultiplier;
                        }

                        return value;
                    });

                    var targets = aliveSpaceships.Where(spaceship => {
                        if (spaceship.targetNode is Mothership)
                        {
                            var point = new Vector2(spaceship.position.X, spaceship.targetNode.position.Y);
                            if (spaceship.position.distanceTo(point) <= spaceship.weaponRange + botMothership.size.Y / 2.0f)
                            {
                                return true;
                            }
                        }
                        return false;
                    });

                    if (targets.Count() > 0)
                    {
                        botSpaceship.setTarget(targets.First());
                    }
                    else
                    {
                        if (botSpaceship.targetNode != null)
                        {
                            if (botSpaceship.health < botSpaceship.maxHealth / 2)
                            {
                                botSpaceship.retreat();
                            }
                        }
                        else
                        {
                            if (botSpaceship.physicsBody != null)
                            {
                                SKPhysicsBody botSpaceshipPhysicsBody = botSpaceship.physicsBody;
                                if (botSpaceshipPhysicsBody.BodyType == BodyType.Dynamic || botSpaceship.health == botSpaceship.maxHealth)
                                {
                                    if (botSpaceship.health < botSpaceship.maxHealth)
                                    {
                                        botSpaceship.retreat();
                                    }
                                    else
                                    {
                                        targets = aliveSpaceships.Where(spaceship =>
                                        {
                                            if (spaceship.targetNode is Spaceship)
                                            {
                                                return spaceship.element.weakness == botSpaceship.element.type;
                                            }
                                            return false;
                                        });

                                        if (targets.Count() > 0)
                                        {
                                            botSpaceship.setTarget(targets.First());
                                        }
                                        else
                                        {
                                            var x = random.Next(-55 / 2, 55 / 2);
                                            var y = random.Next((int)(Mothership.height / 2.0f), (int)Mothership.height);
                                            var point = botSpaceship.position + new Vector2(x, y);
                                            if (mothership.contains(point))
                                            {
                                                botSpaceship.setTarget(mothership);
                                            }
                                            else
                                            {
                                                botSpaceship.physicsBody.BodyType = BodyType.Dynamic;
                                                botSpaceship.destination = point;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        void updateBattleEndInterval()
        {
            mothership.update();
            botMothership.update();

            if (currentTime - battleBeginTime > 3)
            {
                nextState = State.showBattleResult;
            }
        }

        void updateDefault()
        {
            mothership.update();
            botMothership.update();
        }


        internal override void touchDown(Touch touch)
        {
            base.touchDown(touch);

            switch (state)
            {
                case State.battle:
                    touchDownBattle(touch);
                    break;
            }
        }

        internal override void touchMoved(Touch touch)
        {
            base.touchMoved(touch);

            switch (state)
            {
                case State.battle:
                    touchMovedBattle(touch);
                    break;
            }
        }

        internal override void touchUp(Touch touch)
        {
            base.touchUp(touch);

            switch (state)
            {
                case State.battle:
                    touchUpBattle(touch);
                    break;
            }
        }

        void touchDownBattle(Touch touch)
        {
            if (botMothership.parent != null)
            {
                if (botMothership.contains(touch.locationIn(botMothership.parent)))
                {
                    Spaceship.selectedSpaceship?.setTarget(botMothership);
                    return;
                }
            }

            Spaceship nearestSpaceship = getNearestSpaceship(new[] { mothership.spaceships, botMothership.spaceships }, touch);

            if (nearestSpaceship != null)
            {
                switch (nearestSpaceship.team)
                {
                    case Mothership.Team.red:
                        Spaceship.selectedSpaceship?.setTarget(nearestSpaceship);
                        break;
                    case Mothership.Team.green:
                        break;
                    case Mothership.Team.blue:
                        nearestSpaceship.touchUp(touch);
                        break;
                }
                return;
            }

            if (mothership.parent != null)
            {
                if (mothership.contains(touch.locationIn(mothership.parent)))
                {
                    Spaceship.selectedSpaceship?.retreat();
                    return;
                }
            }

            Spaceship.selectedSpaceship?.touchUp(touch);
        }

        void touchMovedBattle(Touch touch)
        {
            if (mothership.parent != null)
            {
                if (mothership.contains(touch.locationIn(mothership.parent)))
                {
                    return;
                }
            }

            if (botMothership.parent != null)
            {
                if (botMothership.contains(touch.locationIn(botMothership.parent)))
                {
                    return;
                }
            }

            Spaceship.selectedSpaceship?.touchUp(touch);
        }

        void touchUpBattle(Touch touch) {
            if (mothership.parent != null)
            {
                if (botMothership.contains(touch.locationIn(botMothership.parent)))
                {
                    Spaceship.selectedSpaceship?.setTarget(botMothership);
                    return;
                }
            }

            Spaceship nearestSpaceship = getNearestSpaceship(new[] { mothership.spaceships, botMothership.spaceships }, touch);

            if (nearestSpaceship != null)
            {
                switch (nearestSpaceship.team)
                {
                    case Mothership.Team.red:
                        Spaceship.selectedSpaceship?.setTarget(nearestSpaceship);
                        break;
                    case Mothership.Team.green:
                        break;
                    case Mothership.Team.blue:
                        if ((nearestSpaceship.position - nearestSpaceship.startingPosition).LengthSquared() > 4.0f)
                        {
                            nearestSpaceship.touchUp(touch);
                        }
                        else
                        {
                            nearestSpaceship.physicsBody.BodyType = BodyType.Dynamic;
                            nearestSpaceship.retreating = false;
                        }
                        break;
                }
                return;
            }

            if (botMothership.parent != null)
            {
                if (botMothership.contains(touch.locationIn(botMothership.parent)))
                {
                    if (Spaceship.selectedSpaceship != null)
                    {
                        Spaceship selectedSpaceship = Spaceship.selectedSpaceship;
                        if (selectedSpaceship.position.distanceTo(selectedSpaceship.startingPosition) > 4.0f)
                        {
                            selectedSpaceship.retreat();
                            selectedSpaceship.retreating = true;
                        }
                    }
                    return;
                }
            }

            Spaceship.selectedSpaceship?.touchUp(touch);
        }

        Spaceship getNearestSpaceship(IEnumerable<Spaceship>[] lists, Touch touch)
        {
            var spaceshipsAtPoint = new List<Spaceship>();

            foreach (List<Spaceship> list in lists)
            {
                foreach (Spaceship spaceship in list)
                {
                    if (spaceship.parent != null && spaceship.health > 0)
                    {
                        if (spaceship.contains(touch.locationIn(spaceship.parent)))
                        {
                            spaceshipsAtPoint.Add(spaceship);
                        }
                    }
                }
            }

            Spaceship nearestSpaceship = null;

            foreach (Spaceship spaceship in spaceshipsAtPoint)
            {
                if (spaceship.parent != null)
                {
                    if (nearestSpaceship != null)
                    {
                        var touchPosition = touch.locationIn(spaceship.parent);
                        if (touchPosition.distanceTo(spaceship.position) < touchPosition.distanceTo(nearestSpaceship.position))
                        {
                            nearestSpaceship = spaceship;
                        }
                    }
                    else
                    {
                        nearestSpaceship = spaceship;
                    }
                }
            }

            return nearestSpaceship;
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
