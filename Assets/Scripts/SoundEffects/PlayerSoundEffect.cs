using System;
using UnityEngine;

public class PlayerSoundEffect : MonoBehaviour
{
     private AudioSource audioSource;
     [SerializeField] Player player;

     private void  Awake()
     {
         audioSource=GetComponent<AudioSource>();
     }

     private void OnEnable()
     {
        player.onPlayerFire+=PlayFireSound;
     }

     private void OnDisable()
     {
         player.onPlayerFire-=PlayFireSound;
     }

    private void PlayFireSound()
    {
        audioSource.Play();
    }
}
