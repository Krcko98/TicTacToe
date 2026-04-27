using Game.Gameplay;
using Game.Gameplay.Board.Tile;
using Game.Manager;
using Game.SM;
using Game.SM.Gameplay.Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.SM.Gameplay
{
    public class GameplayPlayState : SMState
    {
        private GameplayPlayStateData data;

        public override void Init<T>(T data)
        {
            this.data = data as GameplayPlayStateData;
        }

        public override void Enter()
        {
            GameController.Instance.OnTileSelected += tileSelected;
Debug.Log("playing");
            GameController.Instance.gameData.currentActivePlayer = 1;
        }

        private void tileSelected(BoardTile tile, PointerEventData data)
        {
            if(GameController.Instance.gameData.currentActivePlayer == 1)
            {
                tile.SetObject(ThemeManager.ActiveTheme.tileObject.Find(x => x.BoardObjectType == Game.Gameplay.Board.GameBoard.BoardObjectType.X));
                GameController.Instance.GameBoard.Board[tile.BoardLocation.x][tile.BoardLocation.y] = 1;

                GameController.Instance.gameData.currentActivePlayer = 2;
            }
            else
            {
                tile.SetObject(ThemeManager.ActiveTheme.tileObject.Find(x => x.BoardObjectType == Game.Gameplay.Board.GameBoard.BoardObjectType.O));
                GameController.Instance.GameBoard.Board[tile.BoardLocation.x][tile.BoardLocation.y] = 2;

                GameController.Instance.gameData.currentActivePlayer = 1;
            }
        }

        public override void Loop()
        {
            
        }

        public override void Exit()
        {
            GameController.Instance.OnTileSelected -= tileSelected;
        }
    }
}