using Game.Manager;
using Game.SM.Gameloop.Data;
using UnityEngine;

namespace Game.SM.Gameloop
{
    public class SMGameloopMenuState : SMState
    {
        private SMGameloop gameLoop;

        public override void Init<T>(T data)
        {
            GameLoopMenuStateData loopData = data as GameLoopMenuStateData;

            gameLoop = loopData.gameLoop;
        }

        public override void Enter()
        {
            SceneManager.Instance.LoadScene(SceneManager.SceneType.menu);
        }

        public override void Loop()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}