using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource source;
    public int baseLine = 5;

	// Use this for initialization
	void Start () {
        source.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.BallCount() <= baseLine)
            source.pitch = 1.0f;
        else
            source.pitch = Mathf.Pow(1.05f, GameManager.instance.BallCount() - baseLine);
	}
}
