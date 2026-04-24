using UnityEngine;
using TMPro;
using System;
using Game.Save.Stats.Data;

namespace Game.Popup.Menu.Stats
{
    public class UIStat : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public TextMeshProUGUI Text { get => text; }

        public void Init(UIStatData statData)
        {
            text.text = statData.statFormatter(statData.data);
        }
    }
}