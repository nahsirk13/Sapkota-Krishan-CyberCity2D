using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // how fast the bullet moves
    private float direction = 1f; // direction the bullet moves in
    private Rigidbody2D rb; // reference to the rigidbody
    private float lifetime; // how long the bullet exists
    [SerializeField] private float maxLifetime = 7f; // max time before destroying

    void Start()
    {
        // get the rigidbody and set its initial velocity
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * direction * speed;
    }

    void Update()
    {
        // destroy the bullet after a certain time
        lifetime += Time.deltaTime;
        if (lifetime > maxLifetime)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(float dir)
    {
        // set the direction and flip the sprite if needed
        direction = dir;
        transform.localScale = new Vector3(direction, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy the bullet when it hits something
        Destroy(gameObject);
    }
}
