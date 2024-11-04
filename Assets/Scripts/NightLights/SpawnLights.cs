using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;

public class SpawnLights : MonoBehaviour
{
    public static event Action onLit;
    public string NightLightTag;

    public Vector3 Spawn;
    public Quaternion Rot;
    public GameObject Prefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(NightLightTag))
        {
            Destroy(other.gameObject);
            Vector3 SpawnPoint = new Vector3(Spawn.x, Spawn.y, Spawn.z);
            Instantiate(Prefab, SpawnPoint, Rot);
            onLit?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
