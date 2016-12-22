using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {
    public Slider musicVolume;
    public Slider spawnTime;
    public Text spawnTimeValue;

    private void OnEnable()
    {
        musicVolume.normalizedValue = PlayerPrefs.GetFloat("Music Volume", 1.0f);
        spawnTime.value = PlayerPrefs.GetFloat("Spawn Time", 10.0f);
        spawnTimeValue.text = string.Format("Spawn Time: {0:f1}s", spawnTime.value);
        musicVolume.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        spawnTime.onValueChanged.AddListener(delegate { OnSpawnTimeChange(); });
    }

    private void OnSpawnTimeChange()
    {
        PlayerPrefs.SetFloat("Spawn Time", spawnTime.value);
        spawnTimeValue.text = string.Format("Spawn Time: {0:f1}s", spawnTime.value);
    }

    private void OnMusicVolumeChange()
    {
        PlayerPrefs.SetFloat("Music Volume", musicVolume.normalizedValue);
    }
}
