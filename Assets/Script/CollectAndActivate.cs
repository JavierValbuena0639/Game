using UnityEngine;
using UnityEngine.UI;

public class CollectAndActivate : MonoBehaviour
{
    public int totalObjectsToCollect = 6; // Total de objetos que el jugador debe recolectar
    private int collectedObjects = 0; // Contador de objetos recolectados
    public UnityEngine.UI.Text scoreText; // Texto para mostrar la cantidad de puntos recolectados
    private float startTime; // Tiempo de inicio

    public static int totalScore = 0; // Variable estática para almacenar el puntaje total

    private connecdb connector; // Referencia al script connecdb

    void Start()
    {
        connector = FindObjectOfType<connecdb>(); // Busca el script connecdb en la escena
        if (connector == null)
        {
            UnityEngine.Debug.LogError("No se encontró el script connecdb en la escena.");
        }
        else
        {
            UpdateScoreText();
            startTime = Time.time; // Guardar el tiempo de inicio
        }
    }

    void Update()
    {
        // Aquí puedes agregar lógica adicional para la actualización del juego si es necesario
    }

    // Método llamado cuando el jugador entra en contacto con un objeto recolectable
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            totalScore++; // Aumenta el puntaje total
            collectedObjects++; // Incrementa el contador de objetos recolectados
            UpdateScoreText(); // Actualiza el texto de los puntos

            // Desactiva este objeto una vez que se recolecta
            gameObject.SetActive(false);

            // Verifica si se han recolectado todos los objetos
            if (collectedObjects >= totalObjectsToCollect)
            {
                UnityEngine.Debug.Log("¡Todos los objetos recolectados!");
                // Puedes agregar más lógica aquí, como desbloquear una puerta o activar un evento
            }

            // Calcula el tiempo transcurrido
            float elapsedTime = Time.time - startTime;

            // Obtiene el nombre del nivel actual
            string levelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

            // Llama al método Upload() del script connecdb con los datos recolectados
            if (connector != null)
            {
                connector.Upload(totalScore, levelName, elapsedTime.ToString("F2")); // Formatea el tiempo a dos decimales
            }
        }
    }

    // Método para actualizar el texto de los puntos
    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Frutas " + totalScore.ToString() + " / " + totalObjectsToCollect.ToString();
        }
        else
        {
            UnityEngine.Debug.LogWarning("Score Text is not assigned in the Inspector");
        }
    }
}
