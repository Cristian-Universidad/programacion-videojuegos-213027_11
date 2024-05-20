using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    // Array para los prefabs de los enemigos
    public GameObject[] prefabsEnemigos;

    // Array para los retratos en la escena
    public GameObject[] retratos;

    // Rango de la posición X donde se generarán los enemigos
    public float minX = -10f;
    public float maxX = 10f;

    // Rango de la posición Y donde se generarán los enemigos
    public float minY = -10f;
    public float maxY = 10f;

    // Cantidad inicial de enemigos por ronda
    public int enemigosPorRonda = 5;

    // Incremento mínimo y máximo de enemigos por ronda
    public int minIncrementoEnemigosPorRonda = 1;
    public int maxIncrementoEnemigosPorRonda = 5;

    private int rondaActual = 0;

    private void Start()
    {
        // Inicia la generación de enemigos
        GenerarRonda();
    }

    private void Update()
    {
        // Si no hay enemigos en la escena, genera la siguiente ronda
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            GenerarRonda();
        }
    }

    private void GenerarRonda()
    {
        rondaActual++;
        int incrementoEnemigosEstaRonda = Random.Range(minIncrementoEnemigosPorRonda, maxIncrementoEnemigosPorRonda + 1);
        int enemigosEstaRonda = enemigosPorRonda + (rondaActual - 1) * incrementoEnemigosEstaRonda;

        for (int i = 0; i < enemigosEstaRonda; i++)
        {
            GenerarEnemigo();
        }
    }
    private void GenerarEnemigo()
    {
        // Selecciona un enemigo aleatorio del array
        int indiceEnemigo = Random.Range(0, prefabsEnemigos.Length);

        // Genera una posición aleatoria dentro del rango definido
        Vector3 posicionAleatoria = GenerarPosicionAleatoria();

        // Crea una instancia del enemigo en la posición aleatoria
        GameObject enemigo = Instantiate(prefabsEnemigos[indiceEnemigo], posicionAleatoria, Quaternion.identity);

        // Asegúrate de que hay suficientes retratos para el enemigo
        if (retratos.Length < (indiceEnemigo + 1) * 2)
        {
            Debug.LogError("No hay suficientes retratos para el enemigo");
            return;
        }

        // Asigna los retratos al enemigo
        enemigo.GetComponent<booDesaparece>().objetos = new GameObject[] { retratos[indiceEnemigo * 2], retratos[indiceEnemigo * 2 + 1] };
        StartCoroutine(enemigo.GetComponent<booDesaparece>().aparecer());
    }

    private Vector3 GenerarPosicionAleatoria()
    {
        Vector3 posicionAleatoria;
        float distanciaMinimaAlJugador = 5f; // Ajusta esto a la distancia que quieras
        GameObject jugador = GameObject.FindGameObjectWithTag("Player"); // Asegúrate de que tu jugador tiene el tag "Jugador"

        do
        {
            float posX = Random.Range(minX, maxX);
            float posY = Random.Range(minY, maxY);
            posicionAleatoria = new Vector3(posX, posY, 0);
        }
        while (Vector3.Distance(posicionAleatoria, jugador.transform.position) < distanciaMinimaAlJugador);

        return posicionAleatoria;
    }
}