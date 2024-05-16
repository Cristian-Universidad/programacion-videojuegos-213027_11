using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooController : MonoBehaviour
{
    public float speed = 3f; 
    private Transform player; 

    void Start()
    {
     
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        Vector2 direction = (player.position - transform.position).normalized;

       
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
