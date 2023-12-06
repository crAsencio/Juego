using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;

    private Rigidbody2D rigidBody;
    private bool mirandoDerecha = true;
    private Animator animator;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }

    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }


    void ProcesarMovimiento()
    {
        //Logica de Movimiento
        float inputMovimiento = Input.GetAxis("Horizontal");
       
         if(inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);

        GestionarOrientacion(inputMovimiento);
    }

    void GestionarOrientacion(float inputmovimiento)
    {
        //Si se cumple condicióm
        if ((mirandoDerecha == true && inputmovimiento < 0) || (mirandoDerecha == false && inputmovimiento > 0))
        {
            //Ejecutar codigo de volteado 
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }
}
