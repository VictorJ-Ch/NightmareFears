using System;
using UnityEngine;

public class bear : MonoBehaviour
{
    public static event Action onGrab;
    public static event Action onRelease;

    public string tag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            onGrab?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag))
        {
            onRelease?.Invoke();
        }
    }
}
