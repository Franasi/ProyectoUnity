using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script que se al pasar por el trampolin nos impulsara hacia arriba
public class Trampolin : MonoBehaviour
{
    //Variables
    public Animator animacion;

    public float fuerzaSalto = 2f;

    //Si el trampolin entra en conacto con el jugador este saldra impulsado y se activara una animacion del trampolin
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * fuerzaSalto);
            animacion.Play("SaltoTrampolin");
        }
    }
}
