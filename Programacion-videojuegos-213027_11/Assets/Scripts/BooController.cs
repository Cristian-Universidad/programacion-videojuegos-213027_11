using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooController : MonoBehaviour
{
    public float speed = 3f; 
    private Transform player;
    public Sprite normalSprite;
    public Sprite ojosTapadosSprite;
    private SpriteRenderer spriteRenderer;
    public float stopDistance = 5f;
    private booDesaparece boosScript;

    void Start()
    {
     
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boosScript = GetComponent<booDesaparece>();
    }

    void Update()
    {
        if (boosScript.apareciendo)
        {
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        float distance = Vector2.Distance(player.position, transform.position);

       //Cambia la orientacion del enemigo dependiendo de la direccion del jugador
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        
        
        //Si el jugador esta mirando al enemigo, el enemigo se queda quieto y se tapa los ojos
        if (PlayerIsLooking() && distance <= stopDistance)
        {
            spriteRenderer.sprite = ojosTapadosSprite;
            return;
        }
       else
        {
            spriteRenderer.sprite = normalSprite;
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }
    bool PlayerIsLooking()
    {
        return Mathf.Sign(player.transform.localScale.x) == Mathf.Sign(transform.position.x - player.position.x);
    }


}
