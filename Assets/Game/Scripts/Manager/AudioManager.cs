using Game.Save.Theme;
using UnityEngine;

namespace Game.Manager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource music;
        [SerializeField] private AudioSource sound;
        [SerializeField] private float volume = 1f;

        public static bool soundOn = true;
        public static bool musicOn = true;

        public static AudioManager Instance = null;

        public void Init()
        {
            if(AudioManager.Instance != null) return;
            AudioManager.Instance = this;

            music.volume = volume;
            sound.volume = volume;
        }

        public void PlaySound(AudioClip clip)
        {
            sound.PlayOneShot(clip);
        }

        public void ToggleMusic(bool enable)
        {
            music.volume = enable ? volume : 0;
            musicOn = enable;
        }

        public void ToggleSound(bool enable)
        {
            sound.volume = enable ? volume : 0;
            soundOn = enable;
        }
    }
}