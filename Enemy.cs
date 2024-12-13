using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for scene transitions
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveRange = 3f;
    [SerializeField] private float sideToSideSpeed = 1.5f;
    [SerializeField] private float sideToSideRange = 2f;
    [SerializeField] private AudioClip hitSound;  // the shooting sound
    [SerializeField] private float pushbackForce = 5f;  // Force applied on collision

    private AudioSource audioSource;
    [SerializeField] private int ballonHP = 10;  // count how many times ballon hit
    private Rigidbody2D body;


    private Vector3 startPosition;
    private Vector3 initialScale;
    private bool isHit = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // save the starting position and scale
        startPosition = transform.position;
        initialScale = transform.localScale;
    }

    void Update()
    {
        //stop movement and growth if the balloon is hit
        if (isHit) return;


        // move the balloon up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveRange;

        // move the balloon side to side
        float newX = startPosition.x + Mathf.Cos(Time.time * sideToSideSpeed) * sideToSideRange;

        // set the new position
        transform.position = new Vector3(newX, newY, transform.position.z);



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if it hit the bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            audioSource.PlayOneShot(hitSound);
            ballonHP--;  //decrement ballon HP (default 5)
            Debug.Log("Balloon hit by bullet!");
            Destroy(collision.gameObject); // destroy the bullet
                                           // Push the enemy back

            // Apply pushback force
            if (body != null)
            {
                Vector2 pushDirection = (transform.position - collision.transform.position).normalized; // Direction away from the bullet
                body.AddForce(pushDirection * pushbackForce, ForceMode2D.Impulse);
            }
            if (ballonHP == 0) //must hit balloon 5 times to win
            {
                ballonHP = 10; //bring it back to 3 default HP

                Debug.Log($"Enemy Killed!!");
                audioSource.PlayOneShot(hitSound);
                Destroy(gameObject);

            }


        }
    }



}
