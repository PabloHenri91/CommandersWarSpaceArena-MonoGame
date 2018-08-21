using System;

using Hydra;

using static CommandersWar.Game.GameMusic;

namespace CommandersWar.Game
{
    class GameMusic
    {
        internal static MusicType musicType = MusicType.noMusic;

        internal enum MusicType
        {
            noMusic,
            menu,
            battle
        }

        internal static string[] menu = {
            "klamm_cracks"
        };

        internal static string[] battle = {
            "klamm_airborne",
            "klamm_atmosphere",
            "klamm_battleship",
            "klamm_destroyer",
            "klamm_ice-and-fire",
            "klamm_infinity",
            "klamm_prisma",
            "klamm_vortex",
            "Scorpion"
        };
    }

    static class MusicExtension
    {
        internal static void play(this Music music, MusicType musicType)
        {
            if (GameMusic.musicType == musicType) { return; }

            GameMusic.musicType = musicType;

            switch (musicType)
            {
                case MusicType.menu:
                    music.play(menu[SKNode.random.Next(menu.Length)]);
                    break;
                case MusicType.battle:
                    music.play(battle[SKNode.random.Next(battle.Length)]);
                    break;
            }
        }
    }
}

