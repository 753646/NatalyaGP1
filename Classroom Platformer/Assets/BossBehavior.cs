using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    //creates a box to store information (position, rotation, scale)
    Transform player;
    public float speed = 5f;

    PlayerManager playerManager;

    //store if our boss is flipped or not setting the value to flase
    public bool isFlipped = false;

    //create a variable for the health of our boss
    public int bossHealth = 10;
    public float attackRange;

    //create a series of bools to check and set our phase
    public bool phase2 = false;
    public bool phase3 = false;
    public bool isDead = false;

    //re
    public Transform shotLocation;
    public GameObject projectile;
    //create
    public float timer;
    public float waitingTime;
    // Start is called before the first frame update
    
    void Start()
    {
        //set our referece for out playerManager
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //create a series of if else statement that will chec to see
        //if the boss is below 2 and above 3, below 3 and above 1, 
       //and is less or equal to 0
       //phase2
        if (bossHealth < 7 && bossHealth > 3)
        {
            phase2 = true;
            speed = 3;
            Debug.Log("phase2");
        }
        //phase3
        else if (bossHealth < 3 && bossHealth >= 1)
        {
            phase2 = false;
            Debug.Log("phase3");
            phase3 = true;
        }
        
        else if (bossHealth <= 0)
        {
            phase3 = false;
            Debug.Log("isDead");
            isDead = true;
        }

        timer += Time.deltaTime;
    }

    public void ProjecttileShoot()
    {
        if (timer > waitingTime)
        {
            if (phase2)
            {// clone and create our projectile
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                //reset our timer
                timer = 0f;
            }
               else if (phase3)
            {
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                //reset our timer
                timer = 0f;
            }
        }
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z = -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
   }
    private void OnCollisionEnter(Collision collision)
    {
        playerManager.TakeDamage();
    }
}
