using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class connecdb : MonoBehaviour
{
    // Método para enviar los datos al servidor
    public void Upload(int collectedPoints, string levelName, string elapsedTime)
    {
        // Construir el JSON con los datos proporcionados
        string jsonData = @"{
            ""idGame"": 0,
            ""level"": """ + levelName + @""",
            ""userId"": 0,
            ""points"": """ + collectedPoints + @""",
            ""time"": """ + elapsedTime + @""",
            ""idUser"": {
                ""idUser"": 0,
                ""userName"": ""string"",
                ""password"": ""string"",
                ""email"": ""string""
            }
        }";

        // Iniciar la coroutine para enviar los datos al servidor
        StartCoroutine(UploadCoroutine(jsonData));
    }

    IEnumerator UploadCoroutine(string jsonData)
    {
        // Crear la solicitud web con los datos JSON
        using (UnityWebRequest www = UnityWebRequest.PostWwwForm("http://swagger-api.somee.com/api/Game", jsonData))
        {
            // Convertir el JSON a bytes para enviarlo en la solicitud
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);

            // Configurar los manejadores de carga y descarga
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            // Establecer el encabezado Content-Type
            www.SetRequestHeader("Content-Type", "application/json");

            // Enviar la solicitud y esperar la respuesta
            yield return www.SendWebRequest();

            // Verificar si hubo algún error en la respuesta
            if (www.result != UnityWebRequest.Result.Success)
            {
                UnityEngine.Debug.LogError(www.error);
            }
            else
            {
                UnityEngine.Debug.Log("¡Envío de formulario completo!");
            }
        }
    }
}
