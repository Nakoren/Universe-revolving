using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceSounds;

    [SerializeField] private AudioClip playerBlaster;
        

        private bool isMuted = false; 
        private float currentVolume = 3f; 

        private void Start()
        {
            audioSourceSounds.volume = currentVolume;
        }

        public void PlayPlayerBluster() => PlaySound(playerBlaster);
       
        private void PlaySound(AudioClip clip)
        {
            if (isMuted || clip == null) return;

            if (audioSourceSounds.isPlaying)
                audioSourceSounds.Stop();

            audioSourceSounds.clip = clip;
            audioSourceSounds.Play();
        }

        public void StopSound()
        {
            audioSourceSounds.Stop();
            audioSourceSounds.clip = null;
        }

        public void ToggleMute()
        {
            isMuted = !isMuted;
            audioSourceSounds.mute = isMuted;
        }

        public void SetVolume(int volumeIndex)
        {
            volumeIndex = Mathf.Clamp(volumeIndex, 0, 5);

            float[] volumeLevels = { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f };

            currentVolume = volumeLevels[volumeIndex];
            audioSourceSounds.volume = currentVolume;
        }
    
}
