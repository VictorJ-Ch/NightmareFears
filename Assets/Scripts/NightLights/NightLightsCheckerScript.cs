using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NightLightsCheckerScript : MonoBehaviour
{
    public int contador;
    public int nightLights;
    public string sceneName;
    public TextMeshProUGUI contadorTxt;

    void OnTriggerEnter(Collider other)
    {
        print("Outside Tag NightLight");
        if(other.CompareTag("NightLight"))
        {
            print("Inside Tag NIghtLight");
            contador ++;
            contadorTxt.text = "Luces colocadas8nuhnuhn" + contador.ToString() +"/"+ nightLights.ToString();
            print("Luces puestas: " + contador);
            if(contador >= nightLights)
            {
                SceneManager.LoadScene(sceneName);
                print("Cambiando a: " + sceneName);
            }
        }
    }
}
