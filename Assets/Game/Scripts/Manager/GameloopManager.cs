using Game.SM;
using UnityEngine;

namespace Game.Manager
{
    public class GameloopManager : MonoBehaviour
    {
        public SMGameloop.GameloopState GameState = SMGameloop.GameloopState.init;
        
        private SMGameloop smGameloop;

        public static GameloopManager Instance = null;

        public void Init()
        {
            if(GameloopManager.Instance != null) return;
            GameloopManager.Instance = this;

            smGameloop = new SMGameloop();
            smGameloop.Init();

            smGameloop.ChangeState(SMGameloop.GameloopState.mainMenu);
        }

        private void Update()
        {
            smGameloop.UpdateSM();
        }

        public void StartGame()
        {
            smGameloop.ChangeState(SMGameloop.GameloopState.gameplay);
        }
    }
}