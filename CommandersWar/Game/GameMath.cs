using System;
using Hydra;

namespace CommandersWar.Game
{
    public class GameMath
    {
        internal static int unlockSpaceshipPriceInPremiumPoints(Spaceship.Rarity rarity)
        {
            double price = 12.5 / 2.0 * Math.Pow(2.0, (double)rarity);
            return (int)price;
        }

        internal static int buySpaceshipPriceInPremiumPoints(Spaceship.Rarity rarity)
        {
            double price = 12.5 * Math.Pow(2.0, (double)rarity);
            return (int)price;
        }

        internal static int unlockSpaceshipPriceInPoints(Spaceship.Rarity rarity)
        {
            double price = 62500.0 / 2.0 * Math.Pow(2.0, (double)rarity);
            return (int)price;
        }

        internal static int buySpaceshipPriceInPoints(Spaceship.Rarity rarity)
        {
            double price = 62500.0 * Math.Pow(2.0, (double)rarity);
            return (int)price;
        }

        internal static int xpForLevel(int level)
        {
            double x = level - 1;
            double xp = Math.Pow(2, x) * 1000;
            return (int)xp;
        }

        internal static int randomBaseRange(Spaceship.Rarity rarity)
        {
            double min = 0.9;
            double max = 1.1;

            double x = min + SKNode.random.NextDouble() * (max - min);

            switch (rarity)
            {
                case Spaceship.Rarity.common:
                    x = x * 178;
                    break;
                case Spaceship.Rarity.uncommon:
                    x = x * 122;
                    break;
                case Spaceship.Rarity.rare:
                    x = x * 122;
                    break;
                case Spaceship.Rarity.heroic:
                    x = x * 84;
                    break;
                case Spaceship.Rarity.epic:
                    x = x * 84;
                    break;
                case Spaceship.Rarity.legendary:
                    x = x * 58;
                    break;
                case Spaceship.Rarity.supreme:
                    x = x * 58;
                    break;
            }

            return (int)Math.Round(x);
        }

        internal static int range(int level, int baseRange)
        {
            return (int)(baseRange * Math.Pow(1.1, level - 1));
        }

        internal static int randomBaseDamage(Spaceship.Rarity rarity)
        {
            double min = 0.9;
            double max = 1.1;

            double x = min + SKNode.random.NextDouble() * (max - min);

            switch (rarity)
            {
                case Spaceship.Rarity.common:
                    x = x * 11;
                    break;
                case Spaceship.Rarity.uncommon:
                    x = x * 16;
                    break;
                case Spaceship.Rarity.rare:
                    x = x * 23;
                    break;
                case Spaceship.Rarity.heroic:
                    x = x * 34;
                    break;
                case Spaceship.Rarity.epic:
                    x = x * 50;
                    break;
                case Spaceship.Rarity.legendary:
                    x = x * 73;
                    break;
                case Spaceship.Rarity.supreme:
                    x = x * 107;
                    break;
            }

            return (int)Math.Round(x);
        }

        internal static int damage(int level, int baseDamage)
        {
            return (int)(baseDamage * Math.Pow(1.1, level - 1));
        }

        internal static int randomBaseLife(Spaceship.Rarity rarity)
        {
            double min = 0.9;
            double max = 1.1;

            double x = min + SKNode.random.NextDouble() * (max - min);

            switch (rarity)
            {
                case Spaceship.Rarity.common:
                    x = x * 550;
                    break;
                case Spaceship.Rarity.uncommon:
                    x = x * 800;
                    break;
                case Spaceship.Rarity.rare:
                    x = x * 1150;
                    break;
                case Spaceship.Rarity.heroic:
                    x = x * 1700;
                    break;
                case Spaceship.Rarity.epic:
                    x = x * 2500;
                    break;
                case Spaceship.Rarity.legendary:
                    x = x * 3650;
                    break;
                case Spaceship.Rarity.supreme:
                    x = x * 5350;
                    break;
            }

            return (int)Math.Round(x);
        }

        internal static int maxHealth(int level, int baseLife)
        {
            return (int)(baseLife * Math.Pow(1.1, level - 1));
        }

        internal static int randomBaseSpeed(Spaceship.Rarity rarity)
        {
            double min = 0.9;
            double max = 1.1;

            double x = min + SKNode.random.NextDouble() * (max - min);

            switch (rarity)
            {
                case Spaceship.Rarity.common:
                    x = x * 20;
                    break;
                case Spaceship.Rarity.uncommon:
                    x = x * 19;
                    break;
                case Spaceship.Rarity.rare:
                    x = x * 18;
                    break;
                case Spaceship.Rarity.heroic:
                    x = x * 17;
                    break;
                case Spaceship.Rarity.epic:
                    x = x * 16;
                    break;
                case Spaceship.Rarity.legendary:
                    x = x * 15;
                    break;
                case Spaceship.Rarity.supreme:
                    x = x * 14;
                    break;
            }

            return (int)Math.Round(x);
        }

        internal static int speed(int level, int baseSpeed)
        {
            return (int)(baseSpeed * Math.Pow(1.1, level - 1));
        }

        internal static float spaceshipMaxVelocitySquared(int speedAtribute)
        {
            float maxVelocity = speedAtribute * 6.0f;
            return maxVelocity * maxVelocity;
        }
    }
}
