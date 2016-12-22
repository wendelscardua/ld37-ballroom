using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {
    public Slider musicVolume;
    public Slider spawnTime;
    public Text spawnTimeValue;
    public Image spawnTimeFill;

    private void OnEnable()
    {
        musicVolume.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        spawnTime.onValueChanged.AddListener(delegate { OnSpawnTimeChange(); });
        musicVolume.normalizedValue = PlayerPrefs.GetFloat("Music Volume", 1.0f);
        spawnTime.value = PlayerPrefs.GetFloat("Spawn Time", 10.0f);
    }

    private void OnSpawnTimeChange()
    {
        float stv = spawnTime.value;
        float nstv = spawnTime.normalizedValue;
        PlayerPrefs.SetFloat("Spawn Time", stv);
        spawnTimeValue.text = string.Format("Spawn Time: {0:f1}s", stv);
        spawnTimeFill.color = Color.blue * nstv + Color.red * (1 - nstv);
    }

    private void OnMusicVolumeChange()
    {
        PlayerPrefs.SetFloat("Music Volume", musicVolume.normalizedValue);
    }
}
