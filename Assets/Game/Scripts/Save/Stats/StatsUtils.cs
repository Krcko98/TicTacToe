using System;
using UnityEngine;

namespace Game.Save.Stats
{
    public static class StatsUtils
    {
        public static StatsData DefaultStatsData()
        {
            return new StatsData(
                gamesPlayed: 0,
                averageGameDuration: 0,
                gamesDraw: 0,
                player1: new StatsData.PlayerStatsData(
                    playerID: 0,
                    gamesWon: 0
                ),
                player2: new StatsData.PlayerStatsData(
                    playerID: 1,
                    gamesWon: 0
                )
            );
        }

        public static string gamesPlayed(string games)
        {
            return string.Format("Games played : {0}", games);
        }

        public static string playerGamesWon(string playerID, string games)
        {
            string data = string.Format("Player 1 wins : {0}", games);

            if(playerID == "1")
                data = string.Format("Player 2 wins : {0}", games);

            return data;
        }

        public static string gamesDraw(string games)
        {
            return string.Format("Games draw : {0}", games);
        }

        public static string averageGameDuration(string time)
        {
            TimeSpan span = TimeSpan.FromSeconds(float.Parse(time));
            return string.Format("Average game time : {0}", span.ToString(@"mm\:ss"));
        }
    }
}