using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    // initilize the playerCoinAmount
    public int coins = 0;


    /* Having given the coin collectable a tag of Collectables
    * i see if the player has collided with the coin and based off this
    * i update the player inventory to increace by the amount of the coin
    * i then destroy the coin once it has been collected
    * 
    * There is a commented bit, this is where i was trying to change the sene - after
    * 5 coins were collected the Unity System Scene Manager would recognise the coin total
    * and change the scene to the "2_Level_Boss", showing the player progressing to the
    * final boss.
    */


    //public void LoadScene()
    //{
    //   // SceneManager.LoadScene;
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Collectables")
        {
            GameObject collectable = collision.gameObject;

            int collectableValue = collectable.GetComponent<ItemValue>().itemValue;

            coins += collectableValue;

            if (coins == 5)
            {
               SceneManager.LoadScene("3_Level_Boss");
               
            }

            //if (coins == 5)
            //{
            //    SceneManager.goToLevelTwo(); // this is my attempt at changing the scene
            //}

            Destroy(collectable);

        }
    }
}
