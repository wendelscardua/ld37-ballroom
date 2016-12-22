using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource source;
    public int baseLine = 5;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        source.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.BallCount() <= baseLine)
            source.pitch = 1.0f;
        else
            source.pitch = Mathf.Pow(1.05f, gameManager.BallCount() - baseLine);
	}
}
