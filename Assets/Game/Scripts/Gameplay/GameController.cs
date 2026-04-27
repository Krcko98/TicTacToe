using System;
using Game.CameraNS;
using Game.Delegate;
using Game.Gameplay.Board;
using Game.Gameplay.Board.Data;
using Game.Gameplay.Board.Tile;
using Game.Menu.GameplayHUD;
using Game.Popup.Menu;
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
            public int turnAmount = 0;
            public int turnPlayer1 = 0;
            public int turnPlayer2 = 0;
            public float timePassed = 0;
            public int winningPlayer = 0;
        }

        [SerializeField] private GameplayCameraController cameraController;
        [SerializeField] private GameBoard gameBoard;
        [SerializeField] private GameplayHUD gameUI;
        [SerializeField] private EndgamePopup endGamePopup;

        //Game data
        public GameData gameData = new GameData();

        private SMGameplay gameplaySM = new SMGameplay();

        public DelegateCollection.OnTilePointerClickDelegate OnTileSelected;

        public static GameController Instance = null;

        public GameplayCameraController CameraController { get => cameraController; }
        public GameBoard GameBoard { get => gameBoard; }
        public GameplayHUD HUD { get => gameUI; }
        public EndgamePopup EndGamePopup { get => endGamePopup; }

        public void Awake()
        {
            if(GameController.Instance == null)
            {
                GameController.Instance = this;
            }
        }

        private void Update()
        {
            gameplaySM.UpdateSM();
        }

        public void Init()
        {
            //Data setup
            gameData.currentActivePlayer = 1;
            gameData.turnAmount = 0;
            gameData.timePassed = 0;
            gameData.turnPlayer1 = 0;
            gameData.turnPlayer2 = 0;
            gameData.winningPlayer = 0;

            cameraController.Init();
            gameBoard.Init(new GameBoardData(
                tileClicked: tileClicked,
                tilePointerExit: tileEnter,
                tilePointerEnter: tileExit
            ));

            gameUI.Init();
            gameUI.SetTime(0);
            gameUI.SetMoveCount(0, 0);

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