using UnityEngine;

public class GameSoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayClickSound()
    {
        if (clickSound != null)
        {
           audioSource.clip = clickSound;
           audioSource.Play();
        }
    }
}
