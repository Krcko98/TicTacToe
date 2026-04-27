using System.Collections.Generic;
using UnityEngine;

namespace Game.Save.Theme
{
    [CreateAssetMenu(fileName = "ThemeDatabase", menuName = "ScriptableObject/Theme/ThemeDatabase", order = 0)]
    public class ThemeDatabaseSO : ScriptableObject
    {
        public ThemeDataSO ActiveTheme;

        public List<ThemeDataSO> availableThemes;
    }
}