using Game.CameraNS;
using Game.SM;
using Game.SM.Gameplay.Data;
using UnityEngine;

namespace Game.SM.Gameplay
{
    public class GameplayWarmupState : SMState
    {
        private GameplayWarmupStateData data;

        public override void Init<T>(T data)
        {
            this.data = data as GameplayWarmupStateData;
        }

        private void cameraMovementDone(GameplayCameraController.CameraState state)
        {
            if(state == GameplayCameraController.CameraState.look)
            {
                data.gameplaySM.ChangeState(SMGameplay.GameplayState.playGame);
            }
        }

        public override void Enter()
        {
            GameplayCameraController.BlendFinished += cameraMovementDone;
        }

        public override void Loop()
        {
            
        }

        public override void Exit()
        {
            GameplayCameraController.BlendFinished -= cameraMovementDone;
        }
    }
}