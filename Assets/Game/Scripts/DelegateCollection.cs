using Popup;
using UnityEngine;

namespace Game.Delegate
{
    public class DelegateCollection
    {
        #region MainMenu
        public delegate void OnPlaySelectedDelegate();
        public delegate void OnStatsSelectedDelegate();
        public delegate void OnSettingsSelectedDelegate();
        public delegate void OnExitGameSelectedDelegate();
        #endregion

        #region PopupData
        #region StartGame
        public delegate void OnSelectGameThemeDelegate(string themeID);
        public delegate void OnStartGameSelectedDelegate();
        #endregion

        #endregion
    }
}