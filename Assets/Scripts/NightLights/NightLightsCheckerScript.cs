using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightLightsCheckerScript : MonoBehaviour
{
    public int contador;
    public string sceneName;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NightLight"))
        {
            contador += 1;  // O también puedes usar contador++;
            SceneManager.LoadScene(sceneName);
            print("Luces puestas: " + contador);
            print("Cambiando a: " + sceneName);
        }
    }
}
