using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booDesaparece : MonoBehaviour
{
    // Variable para saber si el enemigo está desapareciendo
    public bool estaDesapareciendo = false;

    // Array para los objetos que harán desaparecer al Boo
    public GameObject[] objetos;

    public bool apareciendo = true;
    public AudioSource audioSource;
    public AudioClip sonidoAparecer;
    public AudioClip sonidoDesaparecer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si el objeto con el que el Boo entra en contacto está en el array de objetos
        foreach (GameObject objeto in objetos)
        {
            if (other.gameObject == objeto)
            {
                // Si es así, inicia la rutina de desaparición
                estaDesapareciendo = true;
                StartCoroutine(desaparecer());
            }
        }
    }
    public IEnumerator aparecer()
    {
        Vector3 escalaFinal = transform.localScale;
        transform.localScale = Vector3.zero;

        // Almacena la rotación original del Boo
        Quaternion rotacionOriginal = transform.rotation;

        audioSource.PlayOneShot(sonidoAparecer);

        for (float f = 0f; f <= 1; f += 0.1f)
        {
            // Hace que el enemigo gire
            transform.Rotate(0, 0, -100);

            transform.localScale = Vector3.Lerp(Vector3.zero, escalaFinal, f);

            yield return new WaitForSeconds(0.1f);
        }

        // Restaura la rotación original del Boo
        transform.rotation = rotacionOriginal;
        // El enemigo ha terminado de aparecer
        apareciendo = false;
    }
    IEnumerator desaparecer()
    {
        Vector3 originalScale = transform.localScale;
        
        // Desactiva el Collider2D para que el enemigo deje de interactuar con el jugador
        GetComponent<Collider2D>().enabled = false;

        audioSource.PlayOneShot(sonidoDesaparecer);

        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            // Hace que el enemigo gire
            transform.Rotate(0, 0, 100);

            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, 1 - f);

            yield return new WaitForSeconds(0.1f);
        }

        contadorEnemigos.IncreaseCount();

        // Destruye el enemigo
        Destroy(gameObject);
    }
}