using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovimientoJoystick : MonoBehaviour
{

    private float movimientoHorizontal = 0f;
    private float movimientoVertical = 0f;
    public Joystick joystick;

    public float velocidadHorizontal = 2;


    //Variables
    public float movimiento = 2;
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
        rigi2D = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        animacion = GetComponent<Animator>();
    }

    private void Update()
    {
        

        //Al mover el joystick hacia la la derecha nuestro personaje se movera a la derecha
        if (movimientoHorizontal>0)
        {
            spriteR.flipX = false;
            animacion.SetBool("Correr", true);
            if (ComprobarSuelo.comprobarSuelo == true)
            {
                polvoIzquierda.SetActive(true);
                polvoDerecha.SetActive(false);
            }

        }

        //Al mover el joystick hacia la izquierda nuestro personaje se movera a la izquierda
        else if (movimientoHorizontal<0)
        {
           
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
            
            animacion.SetBool("Correr", false);
            polvoIzquierda.SetActive(false);
            polvoDerecha.SetActive(false);
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
        if (rigi2D.velocity.y < 0)
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

        movimientoHorizontal = joystick.Horizontal * velocidadHorizontal;
        transform.position += new Vector3(movimientoHorizontal, 0, 0) * Time.deltaTime * movimiento;
       
        

     


    }


    //Metodo de salto para asignarselo al boton para la version de Android.
    public void Salto()
    {
        if (ComprobarSuelo.comprobarSuelo)
        {
            posibilidadSaltoDoble = true;
            rigi2D.velocity = new Vector2(rigi2D.velocity.x, salto);
        }
        else
        {

            if (posibilidadSaltoDoble)
            {
                animacion.SetBool("SaltoDoble", true);
                rigi2D.velocity = new Vector2(rigi2D.velocity.x, saltoDoble);
                posibilidadSaltoDoble = false;
            }


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
