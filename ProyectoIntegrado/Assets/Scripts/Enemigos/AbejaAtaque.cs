using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Script encargado de realizar el ataque de la abeja mediante RayCast
 */
public class AbejaAtaque : MonoBehaviour
{
    //Variables

    public Animator animacion;
    public float distanciaRayCast = 0.5f;
    private float cdAtaque = 1.5f;
    private float volverAtacar;
    public GameObject abejaBala;


    void Start()
    {
        volverAtacar = 0;
    }


    void Update()
    {
        volverAtacar -= Time.deltaTime;
    }


    //Usamos RayCast. Al pasar por debajo de la abeja esta nos detectara y nos disparara.
    private void FixedUpdate()
    {
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position,Vector2.down,distanciaRayCast);

        if (hit2.collider!=null)
        {
            if (hit2.collider.CompareTag("Player"))
            {
                if (volverAtacar<0)
                {
                    Invoke("CargarBala",0.5f);
                    animacion.Play("Ataque");
                    volverAtacar = cdAtaque;
                }
            }
        }
    }

    //Metodo que llama a la bala prefabricada
    void CargarBala()
    {
        GameObject nuevaBala;

        nuevaBala = Instantiate(abejaBala,transform.position,transform.rotation);
    }
}
