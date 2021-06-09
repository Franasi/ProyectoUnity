using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * Script que nos devolvera al principio del nivel y activara la animacion de que hemos recibido un golpe
 */

public class Respawn : MonoBehaviour
{

    //Variables
    public Animator animacion;
    private int vida;

    //Array que contendra los corazones de vida
    public GameObject[] corazones;


    void Start()
    {
        vida = corazones.Length;
        animacion = GetComponent<Animator>();

    }


    //Metodo que comprueba la vida que le queda al personaje al golpearnos
    private void ComrpobarVida()
    {

        //Si nuestra vida es menor que 1 se reiniciara la escena porque habremos muerto
        if (vida < 1)
        {
            Destroy(corazones[0].gameObject);
            animacion.Play("Golpe");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //Si es menor que 2 hara la animacion de golpe y destruira un corazon
        else if (vida < 2)
        {
            Destroy(corazones[1].gameObject);
            animacion.Play("Golpe");
        }


        //Si es menor que 3 hara la animacion de golpe y destruira un corazon
        else if (vida < 3)
        {
            Destroy(corazones[2].gameObject);
            animacion.Play("Golpe");
        }
    }

    /*
     * Al darnos se nos quitara una vida y llama al metodo comprobarVida
     */
    public void PlayerHerido()
    {

        vida-= 1;
        ComrpobarVida();
       
    }


}
