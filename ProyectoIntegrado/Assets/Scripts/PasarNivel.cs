using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//Libreria para los cambios de escena
using UnityEngine.SceneManagement;

using UnityEngine.UI;


/*
 * Script que nos permite cambiar de nivel al llegar al final de un nivel
 * 
 */
public class PasarNivel : MonoBehaviour
{
    
    public Image nivelCompleto;

    public AudioSource audio;

    //Metodo que activa la siguiente escena en el build
    void CambiarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Al entrar el jugador en colision con el final de la meta, activara la animacion del final, saltara un texto, y llamamos al metodo CambiarNivel. 
    //reproducira un sonido al entrar en contacto
    void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.transform.CompareTag("Player"))
        {

            GetComponent<Animator>().enabled = true;
            nivelCompleto.gameObject.SetActive(true);
            Invoke("CambiarNivel", 2);
            

            audio.Play();

        }
    }

}
