using System.Collections.Generic;
using Game.Gameplay.Board.Data;
using Game.Gameplay.Board.Tile;
using Game.Manager;
using UnityEngine;

namespace Game.Gameplay.Board
{
    public class GameBoard : MonoBehaviour
    {
        [SerializeField] private GameBoardData boardData;
        [SerializeField] private Transform tileParent;
        [SerializeField] private float tileDistance;
        
        private List<BoardTile> boardTiles = new List<BoardTile>();

        //Game board data
        private int[][] placementBoard = new int[3][]
        {
            new int[3]{0, 0, 0},
            new int[3]{0, 0, 0},
            new int[3]{0, 0, 0}
        };

        public int[][] Board { get => placementBoard; }

        public enum BoardObjectType
        {
            X = 0,
            O = 1,
            COUNT
        }

        public void Init(GameBoardData data)
        {
            boardData = data;

            createTiles();
        }

        private void createTiles()
        {
            for(int i=0; i<9; i++)
            {
                BoardTile tile = Instantiate(ThemeManager.ActiveTheme.tile);
                tile.Init(i%3, i/3, tileDistance, tileParent);
                
                tile.OnTileClicked += boardData.OnTileClicked;
                tile.OnTilePointerEnter += boardData.OnTileEnter;
                tile.OnTilePointerExit += boardData.OnTileExit;

                boardTiles.Add(tile);
            }
        }
    }
}