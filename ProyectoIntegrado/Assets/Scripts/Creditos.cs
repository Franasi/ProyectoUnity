using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script que se encarga de gestionar la pantalla de creditos
public class Creditos : MonoBehaviour
{
   
    //Llama al metodo FinalCreditos al pasar 27 segundos
    void Start()
    {
        Invoke("FinalCreditos", 27);
    }

    //Si pulsamos la tecla "Esc" nos llevara al menu principal
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    //Metodo que al llamarlo nos llevara al menu principal
    public void FinalCreditos()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
