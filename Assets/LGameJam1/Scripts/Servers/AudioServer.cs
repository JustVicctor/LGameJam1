using System;
using UnityEngine;

namespace LGameJam1.Scripts.Servers
{
    public class AudioServer : MonoBehaviour
    {
        public AudioListener audioListener;
        
        public AudioSource audioSource;
        public AudioSource SFXSource;
        
        public AudioClip ambientSound;
        public AudioClip clickSound;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            God.AudioS = this;
        }

        private void Start()
        {
            SFXSource.clip = clickSound;
            audioSource.clip = ambientSound;
            audioSource.Play();
        }

        public void PlayClick()
        {
            SFXSource.Play();
        }
    }
}