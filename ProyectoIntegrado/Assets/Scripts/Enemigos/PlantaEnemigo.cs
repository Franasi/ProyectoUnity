using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script que se encarga de gestionar al enemigo planta

public class PlantaEnemigo : MonoBehaviour
{

    //Variables 

    private float tiempoEspera;
    public float tiempoEsperaAtaque=3;
    public Animator animacion;
    public GameObject balaPrefab;
    public Transform cargarSpawnBala;


    private void Start()
    {
        tiempoEspera = tiempoEsperaAtaque;
    }


    //Tiempo que tiene que pasar hasta que la planta dispare otra bala.
    //Al dispara realizara una animacion de disparo
    private void Update()
    {
        if (tiempoEspera<=0)
        {
            tiempoEspera = tiempoEsperaAtaque;
            animacion.Play("Ataque");
            Invoke("CargarBala", 0.5f);
        }
        else
        {
            tiempoEspera -= Time.deltaTime;
        }
    }


    //Creamos la bala prefabricada
    public void CargarBala()
    {

        GameObject nuevaBala;

        nuevaBala = Instantiate(balaPrefab, cargarSpawnBala.position, cargarSpawnBala.rotation);

    }

}
