using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class ShootingScript : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPosition;
    private Rigidbody2D myRigidBody;


    public int direction;
    public int speed;
    //public float deadZone = -45;

    private float timer;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3)
        {
            timer = 0;
            Shoot();
        }

    }
    public void Shoot()
    {
        Instantiate(fireBall, fireBallPosition.position, Quaternion.identity);
    }
    
}
