using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArgoZone : MonoBehaviour
{
    public GameObject target;
    public GameObject enemy;
    public float movementSpeed = 2F;
    private Rigidbody2D enemyRigidBody;

    private Vector2 calculatedDirection;
    private bool targetDetected = false;

    private Animator bettleAnimator;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        enemyRigidBody = enemy.GetComponent<Rigidbody2D>();

        bettleAnimator = enemy.GetComponent<Animator>();

        spriteRenderer = enemy.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (targetDetected) {
            bettleAnimator.SetBool("IsWalking", true);

            if (calculatedDirection.y < 0)
                spriteRenderer.flipY = true;
            else
                spriteRenderer.flipY = false;
        }
        else {
            bettleAnimator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate() {
        if (targetDetected) {
            calculatedDirection = (target.transform.position - enemy.transform.position).normalized;

            enemyRigidBody.velocity = calculatedDirection * movementSpeed;
        }
        else {
            enemyRigidBody.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name.Equals(target.name))
            targetDetected = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.name.Equals(target.name))
            targetDetected = false;
    }
}
