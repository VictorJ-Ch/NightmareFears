using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NightLightsCheckerScript : MonoBehaviour
{
    public int contador;
    public string sceneName;
    public TextMeshProUGUI contadorTxt;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NightLight"))
        {
            contador ++;
            contadorTxt.text = "Luces colocadas ({contador}/1)";
            SceneManager.LoadScene(sceneName);
            print("Luces puestas: " + contador);
            print("Cambiando a: " + sceneName);
        }
    }
}
