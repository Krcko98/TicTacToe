using UnityEngine;

namespace Game.Manager
{
    public class ThemeManager : MonoBehaviour
    {
        public static ThemeManager Instance = null;

        public void Init()
        {
            if(ThemeManager.Instance != null) return;
            ThemeManager.Instance = this;

            
        }
    }
}