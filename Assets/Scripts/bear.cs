using System;
using UnityEngine;

public class bear : MonoBehaviour
{
    public static event Action onGrab;
    public static event Action onRelease;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bear"))
        {
            onGrab?.Invoke();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bear"))
        {
            onRelease?.Invoke();
        }
    }
}
