using Game.CameraNS;
using Game.Gameplay.Board;
using Game.Gameplay.Board.Data;
using UnityEngine;

namespace Game.Gameplay
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameplayCameraController cameraController;
        [SerializeField] private GameBoard gameBoard;

        public GameplayCameraController CameraController { get => cameraController; }

        public static GameController Instance = null;

        public void Awake()
        {
            if(GameController.Instance == null)
            {
                GameController.Instance = this;
            }
        }

        public void Init()
        {
            cameraController.Init();
            gameBoard.Init(new GameBoardData(
                
            ));
        }
    }
}