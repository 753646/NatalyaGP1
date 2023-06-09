using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    Transform player;
    Transform boss;
    public float speed;
    Rigidbody2D rb;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
        rb = GetComponent<Rigidbody2D>();
        //a way check where the player is and set the 

        if (boss.position.x >= player.position.x)
        {
            direction = new Vector2(-1, 0);
        }
        else
        {
            direction = new Vector2(1, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
