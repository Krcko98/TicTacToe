using System.Collections.Generic;
using Game.Popup.Data;
using Game.Popup.Menu.Stats;
using Game.Save.Stats;
using Game.Save.Stats.Data;
using Popup.UI;
using UnityEngine;
using System;
using Utils.UI;
using TMPro;
using System.Collections;

namespace Game.Popup.Menu
{
    public class StatsPopup : UIPopup
    {
        [SerializeField] private RectTransform statsParent;
        [SerializeField] private UIStat statPref;

        private List<UIStat> statsList = new List<UIStat>();
        private StatsData prevData;

        public override void Open<PopupData>(PopupData data)
        {
            base.Open(data);

            StatsPopupData popupData = data as StatsPopupData;
            DeclineButton.onClick.AddListener(() => popupData.popupDeclined(this));

            prevData = popupData.stats;
            createStatView(popupData.stats);
        }

        private void createStatView(StatsData stats)
        {
            cleanupStatView();

            UIStatData[] data = new UIStatData[]
            {
                new UIStatData(
                    stats.gamesPlayed.ToString(), 
                    (string data) => StatsUtils.gamesPlayed(data)
                ),
                new UIStatData(
                    stats.player1.gamesWon.ToString(), 
                    (string data) => StatsUtils.playerGamesWon("0", data)
                ),
                new UIStatData(
                    stats.player2.gamesWon.ToString(), 
                    (string data) => StatsUtils.playerGamesWon("1", data)
                ),
                new UIStatData(
                    stats.gamesDraw.ToString(), 
                    (string data) => StatsUtils.gamesDraw(data)
                ),
                new UIStatData(
                    stats.averageGameDuration.ToString(), 
                    (string data) => StatsUtils.averageGameDuration(data)
                )
            };
            List<TextMeshProUGUI> tmpList = new List<TextMeshProUGUI>();

            statPref.gameObject.SetActive(false);

            for(int i=0; i<data.Length; i++)
            {
                UIStat tempStat = Instantiate(statPref, statsParent);
                tempStat.gameObject.SetActive(true);
                tempStat.Init(data[i]);

                tmpList.Add(tempStat.Text);
                statsList.Add(tempStat);
            }

            UITools.LowestCommonTextSizeFromTMP(tmpList);
        }

        private void cleanupStatView()
        {
            foreach(UIStat stat in statsList)
            {
                Destroy(stat.gameObject);
            }

            statsList.Clear();
        }

        public void OnDestroy()
        {
            DeclineButton.onClick.RemoveAllListeners();
        }
    }
}