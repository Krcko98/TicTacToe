using Game.CameraNS;
using Game.Delegate;
using Game.Gameplay.Board;
using Game.Gameplay.Board.Data;
using Game.Gameplay.Board.Tile;
using Game.SM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Gameplay
{
    public class GameController : MonoBehaviour
    {
        public class GameData
        {
            public int currentActivePlayer = 1;
        }

        [SerializeField] private GameplayCameraController cameraController;
        [SerializeField] private GameBoard gameBoard;

        //Game data
        public GameData gameData = new GameData();

        private SMGameplay gameplaySM = new SMGameplay();

        public DelegateCollection.OnTilePointerClickDelegate OnTileSelected;

        public static GameController Instance = null;

        public GameplayCameraController CameraController { get => cameraController; }
        public GameBoard GameBoard { get => gameBoard; }


        public void Awake()
        {
            if(GameController.Instance == null)
            {
                GameController.Instance = this;
            }
        }

        public void Init()
        {
            //Data setup
            gameData.currentActivePlayer = 1;

            cameraController.Init();
            gameBoard.Init(new GameBoardData(
                tileClicked: tileClicked,
                tilePointerExit: tileEnter,
                tilePointerEnter: tileExit
            ));

            gameplaySM.Init();
        }

        #region TileCallback
        private void tileClicked(BoardTile tile, PointerEventData data)
        {
            if(GameBoard.Board[tile.BoardLocation.x][tile.BoardLocation.y] != 0) return;

            OnTileSelected?.Invoke(tile, data);
        }

        private void tileEnter(BoardTile tile, PointerEventData data)
        {
            
        }

        private void tileExit(BoardTile tile, PointerEventData data)
        {
            
        }
        #endregion
    }
}