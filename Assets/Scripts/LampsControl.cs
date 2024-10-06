using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Light[] lights;  // Asigna aqu� las luces desde el Inspector
    //public float timerDuration = 5.0f; // Duraci�n del temporizador en segundos

    void Start()
    {
        // Inicia el temporizador
       // Invoke("TurnOffLights", timerDuration);
    }

    public void TurnOffLights()  // Cambia el método a 'public'
{
    foreach (Light light in lights)
    {
        light.enabled = false;
    }
}
    void Update()
    {

    }
}
