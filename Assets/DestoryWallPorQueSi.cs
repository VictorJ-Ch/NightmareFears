using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryWallPorQueSi : MonoBehaviour
{
    private void Awake()
    {
        SpawnLights.isTutorial += DestroyWall;
    }

    void DestroyWall()
    {
        Destroy(this.gameObject);
    }
}
