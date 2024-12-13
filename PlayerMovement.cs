using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>(); //check player object for rigid body component
        anim = GetComponent<Animator>(); //get player animator 
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        //horizontal movement
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        
        //flip player if moving left or right
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);

        //call jump function
        if (Input.GetKey(KeyCode.W) && grounded)
            Jump();
        anim.SetBool("grounded", grounded);

    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed*1f);
        anim.SetTrigger("jump");
        grounded = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

}
