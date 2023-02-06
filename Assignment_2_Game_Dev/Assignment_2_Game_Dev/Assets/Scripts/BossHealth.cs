using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* in this class like the player i have everything related to the enemy health
 * I also have the collision detection and death parameters set so the enemy will die(get destroyed)
 * after three hits from the players bullet
 * this script will also spawn the diamond prefab upon the emnemies death
 */

/* 
 * this class is pretty much the same as the regular enemy only this boss has more health
 */

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public GameObject coinPrefab;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Bullet")
        {
            print("Bullet hit");
            currentHealth--;
            if (currentHealth == 0)
            {
                GameObject g = Instantiate(coinPrefab, this.transform.position, Quaternion.identity);
                g.transform.position = this.transform.position;
                Destroy(this.gameObject);
            }
        }
    }
}
