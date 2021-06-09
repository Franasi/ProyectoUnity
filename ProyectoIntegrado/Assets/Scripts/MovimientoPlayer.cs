using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



/*
 * Script que se encarga de gestionar y realizar los movimientos de nuestro personaje
 */

public class MovimientoPlayer : MonoBehaviour
{


    //Variables
    public float movimiento=2;
    public float salto = 3;
    public float caidaSalto = 0.5f;
    public float saltoBajo = 1;
    public float saltoDoble = 2;

    //Variable boleana que nos permitira saber si nuestro personaje puede realizar un salto doble o no
    private bool posibilidadSaltoDoble;

    //Referencia a nuestro Rigidbody2D
    Rigidbody2D rigi2D;

    //Referencia a nuestro SpriteRenderer
    SpriteRenderer spriteR;

    //Referencia a nuestro Animator
    Animator animacion;



    public GameObject polvoIzquierda;
    public GameObject polvoDerecha;


    void Start()
    {
        rigi2D=GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        animacion = GetComponent<Animator>();
    }

    private void Update()
    {
        //Si pulsamos r se reiniciara el nivel
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //Si pulsamos 0 volvemos al menu principal
        if (Input.GetKey("0"))
        {
            SceneManager.LoadScene("MenuPrincipal");
        }

        //Si pulsamos 9 nos lleva a la pantalla de creditos
        if (Input.GetKey("9"))
        {
            SceneManager.LoadScene("Creditos");
        }

        //Si pulsamos 1 nos llevara al nivel 1
        if (Input.GetKey("1"))
        {
            SceneManager.LoadScene("Nivel1");
        }

        //Si pulsamos 2 nos llevara al nivel 2
        if (Input.GetKey("2"))
        {
            SceneManager.LoadScene("Nivel2");
        }

        //Si pulsamos 3 nos llevara al nivel 3
        if (Input.GetKey("3"))
        {
            SceneManager.LoadScene("Nivel3");
        }

        //Si pulsamos 4 nos llevara al nivel 4
        if (Input.GetKey("4"))
        {
            SceneManager.LoadScene("Nivel4");
        }

        //Si pulsamos 5 nos llevara al nivel 5
        if (Input.GetKey("5"))
        {
            SceneManager.LoadScene("Nivel5");
        }

        //Si pulsamos 8 nos llevara al jumpscare
        if (Input.GetKey("8"))
        {
            SceneManager.LoadScene("Sorpresa");
        }


        //Si pulsamos "espacio" y comprobarSuelo es true nuestro personaje saltara si no es true entrara en otra condicion, si pulsamos
        //espacio comprobara si la variable posibilidadSaltoDoble es true y en caso de que lo sea realizara una animacion, un salto extra y
        //pondra la variable mencionada en false
        if (Input.GetKey("space"))
        {
            
            if (ComprobarSuelo.comprobarSuelo)
            {
                posibilidadSaltoDoble = true;
                rigi2D.velocity = new Vector2(rigi2D.velocity.x, salto);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (posibilidadSaltoDoble)
                    {
                        animacion.SetBool("SaltoDoble",true);
                        rigi2D.velocity = new Vector2(rigi2D.velocity.x, saltoDoble);
                        posibilidadSaltoDoble = false;
                    }
                }

            }
           
        }

        //Si no estamos en el suelo activara la animacion de saltar y desactivara la de correr
        if (ComprobarSuelo.comprobarSuelo == false)
        {
            animacion.SetBool("Salto", true);
            animacion.SetBool("Correr", false);
            polvoIzquierda.SetActive(false);
            polvoDerecha.SetActive(false);
        }

        //Si estamos en el suelo desactivara las animaciones relacionadas con el salto
        if (ComprobarSuelo.comprobarSuelo == true)
        {
            animacion.SetBool("Salto", false);
            animacion.SetBool("SaltoDoble", false);
            animacion.SetBool("Caer", false);
        }

        //Si nuestra velocidad en el eje y es menor que cero activara la animacion de caer
        if (rigi2D.velocity.y<0)
        {
            animacion.SetBool("Caer", true);
        }

        //Si nuestra velocidad en el eje y es mayor que cero desactivara la animacion de caer
        else if (rigi2D.velocity.y > 0)
        {
            animacion.SetBool("Caer", false);
        }

    }

    void FixedUpdate()
    {

        //Movimiento del personaje. Comprobamos que teclas estamos pulsando.

        //Al pulsar "d" o la flecha derecha el personaje se movera a la derecha y mirara a la derecha
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigi2D.velocity = new Vector2(movimiento, rigi2D.velocity.y);
            spriteR.flipX = false;
            animacion.SetBool("Correr", true);
            if (ComprobarSuelo.comprobarSuelo==true)
            {
                polvoIzquierda.SetActive(true);
                polvoDerecha.SetActive(false);
            }
           
        }

        //Al pulsar "a" o la flecha izquierda el personahe se movera a la izquierda y mirara a la izquierda
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigi2D.velocity = new Vector2(-movimiento, rigi2D.velocity.y);
            spriteR.flipX = true;
            animacion.SetBool("Correr", true);

            if (ComprobarSuelo.comprobarSuelo == true)
            {
                polvoIzquierda.SetActive(false);
                polvoDerecha.SetActive(true);
            }

        }
        //Si no pulsamos nada el personaje se mantendra en su sitio
        else
        {
            rigi2D.velocity = new Vector2(0, rigi2D.velocity.y);
            animacion.SetBool("Correr", false);
            polvoIzquierda.SetActive(false);
            polvoDerecha.SetActive(false);
        }

      
        //Salto mejorado. Si presionamos mas tiempo el espacio saltaremos mas que si no lo hacemos
        
        if (rigi2D.velocity.y<0)
        {
            rigi2D.velocity += Vector2.up * Physics2D.gravity.y * (caidaSalto) * Time.deltaTime;
        }

        if (rigi2D.velocity.y>0 && !Input.GetKey("space"))
        {
            rigi2D.velocity += Vector2.up * Physics2D.gravity.y * (saltoBajo) * Time.deltaTime;
        }
      

    }


    /*
     * Metodo que si nuestro personaje entra en contacto con una fruta nuestra puntacion
     * aumentara de 100 en 100
     * */
    private int score = 100;
    public Text texto;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Fruta"))
        {

            texto.text = score.ToString();
            score = 100 + score;

        }
    }
}
