// using UnityEngine;

// public class CylinderInteraction : MonoBehaviour
// {
//     private AudioSource audioSource;

//     private void Start()
//     {
//         // Get the AudioSource component attached to the cylinder
//         audioSource = GetComponent<AudioSource>();
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player")) // Check if the player is touching the cylinder
//         {
//             if (audioSource != null)
//             {
//                 audioSource.Play(); // Play sound effect
//             }
//             Destroy(gameObject, audioSource.clip.length); // Destroy after the sound finishes
//         }
//     }
// }

// using UnityEngine;

// public class CylinderInteraction : MonoBehaviour
// {
//     private AudioSource audioSource;
//     public GameObject explosionEffect; // Drag and drop the particle system here

//     private void Start()
//     {
//         // Get the AudioSource component attached to the cylinder
//         audioSource = GetComponent<AudioSource>();
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player")) // Check if the player is touching the cylinder
//         {
//             if (audioSource != null)
//             {
//                 audioSource.Play(); // Play sound effect
//             }

//             if (explosionEffect != null)
//             {
//                 Instantiate(explosionEffect, transform.position, transform.rotation); // Create the particle effect
//             }

//             Destroy(gameObject, audioSource.clip.length); // Destroy the cylinder after the sound finishes
//         }
//     }
// }


using UnityEngine;
using System.Collections;

public class CylinderInteraction : MonoBehaviour
{
    private AudioSource audioSource; // Reference to the audio source
    public GameObject explosionEffect; // Reference to the particle effect (explosion effect)

    private void Start()
    {
        // Get the AudioSource component attached to the cylinder
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player (tagged as "Player") is touching the cylinder
        if (other.CompareTag("Player"))
        {
            // Play the sound effect immediately
            if (audioSource != null)
            {
                audioSource.Play(); // Play sound when the player collides with the cylinder
            }

            // Trigger the particle effect (explosion effect)
            if (explosionEffect != null)
            {
                // Instantiate (create) the particle effect at the cylinder's position
                Instantiate(explosionEffect, transform.position, transform.rotation);
            }

            // Start a coroutine to destroy the cylinder after the sound has finished
            StartCoroutine(DestroyAfterSound());
        }
    }

    // Coroutine to delay destruction of the cylinder until the sound finishes
    private IEnumerator DestroyAfterSound()
    {
        // Wait for the sound's clip length to complete
        yield return new WaitForSeconds(audioSource.clip.length);

        // Destroy the cylinder after the sound finishes playing
        Destroy(gameObject);
    }
}



