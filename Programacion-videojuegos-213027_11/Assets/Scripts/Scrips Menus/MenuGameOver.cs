using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private VidaJugador vidaJugador;
    public Text finalTimeText;
    public GameObject timerObject;
    public Text enemyCountText;
    public static bool gameOver = false;

    private void Start()
    {
        vidaJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaJugador>();
        vidaJugador.MuerteJugador += AbrirMenu;
    }

    private void AbrirMenu (object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
        finalTimeText.text = "Tiempo final: " + Timer.finalTime;
        timerObject.SetActive(false);
        enemyCountText.text = "Enemigos derrotados: " + contadorEnemigos.enemyCount;
        gameOver = true;
    }

    public void Reiniciar()
    {
        gameOver = false;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Enemigos"), false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
