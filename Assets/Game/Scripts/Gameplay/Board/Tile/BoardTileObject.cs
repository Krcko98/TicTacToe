using UnityEngine;

namespace Game.Gameplay.Board.Tile
{
    public class BoardTileObject : MonoBehaviour
    {
        [SerializeField] private GameBoard.BoardObjectType boardObjectType;
        
        public GameBoard.BoardObjectType BoardObjectType { get => boardObjectType; }
    }
}