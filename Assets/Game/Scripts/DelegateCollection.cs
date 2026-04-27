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
        public delegate void OnTilePointerEnterDelegate(BoardTile tile, PointerEventData eventData);
        public delegate void OnTilePointerExitDelegate(BoardTile tile, PointerEventData eventData);
        public delegate void OnTilePointerClickDelegate(BoardTile tile, PointerEventData eventData);
        #endregion
    }
}