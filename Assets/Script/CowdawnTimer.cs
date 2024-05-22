using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText; // Referencia al texto donde se mostrará la cuenta regresiva
    private float tiempoInicio;
    public float tiempoRestante = 300f; // 10 minutos en segundos
    private bool contadorActivo = true;

    void Start()
    {
        tiempoInicio = Time.time; // Guardamos el tiempo de inicio del juego
    }

    void Update()
    {
        if (contadorActivo)
        {
            float tiempoTranscurrido = Time.time - tiempoInicio;
            tiempoRestante = 300f - tiempoTranscurrido; // Actualizamos el tiempo restante

            if (tiempoRestante <= 0f)
            {
                tiempoRestante = 0f;
                contadorActivo = false;
                CambiarEscena();
            }

            ActualizarTexto();
        }
    }

    void ActualizarTexto()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);

        countdownText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
