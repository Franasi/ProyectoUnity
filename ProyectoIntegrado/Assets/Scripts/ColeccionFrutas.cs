using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


//Script que en futuro nos otorgara vida al recoger todas las frutas en un nivel
public class ColeccionFrutas : MonoBehaviour
{

    public static float puntuacionInt=0;
    
    private void Update()
    {
        FrutasConseguidas();
    }



    public void FrutasConseguidas()
    {
        /*Cada vez que pillamos una fruta el objeto desaparece, por eso preguntamos le preguntamos al objeto padre que contiene las frutas
         cuantos hijos tiene. Si no tiene objetos hijos entrara en el if
        */
        if (transform.childCount==0)
        {
            //Manda por consola un mensaje diciendo que hemos recogido todas las frutas del nivel
            Debug.Log("FRUTAS RECOGIDAS");
        }
    }
}
