using Game.Delegate;
using UnityEngine;

namespace Game.Gameplay.Board.Data
{
    public class GameBoardData
    {
        public DelegateCollection.OnTilePointerClickDelegate OnTileClicked;
        public DelegateCollection.OnTilePointerEnterDelegate OnTileEnter;
        public DelegateCollection.OnTilePointerExitDelegate OnTileExit;

        public GameBoardData(
            DelegateCollection.OnTilePointerClickDelegate tileClicked,
            DelegateCollection.OnTilePointerEnterDelegate tilePointerEnter,
            DelegateCollection.OnTilePointerExitDelegate tilePointerExit
        )
        {
            OnTileClicked = tileClicked;
            OnTileEnter = tilePointerEnter;
            OnTileExit = tilePointerExit;
        }
    }
}