using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsState : IState
{
    [Header("UI object")]
    [SerializeField] GameObject rootUI;

    [Header("Sound and music settings")]
    [SerializeField] private AudioMixerGroup musicMixer;
    [SerializeField] private AudioMixerGroup soundMixer;

    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundVolumeSlider;

    override protected void OnEnter()
    {
        musicVolumeSlider.onValueChanged.AddListener(ChangeMusicVolume);
        soundVolumeSlider.onValueChanged.AddListener(ChangeSoundVolume);
    }

    override protected void OnExit()
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


