using System;

using Realms;

namespace Hydra
{
    public class PlayerData : RealmObject
    {
        public int points { get; set; }

        public PlayerData()
        {
            points = 0;
        }
    }
}
