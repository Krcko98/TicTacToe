using UnityEngine;
using Unity.Cinemachine;
using System.Collections.Generic;
using Game.CameraNS.Utils;

namespace Game.CameraNS
{
    public class GameplayCameraController : MonoBehaviour
    {
        [SerializeField] private Animator cameraStateAnim;
        [SerializeField] private CinemachineStateDrivenCamera stateDrivenCamera;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private CinemachineCamera cineCamera;

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

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            SetState(CameraState.look);
        }

        public void SetState(CameraState state)
        {
            if(!cameraStateAnim.GetCurrentAnimatorStateInfo(0).IsName(states[state]))
            {
                cameraStateAnim.Play(states[state]);
            }
        }
    }
}
