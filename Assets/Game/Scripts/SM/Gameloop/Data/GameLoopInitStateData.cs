using UnityEngine;

namespace Game.SM.Gameloop.Data
{
    public class GameLoopInitStateData
    {
        public SMGameloop gameLoop;

        public GameLoopInitStateData(SMGameloop gameLoop)
        {
            this.gameLoop = gameLoop;
        }
    }
}