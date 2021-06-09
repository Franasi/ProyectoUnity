using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Script que nos mostrara un texto indicandonos como saltar
 * 
 */
public class TutoSalto : MonoBehaviour
{
    public Image tutoSalto;


    //Cuando el jugador entre en contacto con el collider activara el texto y pasado unos segundos destruye el texto y el collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

           
            tutoSalto.gameObject.SetActive(true);
            Destroy(tutoSalto.gameObject, 3.5f);
            Destroy(gameObject);
        }
    }


}
