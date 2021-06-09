using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script que se encarga de cerrar el juego a los 2 segundos de entrar en la escena screamer
public class Screamer : MonoBehaviour
{
    void Start()
    {
        Invoke("FinalScreamer", 2);
    }


    //Metodo que ierra el juego
    public void FinalScreamer()
    {
        Application.Quit();
    }
}
