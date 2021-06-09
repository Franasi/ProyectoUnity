using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script que se encarga de gestionar el danio que le hacemos al enemigo a la hora de saltarles encima.
public class DanioSalto : MonoBehaviour
{
    //Variables
    public Collider2D collider2D;
    public Animator animacion;
    public SpriteRenderer spriteRenderer;
    public GameObject particulas;
    public float fuerzaSalto = 2.5f;
    public int vidas = 2;

    
    //Al saltar encima del enemigo, si es el player el que ha saltado el enemigo perdera una vida y
    //luego comprobara la vida que le quda
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * fuerzaSalto);
            PerderVida();
            ComprobarVida();
            
        }
    }

    //Metodo que quita una vida y reproduce una animacion de golpe
    public void PerderVida()
    {
        vidas--;
        animacion.Play("Hit");
    }

    //Metodo que comprueba la vida. Si no le quedan vidas se llama al metodo enemigoMuerto
    public void ComprobarVida()
    {
        if (vidas==0)
        {
            particulas.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("EnemigoMuerto", 0.2f);
        }
    }

    //Destruye el objeto que es el enemigo
    public void EnemigoMuerto()
    {
        Destroy(gameObject);
        
    }
}
