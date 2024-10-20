using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static event Action Follow;
    public static event Action Patrol;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Follow?.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Patrol?.Invoke();
        }
    }
}
