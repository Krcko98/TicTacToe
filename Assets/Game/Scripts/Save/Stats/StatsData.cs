using System;
using UnityEngine;

namespace Game.Save.Stats
{
    [Serializable]
    public struct StatsData
    {
        [Serializable]
        public struct PlayerStatsData
        {
            public int playerID;
            public int gamesWon;

            public PlayerStatsData(
                int playerID,
                int gamesWon
            )
            {
                this.playerID = playerID;
                this.gamesWon = gamesWon;
            }
        }

        public int gamesPlayed;
        public int averageGameDuration;
        public int gamesDraw;
        public PlayerStatsData player1;
        public PlayerStatsData player2;

        public StatsData(
            int gamesPlayed, 
            int averageGameDuration,
            int gamesDraw,
            PlayerStatsData player1, 
            PlayerStatsData player2
        )
        {
            this.gamesPlayed = gamesPlayed;
            this.averageGameDuration = averageGameDuration;
            this.gamesDraw = gamesDraw;
            this.player1 = player1;
            this.player2 = player2;
        }
    }
}