using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public static event Action onLit;
    public string EnemyTag;

    public Vector3 Spawn;
    public Quaternion Rot;
    public GameObject Prefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(EnemyTag))
        {
            Destroy(other.gameObject);
            Vector3 SpawnPoint = new Vector3(Spawn.x, Spawn.y, Spawn.z);
            Instantiate(Prefab, SpawnPoint, Rot);
            onLit?.Invoke();
            //Destroy(this.gameObject);
        }
    }
}