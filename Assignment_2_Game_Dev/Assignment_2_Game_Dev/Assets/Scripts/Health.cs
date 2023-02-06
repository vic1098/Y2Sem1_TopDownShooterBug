using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* this classs is where all the values related to the player health
 * are stored, it sets the player health to 3, 
 * in the void start is sets the max health to the current health ensuring the player always
 * starts with full health
 * is started a method that would eventually take away the players health but didnt have enough
 * time to finish it, however the enemys version of this works so i will show that when i get there
 */

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     /*
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            // the player dies here
            animator.SetBool("", true);// this will be the player death animation
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    */
}
