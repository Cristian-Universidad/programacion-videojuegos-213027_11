using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boo : MonoBehaviour
{
    [SerializeField] private float tiempoEntreDaño;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if  (other.gameObject.CompareTag("Player"))
        {
            Vector2 direction = (other.transform.position - transform.position).normalized;
            other.gameObject.GetComponent<VidaJugador>().TomarDaño(20, direction);
        }
    }
}
