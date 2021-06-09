using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


/*
 * Script que nos permitira recoger frutas y que al recogerlas se activara una animacion y se elminara
 */

public class RecogerFruta : MonoBehaviour
{
   
    public AudioSource audio;
    //Metodo para cuando personaje pase por encima de una fruta, esta desaparecera y acto seguida ocurrira una animacion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el personaje hace contacto con la fruta entrara en la condicion
        if (collision.CompareTag("Player"))
        {
     
            //Desactivamos sprite de la fruta
            GetComponent<SpriteRenderer>().enabled = false;

            //Activamos el primer componente hijo del componente padre (Realiza la animacion)
            gameObject.transform.GetChild(0).gameObject.SetActive(true);


            FindObjectOfType<ColeccionFrutas>().FrutasConseguidas();


            //Eliminamos el componente y con el sus componentes hijos
            Destroy(gameObject, 0.5f);

            audio.Play();

            
            


        }
    }

}
