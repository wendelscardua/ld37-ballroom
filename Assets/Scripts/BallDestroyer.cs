using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            StartCoroutine(WaitAndDestroy(other, 1.0f));
        }
    }

    private IEnumerator WaitAndDestroy(Collider ball, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(ball);
        GameManager.instance.BallDestroyed();
    }
}
