using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    // creating our target object
    public GameObject cow;
    private Rigidbody2D myRigidBody;
    void Start()
    {
        // creating our rigidbody and finding our player by searching for its tag
        myRigidBody = GetComponent<Rigidbody2D>();
        cow = GameObject.FindGameObjectWithTag("Cow");

        // setting the direction the fireBall will be traveling
        Vector3 direction = cow.transform.position - transform.position;
        // destorying the fireBall after 10 seconds
        Destroy(this.gameObject, 10);
    }

    void Update()
    {
        // moving our object across the screen
        myRigidBody.linearVelocity = new Vector2(2f, 0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // if it collides with a cow or log it will be destoryed
        if (collision.gameObject.CompareTag("Cow") || collision.gameObject.CompareTag("Log"))
        {
            Destroy(this.gameObject);
        }
    }


}
