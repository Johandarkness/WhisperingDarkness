using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Necesario si usas TextMeshPro para mostrar el texto

public class CountDown : MonoBehaviour
{
    public float timeInMinutes = 2f;  // El tiempo en minutos
    private float timeRemaining;      // Tiempo restante en segundos
    public TextMeshProUGUI countdownText;  // Referencia al componente TextMeshProUGUI
    public NewBehaviourScript lightController;   // Cambié el tipo a LampsControl para usar el script correcto

    void Start()
    {
         Debug.Log("Tiempo en minutos sas"+timeInMinutes);
        timeRemaining = timeInMinutes * 60;  // Convertir minutos a segundos
        Debug.Log(timeRemaining = timeInMinutes * 60);
        Debug.Log("Tiempo inicial: " + timeRemaining);
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            // Reducir el tiempo restante
            timeRemaining -= Time.deltaTime;

            // Imprimir el tiempo restante para depuración

            // Formatear el tiempo restante en minutos y segundos
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            // Mostrar el tiempo en pantalla
            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            // Si el tiempo llega a 0
            countdownText.text = "00:00";  // Mostrar 00:00 cuando termine el countdown

            // Verificar que el lightController no sea null antes de intentar apagar las luces
            if (lightController != null)
            {
                lightController.TurnOffLights();
            }
            else
            {
                Debug.LogWarning("No se ha asignado el controlador de luces (lightController).");
            }

            // Desactivar el contador para que no siga ejecutándose
            this.enabled = false;
        }
    }
}
