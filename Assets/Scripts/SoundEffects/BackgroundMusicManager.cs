using System;
using UnityEngine;
using UnityEngine.Audio;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField] private GamePlayState gamePlayState;
    [SerializeField] private PauseState pauseState;

    [SerializeField] private AudioMixerGroup musicMixer;
    [SerializeField] private AudioMixerSnapshot gamePlayMode;
    [SerializeField] private AudioMixerSnapshot pauseMode;

    private void OnEnable()
    {
        gamePlayState.onGamePlay+=enableGamePlayMode;
        pauseState.onPause+=enablePauseMode;
        
    }

    private void OnDisable()
    {
        gamePlayState.onGamePlay-=enableGamePlayMode;
        pauseState.onPause-=enablePauseMode;
    }

    private void enablePauseMode()
    {
        Debug.Log("PAUSE MODE");
        pauseMode.TransitionTo(1.5f);
    }

    private void enableGamePlayMode()
    {
        Debug.Log("GP MODE");
        gamePlayMode.TransitionTo(1.5f);
    }
}
