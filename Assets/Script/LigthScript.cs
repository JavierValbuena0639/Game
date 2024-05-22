using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscenaAutomatico : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public string nombreDeLaEscena;

    // Tiempo de retraso en segundos
    public float retraso = 5f;

    void Start()
    {
        // Invoca el método CambiarEscena después del retraso especificado
        Invoke("CambiarEscena", retraso);
    }

    // Método para cambiar de escena
    void CambiarEscena()
    {
        // Cambia a la escena con el nombre especificado
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}
