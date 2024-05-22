using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador
    public float rotationSpeed = 100f; // Velocidad de rotación del jugador
    public Camera mainCamera; // Referencia a la cámara principal

    void Update()
    {
        // Movimiento del jugador
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Rotación del jugador
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        // Movimiento de la cámara
        if (mainCamera != null)
        {
            mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y, transform.position.z);
        }
    }
}
