using System;
using UnityEngine;

namespace Game.ScreenNS
{
    public class ScreenSettings : MonoBehaviour
    {
        public static ScreenSettings Instance = null;
        
        public static Action<ScreenOrientation> ChangeScreenSize;
        public static ScreenOrientation Orientation;

        public enum ScreenOrientation
        {
            wide = 1,
            tall = 2
        }

        public void Init()
        {
            if(ScreenSettings.Instance == null)
            {
                ScreenSettings.Instance = this;
            }
        }

        void Update()
        {
            if(Screen.width > Screen.height)
            {
                if(Orientation != ScreenOrientation.wide)
                {
                    ChangeScreenSize?.Invoke(ScreenOrientation.wide);
                }

                Orientation = ScreenOrientation.wide;
            }
            else
            {
                if(Orientation != ScreenOrientation.tall)
                {
                    ChangeScreenSize?.Invoke(ScreenOrientation.tall);
                }

                Orientation = ScreenOrientation.tall;
            }
        }
    }
}