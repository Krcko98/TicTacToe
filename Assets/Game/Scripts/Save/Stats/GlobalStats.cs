using System.Collections.Generic;
using UnityEngine;

namespace Game.Save.Stats
{
    public class GlobalStats : MonoBehaviour
    {
        public StatsData statsData;

        public static GlobalStats Instance = null;

        public void Init()
        {
            if(GlobalStats.Instance != null) return;
            GlobalStats.Instance = this;

            LoadAllStats();
        }

        public void LoadAllStats()
        {
            statsData = SaveLoad.Load<StatsData>(SaveLoad.PrefType.globalStats);
        }

        public void SaveStats()
        {
            SaveLoad.Save<StatsData>(SaveLoad.PrefType.globalStats, statsData);
        }
    }
}