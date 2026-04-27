using UnityEngine;
using Unity.Cinemachine;
using System.Collections.Generic;
using Game.CameraNS.Utils;
using System;
using Tasks.CoroutineExtension;
using Tasks.CoroutineExtension.Presets;

namespace Game.CameraNS
{
    public class GameplayCameraController : MonoBehaviour
    {
        [SerializeField] private Animator cameraStateAnim;
        [SerializeField] private CinemachineStateDrivenCamera stateDrivenCamera;
        [SerializeField] private CinemachineTargetGroup targetGroup;

        public static event Action<CameraState> BlendFinished;

        private Task blendingTask;

        public enum CameraState
        {
            entrance = 0,
            look = 1,
            COUNT
        }

        private Dictionary<CameraState, string>  states = new Dictionary<CameraState, string>()
        {
            { CameraState.entrance, "EntranceCamera" },
            { CameraState.look, "LookCamera" }
        };

        public void Init()
        {
            SetState(CameraState.look);
        }

        public void SetState(CameraState state)
        {
            if(cameraStateAnim.GetCurrentAnimatorStateInfo(0).IsName(states[state])) return;

            cameraStateAnim.Play(states[state]);

            blendingTask = new Task(
                TaskPresets.waitForSeconds(
                    3f,
                    () => BlendFinished?.Invoke(state)
                )
            );
        }
    }
}
