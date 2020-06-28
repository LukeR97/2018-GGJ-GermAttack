using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public AudioSource soundSource;
    public AudioClip sound;

    private bool hasPlayedAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && hasPlayedAudio == false) {

            soundSource.PlayOneShot(sound);
            hasPlayedAudio = true;
        }
    }
}
