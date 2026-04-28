using Game.Menu.Data;
using UnityEngine;
using UnityEngine.UI;
using CustomButton;
using Popup;
using Game.Delegate;
using Game.Popup.Menu;
using Game.Popup.Data;
using Game.Save.Stats;
using Game.Manager;
using Popup.UI;

namespace Game.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private CustomButtonBase startGameButton;
        [SerializeField] private CustomButtonBase statsButton;
        [SerializeField] private CustomButtonBase settingsButton;
        [SerializeField] private CustomButtonBase exitButton;

        [SerializeField] private StartGamePopup startPopup;
        [SerializeField] private StatsPopup statsPopup;
        [SerializeField] private SettingsPopup settingsPopup;

        public static event DelegateCollection.OnPlaySelectedDelegate OnStartGameSelected;
        public static event DelegateCollection.OnStatsSelectedDelegate OnStatsSelected; 
        public static event DelegateCollection.OnSettingsSelectedDelegate OnSettingsSelected; 
        public static event DelegateCollection.OnExitGameSelectedDelegate OnExitSelected;

        private void Awake()
        {
            Init(null);
        }

        public void Init(MainMenuData data)
        {
            addListeners();
        }

        private void addListeners()
        {
            startGameButton.onClick.AddListener(startSelected);
            statsButton.onClick.AddListener(statsSelected);
            settingsButton.onClick.AddListener(settingsSelected);
            exitButton.onClick.AddListener(exitSelected);
        }

        private void removeListeners()
        {
            startGameButton.onClick.RemoveListener(startSelected);
            statsButton.onClick.RemoveListener(statsSelected);
            settingsButton.onClick.RemoveListener(settingsSelected);
            exitButton.onClick.RemoveListener(exitSelected);
        }

        private void startSelected()
        {
            startPopup.Open(new StartGamePopupData(
                descriptionData: "",
                headerData: "Start game?",
                useAcceptButton: true,
                useDeclineButton: true,
                popupAccepted: gameStarted,
                popupDeclined: gameDeclined,
                OnThemeSelectedCallback: themeSelected
            ));

            OnStartGameSelected?.Invoke();
        }

        private void statsSelected()
        {
            statsPopup.Open(new StatsPopupData(
                descriptionData: "",
                headerData: "Stats info",
                useAcceptButton: false,
                useDeclineButton: true,
                popupAccepted: null,
                popupDeclined: statsClosed,
                stats: GlobalStats.Instance.statsData
            ));

            OnStatsSelected?.Invoke();
        }

        private void settingsSelected()
        {
            settingsPopup.Open(new SettingsPopupData(
                descriptionData: "",
                headerData: "Settings",
                useAcceptButton: false,
                useDeclineButton: true,
                popupAccepted: null,
                popupDeclined: settingsClosed
            ));

            OnSettingsSelected?.Invoke();
        }

        private void exitSelected()
        {
            

            OnExitSelected?.Invoke();
        }

        #region StartGamePopup
        private void gameStarted(IPopup popup)
        {
            GameloopManager.Instance.StartGame();
        }

        private void gameDeclined(IPopup popup)
        {
            startPopup.Close();
        }

        private void themeSelected(string themeID)
        {
            Debug.Log("Theme ID : " + themeID);
        }
        #endregion

        #region StatsPopup
        private void statsClosed(IPopup popup)
        {
            statsPopup.Close();
        }
        #endregion

        #region SettingsPopup
        private void settingsClosed(IPopup popup)
        {
            settingsPopup.Close();
        }
        #endregion

        private void OnDestroy()
        {
            removeListeners();
        }
    }
}