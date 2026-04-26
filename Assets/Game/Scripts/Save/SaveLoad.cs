using System.Collections.Generic;
using UnityEngine;

namespace Game.Save
{
    public static class SaveLoad
    {
        public static readonly Dictionary<PrefType, string> SaveLoadPrefs = new Dictionary<PrefType, string>()
        {
            { PrefType.globalStats, "globalStats" }
        };

        public enum PrefType
        {
            globalStats = 0,
            COUNT
        }

        public static void Save<T>(PrefType prefType, T value)
        {
            PlayerPrefs.SetString(
                SaveLoadPrefs[prefType],
                JsonUtility.ToJson(value)
            );
        }

        public static T Load<T>(PrefType prefType)
        {
            if(!PlayerPrefs.HasKey(SaveLoadPrefs[prefType]))
            {
                return default(T);
            }

            return JsonUtility.FromJson<T>(
                PlayerPrefs.GetString(SaveLoadPrefs[prefType])
            );
        }
    }
}