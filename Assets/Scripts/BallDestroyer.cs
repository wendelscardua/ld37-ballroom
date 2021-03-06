﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour {
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.tag = "ZombieBall";
            StartCoroutine(WaitAndDestroy(other, 1.0f));
        }
    }

    private IEnumerator WaitAndDestroy(Collider ball, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        ball.gameObject.SetActive(false);
        Destroy(ball);
        gameManager.BallDestroyed();
    }
}
