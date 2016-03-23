using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Model
{
    class PlayerManager : IDisposable
    {
        private static PlayerManager playerManager;
        private IPlayer player;

        private PlayerManager() {
            if (Configuration.Instance.CrazyMode) {
                player = new MultithreadPlayer();
            } else {
                player = new Player();
            }
        }

        public static PlayerManager Instance
        {
            get
            {
                if (playerManager == null) {
                    playerManager = new PlayerManager();
                }
                return playerManager;
            }
        }

        public IPlayer Player
        {
            get
            {
                return player;
            }
        }

        public void Dispose()
        {
            if (player is MultithreadPlayer) {
                (player as MultithreadPlayer).Dispose();
            }
        }
    }
}
