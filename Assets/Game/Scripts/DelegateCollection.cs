using Game.Gameplay.Board.Tile;
using Popup;
using UnityEngine;
using UnityEngine.EventSystems;

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

        #region Gameplay
        public delegate void OnTilePointerEnterDelegate(PointerEventData eventData, BoardTile tile);
        public delegate void OnTilePointerExitDelegate(PointerEventData eventData, BoardTile tile);
        public delegate void OnTilePointerClickDelegate(PointerEventData eventData, BoardTile tile);
        #endregion
    }
}