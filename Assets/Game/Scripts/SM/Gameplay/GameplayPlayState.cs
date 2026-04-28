using Game.Gameplay;
using Game.Gameplay.Board.Tile;
using Game.Manager;
using Game.Save.Stats;
using Game.SM.Gameplay.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using static Game.Gameplay.Board.GameBoard;

namespace Game.SM.Gameplay
{
    public class GameplayPlayState : SMState
    {
        private GameplayPlayStateData data;
        private float timeStart = 0f;
        private bool timeCounting = false;

        public override void Init<T>(T data)
        {
            this.data = data as GameplayPlayStateData;
        }

        public override void Enter()
        {
            GameController.Instance.OnTileSelected += tileSelected;
Debug.Log("playing");
            GameController.Instance.gameData.currentActivePlayer = 1;
            
            timeCounting = true;
            timeStart = Time.time;
        }

        private void tileSelected(BoardTile tile, PointerEventData data)
        {
            int player = GameController.Instance.gameData.currentActivePlayer;

            tile.SetObject(ThemeManager.ActiveTheme.tileObject.Find(x => x.BoardObjectType == (BoardObjectType)(player-1)));
            GameController.Instance.GameBoard.Board[tile.BoardLocation.x][tile.BoardLocation.y] = player;

            GameController.Instance.gameData.currentActivePlayer = player == 1 ? 2 : 1;
            GameController.Instance.gameData.turnAmount++;
            if(player == 1)
            {
                GameController.Instance.gameData.turnPlayer1++;

                AudioManager.Instance.PlaySound(ThemeManager.ActiveTheme.boardClickP1);
            }
            else
            {
                GameController.Instance.gameData.turnPlayer2++;

                AudioManager.Instance.PlaySound(ThemeManager.ActiveTheme.boardClickP2);
            }

            GameController.Instance.HUD.SetMoveCount(GameController.Instance.gameData.turnPlayer1, GameController.Instance.gameData.turnPlayer2);

            GameBoardStatus boardStatus = GameController.Instance.GameBoard.GetBoardStatus();

            if(boardStatus.matchingStatus != 0)
            {
                saveGameInfo(boardStatus.matchingStatus);

                GameController.Instance.gameData.winningPlayer = boardStatus.matchingStatus;

                AudioManager.Instance.PlaySound(ThemeManager.ActiveTheme.winnerAudio);

                this.data.gameplaySM.ChangeState(SMGameplay.GameplayState.finishGame);

                return;
            }
            
            if(GameController.Instance.gameData.turnAmount == 9)
            {
                saveGameInfo(0);

                AudioManager.Instance.PlaySound(ThemeManager.ActiveTheme.winnerAudio);

                this.data.gameplaySM.ChangeState(SMGameplay.GameplayState.finishGame);
            }
        }

        private void saveGameInfo(int playerWon)
        {
            StatsData data = GlobalStats.Instance.statsData;

            //Save game data
            data.gamesPlayed++;
            if(playerWon == 0)
            {
                data.gamesDraw++;
            }
            else if(playerWon == 1)
            {
                data.player1.gamesWon++;
            }
            else if(playerWon == 2)
            {
                data.player2.gamesWon++;
            }
            data.averageGameDuration = (data.averageGameDuration * (data.gamesPlayed-1) + 
            GameController.Instance.gameData.timePassed) / data.gamesPlayed;

            GlobalStats.Instance.SaveStats();
        }

        public override void Loop()
        {
            if(!timeCounting) return;

            GameController.Instance.gameData.timePassed = Time.time - timeStart;
            GameController.Instance.HUD.SetTime(GameController.Instance.gameData.timePassed);
        }

        public override void Exit()
        {
            GameController.Instance.OnTileSelected -= tileSelected;
            timeStart = 0;
            timeCounting = false;
        }
    }
}