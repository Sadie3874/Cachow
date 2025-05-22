using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class FollowCowPlatform : MonoBehaviour
{
    // vars for move speed
    public float moveSpeed;
    // creating a transform for cow and having a rigidbody
    private Transform cow;
    public Rigidbody myRigidBody;
    void Start()
    {
        // finding the cow tag to follow 
        cow = GameObject.FindGameObjectWithTag("Cow").transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, cow.position, moveSpeed * Time.deltaTime);
        // Frezzing the x location so it will only follow the cow up and down
        transform.position = new Vector3(-8f, transform.position.y, transform.position.z);
    }
}
