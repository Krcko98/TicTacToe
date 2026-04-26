using System;
using System.Collections.Generic;
using UnityEngine;
using SceneManagement = UnityEngine.SceneManagement;

namespace Game.Manager
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager Instance = null;

        public static Action<SceneManagement.Scene, SceneManagement.LoadSceneMode> OnSceneChanged;
        public static bool changingScene = false;

        public Dictionary<SceneType, string> scenes = new Dictionary<SceneType, string>()
        {
            { SceneType.init, "InitialScene" },
            { SceneType.menu, "MainMenu" },
            { SceneType.gameplay, "Gameplay" }
        };

        public enum SceneType
        {
            init = 0,
            menu = 1,
            gameplay = 2,
            COUNT
        }

        public void Init()
        {
            if(SceneManager.Instance != null) return;
            SceneManager.Instance = this;
            
            SceneManagement.SceneManager.sceneLoaded += sceneChanged;
        }

        private void sceneChanged(SceneManagement.Scene scene, SceneManagement.LoadSceneMode mode)
        {
            changingScene = false;
            Debug.Log("loaded");

            OnSceneChanged?.Invoke(scene, mode);
        }

        public void LoadScene(SceneType scene)
        {
            if(changingScene == true) return;

            changingScene = true;
            SceneManagement.SceneManager.LoadScene(scenes[scene]);
        }

        public void Oestroy()
        {
            SceneManagement.SceneManager.sceneLoaded -= sceneChanged;           
        }
    }
}