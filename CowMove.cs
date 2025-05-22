using System;
using UnityEngine;

public class CowMove : MonoBehaviour // done
{
    // all scripts can access this because it is a public static event
    public static event Action onCowDeath;

    public Rigidbody2D myRigidBody;
    private SpriteRenderer mySpriteRenderer;
    public GameObject gameOver;

    // vars for the move and jump speed
    public float moveSpeed = 5;
    public float jumpSpeed = 40;

    // var to see if the cow is still alive or is jumping
    public bool cowAlive = true;
    private bool isCowJumping;
    public int cowhealth = 3;
    void Start()
    {
        // retriving our components
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if player clicks certin key the cow will move in its respective direction
        if (Input.GetKey(KeyCode.D) && cowAlive)
        {
            // flipping the sprite so it faces the direction it is going
            mySpriteRenderer.flipX = true;
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) && cowAlive)
        {
            mySpriteRenderer.flipX = false;
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Space) && cowAlive && !isCowJumping)
        {
            transform.Translate(Vector2.up * jumpSpeed * 8 * Time.deltaTime);
            isCowJumping = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D other) 
    {
        // if cow is jumping and has not come into contact with the tags ground or log
        // this will prevent cow from double jumping
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Log"))
        {
            isCowJumping = false;
        }
        else if (other.gameObject.CompareTag("Fireball"))
        {
            // Checking if the game object is a fireball if so we will take
            // away a life and if it is 0 then we will throw the game over screen 
            if (cowhealth >= 2)
            {
                cowhealth -= 1;
            }
            else if (cowhealth == 1)
            {
                cowhealth -= 1;
                // call the game over screen
                cowAlive = false;
                onCowDeath?.Invoke();
            }

        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            // call the game over screen
            onCowDeath?.Invoke();
        }
    }
    
}
