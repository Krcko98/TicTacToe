using Game.Gameplay.Board.Data;
using UnityEngine;

namespace Game.Gameplay.Board
{
    public class GameBoard : MonoBehaviour
    {
        [SerializeField] private GameBoardData boardData;

        public void Init(GameBoardData data)
        {
            boardData = data;

            
        }
    }
}