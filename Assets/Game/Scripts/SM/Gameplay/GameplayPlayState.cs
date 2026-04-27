using Game.Gameplay;
using Game.Gameplay.Board.Tile;
using Game.Manager;
using Game.SM;
using Game.SM.Gameplay.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using static Game.Gameplay.Board.GameBoard;

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
            int player = GameController.Instance.gameData.currentActivePlayer;

            tile.SetObject(ThemeManager.ActiveTheme.tileObject.Find(x => x.BoardObjectType == (BoardObjectType)(player-1)));
            GameController.Instance.GameBoard.Board[tile.BoardLocation.x][tile.BoardLocation.y] = player;

            GameController.Instance.gameData.currentActivePlayer = player == 1 ? 2 : 1;
            GameController.Instance.gameData.turnAmount++;

            GameBoardStatus boardStatus = GameController.Instance.GameBoard.GetBoardStatus();

            for(int i=0; i<3; i++)
            {
                Debug.LogFormat("{0} {1} {2}", 
                    GameController.Instance.GameBoard.Board[i][0],
                    GameController.Instance.GameBoard.Board[i][1],
                    GameController.Instance.GameBoard.Board[i][2]
                );
            }

            //Debug.Log(boardStatus.matchingStatus);

            if(boardStatus.matchingStatus != 0)
            {
                this.data.gameplaySM.ChangeState(SMGameplay.GameplayState.finishGame);
            }
            
            if(GameController.Instance.gameData.turnAmount == 9)
            {
                Debug.Log("Draw");
                this.data.gameplaySM.ChangeState(SMGameplay.GameplayState.finishGame);
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