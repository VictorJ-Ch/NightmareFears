using System;
using UnityEngine;

public class SpawnLights : MonoBehaviour
{
    public static event Action onLit;
    public static event Action isTutorial;

    public string NightLightTag;

    public bool Tuttorial;

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

        if (Tuttorial)
        {
            isTutorial?.Invoke();
        }
    }
}
