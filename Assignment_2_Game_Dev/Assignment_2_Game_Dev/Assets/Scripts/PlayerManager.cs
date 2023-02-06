using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    // initilize rotation speed to allow the player to rotate (Move left and Right)
    public float rotationSpeed = 5.0f;
    // initilize player speed to allow the player to physically move
    public float playerSpeed = 1;

    /* ititilize the reference the the bullet prefab
     * initilize the gunTip gameObject which will be where the bullets
     * will spawn/shoot from and the bullet speed and a vector2 for the bullets direction*/ 
    public Bullet bulletPrefab;
    public GameObject gunTip;
    public float bulletSpeed = 2.0f;
    private Vector2 bulletDirection;

    /* initilize a rigidbody that will reference the players rigid body
     * 2 vector2's which will aid in the player movement and the player animator 
     * initilized*/
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lookDir;
    private Animator animator;
    // private SpriteRenderer playerSR;

    // initilizing values to make the player look up, down, left, right
    private float myLeft = 90;
    private float myRight = -90;
    private float myUp = 0;
    private float myDown = 180;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        animator = gameObject.GetComponent<Animator>();

        // playerSR = gameObject.GetComponent<SpriteRenderer>();
    }

    /*in the void update we set the walking to true or false
     * i use code to see what direction the player is moving an rotate the spritevrelative to this 
     * the bullet transform direction is done here - i.e. if the player is facing 
     * up the bullet shoots up and if the palyer is facing down the bullet shoots down, etc */
    void Update()
    {
        if (movement != Vector2.zero)
        {
            animator.SetBool("Walk", true);

            if (movement.y < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, myDown);
                bulletDirection = Vector2.down;
                //playerSR.flipY = true;
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, myUp);
                bulletDirection = Vector2.up;

                //playerSR.flipY = false;
            }

            if (movement.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, myLeft);
                bulletDirection = Vector2.left;
            }
            else if(movement.x >0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, myRight);
                bulletDirection = Vector2.right;
            }


        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    // in this method the players movement speed is set relative to the Time.fixedDelta time
    // which is just the amount of time that has passed since the last update, allowing
    // for better player movement
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * playerSpeed * Time.fixedDeltaTime));
    }

    // this method moves the player relative to what key is being pressed
    void OnMove(InputValue movePosition)
    {

        movement = movePosition.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookDir = value.Get<Vector2>();
    }
    void OnFire()
    {
        animator.SetTrigger("Shoot");
        FireBullet();
    }

    /* this method is what fires the bullet
     * it instantiates the bullet prefab sets its start point at the guntip and uses
     * a quaternion to know where this point is, it sets the direction the bullet travels in
     * and destroys the bullet after 3 seconds ensuring the bullet dosen't fly forever*/
    private void FireBullet()
    {
        // instantiate a bullet object
        // set the transform and rotation = player tran and rotation
        Bullet b = Instantiate(bulletPrefab, gunTip.transform.position, Quaternion.identity);
        b.transform.position = gunTip.transform.position;
        b.transform.rotation = gunTip.transform.rotation;
        b.Player = this.gameObject;
        b.direction = (Vector3)bulletDirection;
        Destroy(b.gameObject, 3f);
    }
}
