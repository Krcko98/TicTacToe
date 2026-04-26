using Game.Save.Stats;
using UnityEngine;

namespace Game.Manager
{
    public class PersistenceManager : MonoBehaviour
    {
        public static PersistenceManager Instance = null;

        [SerializeField] private GameloopManager gameLoopManager;
        [SerializeField] private GlobalStats globalStats;
        [SerializeField] private SceneManager sceneManager;

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
            globalStats.Init();
            sceneManager.Init();
            gameLoopManager.Init();
        }
    }

}