using UnityEngine;

public class ResetScoreOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el otro objeto tiene la etiqueta "objeto1" o "objeto2"
        if (other.CompareTag("Objeto1") || other.CompareTag("Objeto2"))
        {
            // Reinicia el puntaje del script CollectAndActivate a 0
            CollectAndActivate.totalScore = 0;

            // Busca todos los objetos con el script CollectAndActivate y actualiza sus textos de puntaje
            CollectAndActivate[] collectAndActivateScripts = FindObjectsOfType<CollectAndActivate>();
            foreach (CollectAndActivate script in collectAndActivateScripts)
            {
                script.UpdateScoreText();
            }
        }
    }
}
