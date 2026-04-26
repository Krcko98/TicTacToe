using System;
using System.Collections;
using Game.Gameplay;
using Game.Manager;
using Game.SM.Gameloop.Data;
using Tasks.CoroutineExtension;
using Tasks.CoroutineExtension.Presets;
using UnityEngine;

namespace Game.SM.Gameloop
{
    public class SMGameloopGameplayState : SMState
    {
        private SMGameloop gameLoop;

        public override void Init<T>(T data)
        {
            GameLoopGameplayStateData loopData = data as GameLoopGameplayStateData;

            gameLoop = loopData.gameLoop;
        }

        public override void Enter()
        {
            SceneManager.OnSceneChanged += sceneChanged;
            SceneManager.Instance.LoadScene(SceneManager.SceneType.gameplay);
        }

        public override void Loop()
        {
            
        }

        public override void Exit()
        {
            
        }

        private void sceneChanged(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
        {
            new Task(TaskPresets.delayStartOfNewFrame(() => GameController.Instance.Init()));

            SceneManager.OnSceneChanged -= sceneChanged;
        }
    }
}