using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for scene transitions
using TMPro;

public class Balloon : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; 
    [SerializeField] private float moveRange = 3f; 
    [SerializeField] private float sideToSideSpeed = 1.5f; 
    [SerializeField] private float sideToSideRange = 2f; 
    [SerializeField] private float growRate = 0.1f; 
    [SerializeField] private float maxSize = 3f;
    [SerializeField] private AudioClip hitSound;  // the shooting sound
    private AudioSource audioSource;
    [SerializeField] private int ballonHP = 5;  // count how many times ballon hit


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

        // grow the balloon over time
        if (transform.localScale.x < maxSize)
        {
            transform.localScale += Vector3.one * growRate * Time.deltaTime;
        }

        //  if balloon hits max size, make it disappear and add to player score
        if (transform.localScale.x >= maxSize)
        {

            Destroy(gameObject);

            GoToNextScene();
        }


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

            if (ballonHP ==0) //must hit balloon 5 times to win
            {
                ballonHP = 5; //bring it back to 5 default HP

                float balloonSize = transform.localScale.x; //get size of balloon at pop
                int score = Mathf.RoundToInt((maxSize - balloonSize) * 100); // higher score for smaller size

                Debug.Log($"Balloon popped! Size: {balloonSize}, Score: {score}");

                Destroy(gameObject);

                // update the player's score
                GoToNextScene(); // trigger next scene

            }
        }
    }


    private void GoToNextScene()
    {
        
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene("Menu");
            //TODO:add to high score list
        }
    }



}
