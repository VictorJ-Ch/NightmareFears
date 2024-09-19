using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private static GameManagerScript instance;
    public enum State{Pause, Play, Normal, Hugging} 
    public static State gameState, PlayerState;

    public Light BearLight;
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
        BearHug.Hug += HuggingBear;
        BearHug.UnHug += UnHug;
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

    void HuggingBear()
    {
        PlayerState = State.Hugging;
        if (BearLight.intensity <= 20)
        {
            BearLight.intensity++;
        }
    }

    void UnHug()
    {
        PlayerState = State.Normal;
        if (BearLight.intensity >= 0)
        {
            BearLight.intensity--;
        }
    }
}
