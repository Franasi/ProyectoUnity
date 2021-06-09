using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


//Script que se encarga de gestionar el menu de opciones del juego
public class MenuOpciones : MonoBehaviour
{

    //Variables 

    public GameObject panelOpciones;
    public AudioSource audio;
    public AudioSource musicaFondo;

    //Metodo que al llamarlo se pausara el juego y activara el menu de opciones
    public void PanelOpciones()
    {
        Time.timeScale = 0;
        panelOpciones.SetActive(true);
    }

    //Metodo que al llamarlo reanudara el juego y ocultara el menu de opciones
    public void Volver()
    {
        Time.timeScale = 1;
        panelOpciones.SetActive(false);
    }

    //Metodo que al llamarlo desactivara la musica o la reanudara
    public void Ajustes()
    {
        if (musicaFondo.enabled == true)
        {
            musicaFondo.enabled = false;
        }
        else
            musicaFondo.enabled = true;

    }

    //Metodo que al llamarlo nos permitira volver a menu 
    public void IrMenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuPrincipal");
    }

    //Metodo que al llamarlo nos cerrara el juego
    public void SalirJuego()
    {
        Application.Quit();
    }

    //Metodo que llama al sonido al pulsar una tecla
    public void ActivarSonido()
    {
        audio.Play();
    }

}
