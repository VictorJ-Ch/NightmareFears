using UnityEngine;

public class grito : MonoBehaviour
{
    public AudioSource triggerSound;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Nightlight")) // Asegúrate de que tu jugador tenga el tag "Player"
        {
            if (!triggerSound.isPlaying)
            {
                triggerSound.Play();
            }
        }
    }
}

