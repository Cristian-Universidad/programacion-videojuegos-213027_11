using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contadorEnemigos : MonoBehaviour
{
    public static int enemyCount = 0;
    public static contadorEnemigos instance;

    public Text enemyCountText;
    private void Awake()
    {
        enemyCount = 0;
        // Asegúrate de que solo haya una instancia de EnemyCounter
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void IncreaseCount()
    {
        if (!MenuGameOver.gameOver)
        {
            enemyCount++;

            instance.enemyCountText.text = "Enemigos derrotados: " + enemyCount;
        }
    }
}
