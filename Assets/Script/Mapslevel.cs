using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mapslevel : MonoBehaviour
{

    public void sceneGame1()
    {
        //Aca debe ir el nombre de la primera esena que seria el primer nivel
        SceneManager.LoadScene("Play");
    }

    public void sceneGame2()
    {
        SceneManager.LoadScene("Map2");
    }
    public void sceneGame3()
    {
        SceneManager.LoadScene("Mapa3");
    }
}
