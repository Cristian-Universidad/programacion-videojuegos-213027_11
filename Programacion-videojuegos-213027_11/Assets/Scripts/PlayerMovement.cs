using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    public bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebote;

    [SerializeField] private AudioClip saltoSonido;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (Horizontal > 0.0f)
            transform.localScale = new Vector3(Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);

        Animator.SetBool("running", Horizontal != 0.0f);

        // Verificar si el personaje está en el suelo y no está ascendiendo ni descendiendo
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f) && Mathf.Abs(Rigidbody2D.velocity.y) < 0.1f)
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
            ControladorSonido.Instance.EjecutarSonido(saltoSonido);
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        if (sePuedeMover)
        {
            Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
        }
        
    }

    public void Rebote(Vector2 puntoGolpe)
    {
        Rigidbody2D.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
    }
}