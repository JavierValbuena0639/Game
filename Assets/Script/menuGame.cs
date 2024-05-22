using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuGame : MonoBehaviour
{

    public void sceneGame()
    {
        //Aca debe ir el nombre de la primera esena que seria el primer nivel
        SceneManager.LoadScene("Maps");
    }

    public void Keybortadsettings()
    {
        SceneManager.LoadScene("KeyBoardSettings");
    }
    public void GameReturn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Login");
        Invoke("ExitDelay", 5);
    }
}
