using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP : MonoBehaviour
{
    // Collision Play

    public AudioClip clip;
    public AudioSource source;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground") || coll.gameObject.CompareTag("Rock"))
        GetComponent<AudioSource>().Play();
    }
}
