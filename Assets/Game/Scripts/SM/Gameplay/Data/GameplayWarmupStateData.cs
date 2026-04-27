using Game.CameraNS;
using UnityEngine;

namespace Game.SM.Gameplay.Data
{
    public class GameplayWarmupStateData
    {
        public SMGameplay gameplaySM;

        public GameplayWarmupStateData(SMGameplay gameplaySM)
        {
            this.gameplaySM = gameplaySM;
        }
    }
}