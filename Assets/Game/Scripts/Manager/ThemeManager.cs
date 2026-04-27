using Game.Save.Theme;
using UnityEngine;

namespace Game.Manager
{
    public class ThemeManager : MonoBehaviour
    {
        [SerializeField] private ThemeDatabaseSO themeDB;

        public static ThemeDataSO ActiveTheme { get; set; }

        public static ThemeManager Instance = null;

        public void Init()
        {
            if(ThemeManager.Instance != null) return;
            ThemeManager.Instance = this;

            ActiveTheme = themeDB.ActiveTheme;
        }
    }
}