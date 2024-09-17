using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class GameManagerScript : MonoBehaviour
{
    private static GameManagerScript instance;
    public enum State{Pause, Play} 
    public static State gameState;
    public static GameManagerScript Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameManager = new GameObject();
                instance =  gameManager.AddComponent<GameManagerScript>();
                gameManager.name = "Game Manager Singleton";
            }
            return instance;
        }
    }
    void Start()
    {
        gameState = State.Play;
    }
    void Update()
    {
        ChangeState();
    }
    void ChangeState()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        foreach (var device in inputDevices)
        {
            bool triggerValue;
            // Se cambia el valor de triggerButton por el que se desea
            if(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        gameState = State.Pause;
        Time.timeScale = 0; //Pause
        Debug.Log("game paused");
    }
    public void Play()
    {
        gameState = State.Play;
        Time.timeScale = 1; //Play
        Debug.Log("Game Continues");
    }
}
