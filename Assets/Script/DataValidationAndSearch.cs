using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class DataValidationAndSearch : MonoBehaviour
{
    public InputField usernameInputField; // Asigna el InputField del nombre de usuario desde el inspector
    public InputField passwordInputField; // Asigna el InputField de la contraseña desde el inspector
    public Button searchButton; // Asigna el botón desde el inspector

    private void Start()
    {
        // Configurar el InputField de la contraseña como un campo de contraseña
        passwordInputField.contentType = InputField.ContentType.Password;

        searchButton.onClick.AddListener(OnSearchButtonClicked);
    }

    public void OnSearchButtonClicked()
    {
        string username = usernameInputField.text.Trim();
        string password = passwordInputField.text.Trim();

        if (IsValid(username, password))
        {
            StartCoroutine(SearchUser(username, password));
        }
        else
        {
            UnityEngine.Debug.LogError("El nombre de usuario o la contraseña no son válidos.");
        }
    }

    private bool IsValid(string username, string password)
    {
        // Validación simple: verifica que el nombre de usuario y la contraseña no estén vacíos
        return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
    }

    private IEnumerator SearchUser(string username, string password)
    {
        string url = $"http://swagger-api.somee.com/api/User/login?email={username}&password={password}";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Enviar la solicitud y esperar a la respuesta
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                UnityEngine.Debug.LogError($"Error: {webRequest.error}");
                UnityEngine.Debug.LogError($"URL: {url}");
            }
            else
            {
                // Procesar la respuesta
                string response = webRequest.downloadHandler.text;
                UnityEngine.Debug.Log($"Resultado: {response}");

                // Asumimos que una respuesta no vacía significa éxito
                if (!string.IsNullOrEmpty(response))
                {
                    // Cargar la siguiente escena
                    SceneManager.LoadScene("MainMenu");
                }
                else
                {
                    UnityEngine.Debug.LogError("La respuesta del servidor está vacía.");
                }
            }
        }
    }
}
