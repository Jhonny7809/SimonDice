using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioesc : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void salir()
    {
        Debug.Log("salir...");
        Application.Quit();
    }
}
