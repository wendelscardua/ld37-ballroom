using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSound : MonoBehaviour {
    public AudioSource source;

    private void OnCollisionEnter(Collision collision)
    {
        float magnitude = collision.relativeVelocity.magnitude;
        magnitude = Mathf.Clamp(magnitude / 10.0f, 0.0f, 1.0f);
        source.PlayOneShot(source.clip, magnitude);
    }
}
