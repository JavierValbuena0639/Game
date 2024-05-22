using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public string url = "http://3.93.175.162/register.html"; // URL to be opened

    // Method to open the link
    public void OpenURL()
    {
        UnityEngine.Application.OpenURL(url);
    }
}
