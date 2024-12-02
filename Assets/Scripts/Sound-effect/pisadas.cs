using UnityEngine;

public class pisadas : MonoBehaviour
{
    public AudioSource moveSound;

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        // Comprueba si el jugador se ha movido desde la última actualización
        if (transform.position != lastPosition)
        {
            if (!moveSound.isPlaying)
            {
                moveSound.Play();
            }
        }
        else
        {
            if (moveSound.isPlaying)
            {
                moveSound.Stop();
            }
        }

        // Actualiza la última posición del jugador
        lastPosition = transform.position;
    }
}

