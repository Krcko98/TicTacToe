using System.Collections.Generic;
using Game.Gameplay.Board.Data;
using Game.Gameplay.Board.Tile;
using Game.Manager;
using UnityEngine;

namespace Game.Gameplay.Board
{
    public class GameBoard : MonoBehaviour
    {
        public class GameBoardStatus
        {
            public int matchingStatus;//0 = no match, 1 = X, 2 = O
            public List<BoardTile> tilesMatched = new List<BoardTile>();

            public GameBoardStatus()
            {
                matchingStatus = 0;
            }
        }

        public class GameBoardResult
        {
            public string Name = "";
            public int[][] resultMatrix = new int[3][];

            public GameBoardResult(int[][] matrix, string name)
            {
                Name = name;
                resultMatrix = matrix;
            }            

            public List<Vector2Int> CheckResult(int[][] gameBoard)
            {
                List<Vector2Int> results = new List<Vector2Int>();
                int result = 0;

                for(int i=0; i<gameBoard.Length; i++)
                {
                    for(int j=0; j<gameBoard.Length; j++)
                    {
                        if(resultMatrix[i][j] == 0) continue;
                    
                        int boardResult = resultMatrix[i][j] * gameBoard[i][j];

                        if(boardResult == 0)
                        {
                            results.Clear();
                            return results;
                        }

                        if(result == 0)
                        {
                            result = boardResult;
                            results.Add(new Vector2Int(i, j));
                        }
                        else
                        {
                            if(result != boardResult)
                            {
                                results.Clear();
                                return results;
                            }
                            else
                            {
                                result = boardResult;
                                results.Add(new Vector2Int(i, j));
                            }
                        }
                    }
                }

                return results;
            }
        }

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

        private List<GameBoardResult> boardResults = new List<GameBoardResult>();

        //Board winner options
        #region Results
        private int[][] horizontal1 = new int[3][]
        {
            new int[3]{1, 1, 1},
            new int[3]{0, 0, 0},
            new int[3]{0, 0, 0}
        };
        private int[][] horizontal2 = new int[3][]
        {
            new int[3]{0, 0, 0},
            new int[3]{1, 1, 1},
            new int[3]{0, 0, 0}
        };
        private int[][] horizontal3 = new int[3][]
        {
            new int[3]{0, 0, 0},
            new int[3]{0, 0, 0},
            new int[3]{1, 1, 1}
        };
        private int[][] vertical1 = new int[3][]
        {
            new int[3]{1, 0, 0},
            new int[3]{1, 0, 0},
            new int[3]{1, 0, 0}
        };
        private int[][] vertical2 = new int[3][]
        {
            new int[3]{0, 1, 0},
            new int[3]{0, 1, 0},
            new int[3]{0, 1, 0}
        };
        private int[][] vertical3 = new int[3][]
        {
            new int[3]{0, 0, 1},
            new int[3]{0, 0, 1},
            new int[3]{0, 0, 1}
        };
        private int[][] diagonal1 = new int[3][]
        {
            new int[3]{1, 0, 0},
            new int[3]{0, 1, 0},
            new int[3]{0, 0, 1}
        };
        private int[][] diagonal2 = new int[3][]
        {
            new int[3]{0, 0, 1},
            new int[3]{0, 1, 0},
            new int[3]{1, 0, 0}
        };

        public int[][] Board { get => placementBoard; }

        public enum BoardObjectType
        {
            X = 0,
            O = 1,
            COUNT
        }
        #endregion

        public void Init(GameBoardData data)
        {
            boardData = data;

            boardResults.Add(new GameBoardResult(horizontal1, "h1"));
            boardResults.Add(new GameBoardResult(horizontal2, "h2")); 
            boardResults.Add(new GameBoardResult(horizontal3, "h3"));
            boardResults.Add(new GameBoardResult(vertical1, "v1")); 
            boardResults.Add(new GameBoardResult(vertical2, "v2"));
            boardResults.Add(new GameBoardResult(vertical3, "v3")); 
            boardResults.Add(new GameBoardResult(diagonal1, "d1"));
            boardResults.Add(new GameBoardResult(diagonal2, "d2")); 

            createTiles();
        }

        public GameBoardStatus GetBoardStatus()
        {
            GameBoardStatus status = new GameBoardStatus();
            List<Vector2Int> match = new List<Vector2Int>();

            //Check horizontal
            foreach(GameBoardResult result in boardResults)
            {
                match = result.CheckResult(placementBoard);
                status.tilesMatched.Clear();

                if(match.Count != 3) continue;

                foreach(Vector2Int pos in match)
                {
                    status.tilesMatched.Add(boardTiles.Find(x => x.BoardLocation == pos));
                    if(status.tilesMatched.Count == 3)
                    {
                        Debug.Log(result.Name);
                        status.matchingStatus = placementBoard[pos.x][pos.y];
                        return status;
                    }
                }
            }

            return status;
        }

        private void createTiles()
        {
            for(int i=0; i<9; i++)
            {
                BoardTile tile = Instantiate(ThemeManager.ActiveTheme.tile);
                tile.Init(i/3, i%3, tileDistance, tileParent);

                tile.OnTileClicked += boardData.OnTileClicked;
                tile.OnTilePointerEnter += boardData.OnTileEnter;
                tile.OnTilePointerExit += boardData.OnTileExit;

                boardTiles.Add(tile);
            }
        }
    }
}