using System;
using System.Collections.Generic;
using System.Text;

namespace Concordia.Common
{
    public class Player
    {
        public Player(string name, string avatarUrl, int gender, int? district)
        {
            Name = name ?? string.Empty;
            AvatarUrl = avatarUrl ?? string.Empty;
            Gender = (gender <= 2 && gender >= 0) ? gender : 0;
            District = district ?? null;
            IsAlive = true;
        }

        public void Kill()
        {
            IsAlive = false;
        }

        public string Name { get; private set; }

        public string AvatarUrl { get; private set; }

        public int Gender { get; set; }

        public int? District { get; set; }

        public bool IsAlive { get; set; }
    }
}
