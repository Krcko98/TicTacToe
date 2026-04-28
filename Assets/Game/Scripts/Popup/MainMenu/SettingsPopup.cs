using CustomButton;
using Game.Manager;
using Popup.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Popup.Menu
{
    public class SettingsPopup : UIPopup
    {
        [SerializeField] private Toggle musicToggle;
        [SerializeField] private Toggle soundToggle;

        public override void Open<T>(T data)
        {
            base.Open(data);

            soundToggle.onValueChanged.AddListener(onSoundToggle);
            musicToggle.onValueChanged.AddListener(onMusicToggle);

            soundToggle.isOn = AudioManager.soundOn;
            musicToggle.isOn = AudioManager.musicOn;

            DeclineButton.onClick.AddListener(() => data.popupDeclined(this));
        }

        private void onSoundToggle(bool enabled)
        {
            AudioManager.Instance.ToggleSound(enabled);
        }

        private void onMusicToggle(bool enabled)
        {
            AudioManager.Instance.ToggleMusic(enabled);
        }
    }
}