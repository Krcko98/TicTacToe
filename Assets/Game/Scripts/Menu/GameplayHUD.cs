using System;
using CustomButton;
using Game.Popup.Menu;
using TMPro;
using UnityEngine;

namespace Game.Menu.GameplayHUD
{
    public class GameplayHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moveCount;
        [SerializeField] private TextMeshProUGUI timer;
        [SerializeField] private CustomButtonBase settingsButton;
        [SerializeField] private SettingsPopup settingsPopup;

        public void Init()
        {
            settingsButton.onClick.AddListener(settingsClicked);
        }

        public void SetTime(float timeElapsed)
        {
            TimeSpan span = TimeSpan.FromSeconds(timeElapsed);
            timer.text = span.ToString(@"mm\:ss");
        }

        public void SetMoveCount(int player1, int player2)
        {
            moveCount.text = string.Format("Moves <br>(P1: {0} P2: {1})", player1, player2);
        }

        private void settingsClicked()
        {
            settingsPopup.Open();
            settingsPopup.DeclineButton.onClick.AddListener(closeSettings);
        }

        private void closeSettings()
        {
            settingsPopup.Close();
        }

        public void OnDestroy()
        {
            settingsButton.onClick.RemoveListener(settingsClicked);
        }
    }
}