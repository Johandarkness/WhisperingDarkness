using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Light[] lights;  // Asigna aquí las luces desde el Inspector
    public float timerDuration = 5.0f; // Duración del temporizador en segundos

    void Start()
    {
        // Inicia el temporizador
        Invoke("TurnOffLights", timerDuration);
    }

    void TurnOffLights()
    {
        // Apagar cada luz
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
    }
    void Update()
    {

    }
}
