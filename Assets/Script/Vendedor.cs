using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vendedor : MonoBehaviour
{
    public Text totalScoreText; // Texto para mostrar el puntaje total en valor de 50 puntos por banana
    public string sceneToLoad; // Nombre de la escena a cargar
    public int pointsToChangeScene = 1000; // Puntos necesarios para cambiar de escena
    private static int previousTotalScore = 0; // Variable para almacenar el puntaje total previo

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el otro objeto tiene la etiqueta "Objeto1" o "Objeto2"
        if (other.CompareTag("Objeto1") || other.CompareTag("Objeto2"))
        {
            // Calcula el puntaje actual basado en las bananas recolectadas
            previousTotalScore += CollectAndActivate.totalScore * 50;

            // Reinicia el puntaje del script CollectAndActivate a 0
            CollectAndActivate.totalScore = 0;

            // Busca todos los objetos con el script CollectAndActivate y actualiza sus textos de puntaje
            CollectAndActivate[] collectAndActivateScripts = FindObjectsOfType<CollectAndActivate>();
            foreach (CollectAndActivate script in collectAndActivateScripts)
            {
                script.UpdateScoreText();
            }

            // Actualiza el texto del puntaje total basado en que cada banana vale 50 puntos
            UpdateTotalScoreText();

            // Verifica si el puntaje total ha alcanzado o superado los puntos necesarios para cambiar de escena
            if (previousTotalScore >= pointsToChangeScene)
            {
                ChangeScene();
            }
        }
    }

    // Método para actualizar el texto del puntaje total
    public void UpdateTotalScoreText()
    {
        totalScoreText.text = "Total Score: " + previousTotalScore.ToString() + " Points";
    }

    // Método para cambiar de escena
    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}