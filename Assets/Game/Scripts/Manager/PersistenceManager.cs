using Game.Save.Stats;
using Game.ScreenNS;
using UnityEngine;

namespace Game.Manager
{
    public class PersistenceManager : MonoBehaviour
    {
        public static PersistenceManager Instance = null;

        [SerializeField] private GameloopManager gameLoopManager;
        [SerializeField] private GlobalStats globalStats;
        [SerializeField] private SceneManager sceneManager;
        [SerializeField] private ThemeManager themeManager;
        [SerializeField] private ScreenSettings screenSettings;
        [SerializeField] private AudioManager audioManager;

        public void Awake()
        {
            if(PersistenceManager.Instance == null)
            {
                PersistenceManager.Instance = this;
                Init();
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void Init()
        {
            screenSettings.Init();
            globalStats.Init();
            audioManager.Init();
            sceneManager.Init();
            gameLoopManager.Init();
            themeManager.Init();
        }
    }

}