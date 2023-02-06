using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* this class will give the bullet its direction, speed and its vector so
 * the bullet can move
 */

public class Bullet : MonoBehaviour
{
    public GameObject Player;
    public float bulletSpeed = 20f;
    private Rigidbody2D rb;
    public Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //direction = new Vector3(Player.transform.position.x,
        //                        Player.transform.position.y,
        //                        0f);

    }

    private void Update()
    {
        this.transform.position += direction * bulletSpeed;

        //rb.velocity = this.transform.forward * bulletSpeed;

    }
}
