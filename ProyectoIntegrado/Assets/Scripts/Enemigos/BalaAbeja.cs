using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script que gestiona el proyectil que nos lanza la abeja
public class BalaAbeja : MonoBehaviour
{
    public float velocidad = 2;
    public float tiempoVida = 2;


    //Destruye el proyectil pasado unos segundos
    private void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    //Hace que la bala de dispare hacia abajo a una determinada velocidad
    private void Update()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);

    }
}
