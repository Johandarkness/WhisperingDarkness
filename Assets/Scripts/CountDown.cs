using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Necesario si usas TextMeshPro para mostrar el texto

public class CountDown : MonoBehaviour
{
    public float timeInMinutes = 1f;  // El tiempo en minutos
    private float timeRemaining;      // Tiempo restante en segundos
    public TextMeshProUGUI countdownText;  // Referencia al componente TextMeshProUGUI
    //public AnotherScript anotherScript;    // Referencia a otro script que llamaremos al llegar a 0

    void Start()
    {
        timeRemaining = timeInMinutes * 60;  // Convertir minutos a segundos
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            // Reducir el tiempo restante
            timeRemaining -= Time.deltaTime;

            // Formatear el tiempo restante en minutos y segundos
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            // Mostrar el tiempo en pantalla
            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            // Llamar al otro script si el tiempo ha terminado
            countdownText.text = "00:00";  // Mostrar 00:00 cuando termine el countdown
            //anotherScript.TriggerAction(); // Método en otro script
        }
    }
}
