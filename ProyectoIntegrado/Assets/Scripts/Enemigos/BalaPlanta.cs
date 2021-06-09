using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script que gestiona la bala que la planta dispara a
//modo de proyectil
public class BalaPlanta : MonoBehaviour
{

    //Variables

    public float velocidad = 2;
    public float duracionBala = 2;
    public bool left;


    //Destruye la bala al pasar 2 segundos desde que se disparo
    private void Start()
    {
        Destroy(gameObject,duracionBala);
    }

    //Nos permitira cambiar hacia que lado se dispara la bala
    private void Update()
    {
        if (left)
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        }
    }
}
