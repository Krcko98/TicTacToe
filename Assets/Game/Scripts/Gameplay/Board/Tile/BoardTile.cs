using Game.Delegate;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Gameplay.Board.Tile
{
    public class BoardTile : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private BoardTileObject boardTileObject;
        [SerializeField] private Transform tileObjectParent;

        private Vector2Int boardLocation;

        public event DelegateCollection.OnTilePointerClickDelegate OnTileClicked;
        public event DelegateCollection.OnTilePointerEnterDelegate OnTilePointerEnter;
        public event DelegateCollection.OnTilePointerExitDelegate OnTilePointerExit;

        public BoardTileObject TileObject { get => boardTileObject; }
        public Vector2Int BoardLocation { get => boardLocation; }

        public void Init(int posX, int posY, float distance, Transform parent)
        {
            boardLocation = new Vector2Int(posX, posY);
            transform.parent = parent;
            transform.localPosition = new Vector3(
                boardLocation.x * distance,
                0f,
                boardLocation.y * distance
            );
        }

        public void SetObject(BoardTileObject tileObject)
        {
            BoardTileObject obj = Instantiate(tileObject);
            obj.transform.parent = tileObjectParent;
            obj.transform.localPosition = Vector3.zero;

            boardTileObject = obj;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnTileClicked?.Invoke(this, eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnTilePointerEnter?.Invoke(this, eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnTilePointerExit?.Invoke(this, eventData);
        }
    }
}