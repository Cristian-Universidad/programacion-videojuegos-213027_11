using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

public class VidaJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;
    public event EventHandler MuerteJugador;
    private Rigidbody2D rb2D;
    private PlayerMovement movimientoJugador;
    [SerializeField] private float tiempoPerdidaControl;
    private void Start()
    {
        movimientoJugador = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void TomarDaño(float daño, Vector2 posicion)
    {
        vida -= daño;
        if (vida <= 0)
        {        
            StartCoroutine(PerderControl());
            movimientoJugador.Rebote(posicion);
            animator.SetTrigger("Muerte");
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Enemigos"), true);
        }
        
    }
    private IEnumerator PerderControl()
    {
        movimientoJugador.sePuedeMover = false;;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador.sePuedeMover = true;
    }

    public void MuerteJugadorEvento()
    {
        MuerteJugador?.Invoke(this, EventArgs.Empty);
    }
}
