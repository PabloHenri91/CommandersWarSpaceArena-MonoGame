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
    class SpaceshipHealthBar : SKSpriteNode
    {
        internal Vector2 positionOffset;

        SKSpriteNode fill;

        internal Label labelLevel;
        Label labelHealth;

        public SpaceshipHealthBar(int level, int health, Mothership.Team team, Spaceship.Rarity rarity) : base("spaceshipHealthBarBackground")
        {
            Color teamColor = Color.Transparent;
            Color rarityColor = Spaceship.colorFor(rarity);

            switch (team)
            {
                case Mothership.Team.red:
                    teamColor = GameColors.redTeam;
                    positionOffset = new Vector2(0.0f, -Spaceship.radius - 8.0f);
                    break;
                case Mothership.Team.green:
                case Mothership.Team.blue:
                    teamColor = GameColors.blueTeam;
                    positionOffset = new Vector2(0.0f, Spaceship.radius + 8.0f);
                    break;
            }

            fill = new SKSpriteNode("");
            fill.color = rarityColor;
            fill.size = new Vector2(size.X - 4.0f, size.Y - 4.0f);
            fill.position = new Vector2(-25.5f, 0);
            fill.anchorPoint = new Vector2(0.0f, 0.5f);
            addChild(fill);

            SKSpriteNode border = new SKSpriteNode("spaceshipHealthBarBorder");
            addChild(border);

            SKSpriteNode levelBackground = new SKSpriteNode("spaceshipHealthBarLevelBackground");
            levelBackground.position = new Vector2(-38.0f, 0);
            addChild(levelBackground);

            labelLevel = new Label($"{level}", 0, 0, HorizontalAlignment.left, VerticalAlignment.top, FontName.kenpixel, FontSize.size8);
            labelLevel.color = GameColors.fontBlack;
            levelBackground.addChild(labelLevel);

            color = teamColor;
            fill.color = rarityColor;
            border.color = teamColor;
            levelBackground.color = teamColor;

            labelHealth = new Label($"{health}", 0, 0, HorizontalAlignment.left, VerticalAlignment.top, FontName.kenpixel, FontSize.size8);
            labelHealth.color = GameColors.fontBlack;
            labelHealth.position = new Vector2(0, 0.5f);
            addChild(labelHealth);
        }

        internal void update(int health, int maxHealth)
        {
            if (health > 0)
            {
                isHidden = false;
                labelHealth.text = health.ToString();
                fill.size = new Vector2(size.X * ((float)health / (float)maxHealth) - 4.0f, fill.size.Y);
            }
            else
            {
                isHidden = true;
            }
        }
    }
}
