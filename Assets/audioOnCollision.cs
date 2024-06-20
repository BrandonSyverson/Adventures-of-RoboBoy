using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioOnCollision : MonoBehaviour
{
    public AudioClip collisionSound; // Assign the audio clip in the Inspector

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = collisionSound;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Change "YourCollisionTag" to the tag of the object you want to collide with
        {
            audioSource.Play();
        }
    }
}