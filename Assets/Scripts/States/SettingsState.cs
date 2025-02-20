using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsState : MonoBehaviour
{
    [Header("States")]
    [SerializeField] PauseState pauseState;
    [SerializeField] private OpenMenuState openMenuState;

    [Header("UI object")]
    [SerializeField] GameObject rootUI;

    [Header("Sound and music settings")]
    [SerializeField] private AudioMixerGroup musicMixer;
    [SerializeField] private AudioMixerGroup soundMixer;

    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundVolumeSlider;

    public GameObject previousState;

    private void Start()
    {
        musicVolumeSlider.onValueChanged.AddListener(ChangeMusicVolume);
        soundVolumeSlider.onValueChanged.AddListener(ChangeSoundVolume);
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;

        if (rootUI != null)
        {
            rootUI.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (rootUI != null)
        {
            rootUI.SetActive(false);
        }
    }

    public void ExitSettings()
    {
        if (previousState == pauseState.gameObject)
        {
            pauseState.gameObject.SetActive(true);
        }
        else if (previousState == openMenuState.gameObject)
        {
            openMenuState.gameObject.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }


    public void ChangeSoundVolume(float volume)
    {
        float dB = Mathf.Lerp(-60f, 0f, volume);
        soundMixer.audioMixer.SetFloat("SoundVolume", dB);
    }

    public void ChangeMusicVolume(float volume)
    {
        float dB = Mathf.Lerp(-60f, 0f, volume);
        musicMixer.audioMixer.SetFloat("MusicVolume", dB);
    }
}


