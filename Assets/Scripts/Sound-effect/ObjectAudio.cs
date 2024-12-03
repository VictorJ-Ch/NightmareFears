using UnityEngine;

public class ObjectAudio : MonoBehaviour
{
    public AudioClip disappearSound;  // Asigna el clip de audio desde el Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gameObject.activeInHierarchy)
        {
            PlayDisappearSound();
        }
    }

    void PlayDisappearSound()
    {
        if (disappearSound != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(disappearSound);
        }
    }
}

