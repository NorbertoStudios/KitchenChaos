using System;
using UnityEngine;

namespace Utils
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager Instance { get; private set; }

        private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";
        
        private AudioSource _audioSource;
        private float volume;
        private float initialVolume = 0.3f;
        

        private void Awake()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
            
            
            volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, initialVolume);
            _audioSource.volume = volume;
        }

        public void ChangeVolume() {
            volume += 0.1f;
            if(volume > 1f) {
                volume = 0f;
            }

            _audioSource.volume = volume;
            
            PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, volume);
            PlayerPrefs.Save();
        }

        public float GetVolume() {
            return volume;
        }
    }
}