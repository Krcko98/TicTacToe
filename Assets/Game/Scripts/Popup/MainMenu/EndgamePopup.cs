using System;
using Game.Popup.Data;
using Popup.UI;
using TMPro;
using UnityEngine;

namespace Game.Popup.Menu
{
    public class EndgamePopup : UIPopup
    {
        [SerializeField] private TextMeshProUGUI winnerText;
        [SerializeField] private TextMeshProUGUI averageTimeText;

        private EndgamePopupData data;

        public override void Open<T>(T data)
        {
            AcceptButton.onClick.AddListener(() => this.data.popupAccepted(this));
            DeclineButton.onClick.AddListener(() => this.data.popupDeclined(this));


            base.Open(data);

            this.data = data as EndgamePopupData;
            TimeSpan span = TimeSpan.FromSeconds(this.data.gameTime);

            if(this.data.winnerPlayer != 0)
                winnerText.text = string.Format("Winner is <br><b>Player{0}</b>", this.data.winnerPlayer);
            else
                winnerText.text = string.Format("Draw");

            averageTimeText.text = span.ToString(@"mm\:ss");
        }
    }
}