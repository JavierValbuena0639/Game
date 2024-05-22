using UnityEngine;

public class MoverObjeto : MonoBehaviour
{
    public float velocidad = 1f; // Velocidad de movimiento
    public float distancia = 10f; // Distancia a moverse

    private bool moverHaciaDerecha = true;
    private float distanciaRecorrida = 0f;

    void Update()
    {
        // Mover hacia la derecha
        if (moverHaciaDerecha)
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            distanciaRecorrida += velocidad * Time.deltaTime;
        }
        // Mover hacia la izquierda
        else
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
            distanciaRecorrida += velocidad * Time.deltaTime;
        }

        // Cambiar la dirección cuando la distancia recorrida sea mayor o igual a la distancia deseada
        if (distanciaRecorrida >= distancia)
        {
            moverHaciaDerecha = !moverHaciaDerecha;
            distanciaRecorrida = 0f;
        }
    }
}
