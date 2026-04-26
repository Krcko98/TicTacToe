using System;
using Game.Gameplay.Board.Tile;
using UnityEngine;

namespace Game.Save.Theme
{
    [CreateAssetMenu(fileName = "ThemeData", menuName = "ScriptableObject/Theme/ThemeData", order = 1)]
    [Serializable]
    public class ThemeDataSO : ScriptableObject
    {
        public string themeName;
        public GameObject gameEnvironment;
        public BoardTileObject tileObject;
    }
}