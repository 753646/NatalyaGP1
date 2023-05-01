using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    //declare public max and current health
    public int maxHealth;
    public int currentHealth;
    PlayerMovement playerMovement;
    public int coinCount;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerMovement = GetComponent<PlayerMovement>();
    }

    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Coin":
                coinCount++;
                return true;
            case "Speed+":
                playerMovement.SpeedPowerUp();
                return true;
            default:
                Debug.Log("Item tag or reference not set.");
                return false;
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            PauseGame();
        }

    }

    //create a function that minuses the players current health.
    public void TakeDamage()
    {
        currentHealth -= 1;
    }
    //create a function that will pause the game
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    //create a function that will resume the game
}
