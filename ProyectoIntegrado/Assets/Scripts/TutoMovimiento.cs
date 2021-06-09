using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script que se encarga de eliminar el primer mensaje del tutorial tras 3 segundos.
public class TutoMovimiento : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject, 3.5f);
    }

    
}
