using Game.Delegate;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Gameplay.Board.Tile
{
    public class BoardTile : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private BoardTileObject boardTileObject;

        public event DelegateCollection.OnTilePointerClickDelegate OnTileClicked;
        public event DelegateCollection.OnTilePointerEnterDelegate OnTilePointerEnter;
        public event DelegateCollection.OnTilePointerExitDelegate OnTilePointerExit;

        public BoardTileObject TileObject { get => boardTileObject; }

        public void Init()
        {
            
        }

        public void SetObject(BoardTileObject tileObject)
        {
            boardTileObject = tileObject;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnTileClicked?.Invoke(eventData, this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnTilePointerEnter?.Invoke(eventData, this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnTilePointerExit?.Invoke(eventData, this);
        }
    }
}