using UnityEngine;

namespace Game.SM.Gameloop.Data
{
    public class GameLoopGameplayStateData
    {
        public SMGameloop gameLoop;

        public GameLoopGameplayStateData(SMGameloop gameLoop)
        {
            this.gameLoop = gameLoop;
        }
    }
}