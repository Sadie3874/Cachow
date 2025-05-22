using UnityEngine;

public class MovingLog : MonoBehaviour // done
{
    // var to hold both markers
    public Transform pointA;
    public Transform pointB;
    // speed we are moving at
    public float moveSpeed = 2;

    private Vector3 nextPostition;
    void Start()
    {
        // position b is the first postion we move towards 
        nextPostition = pointB.position;
    }

    
    void Update()
    {
        // this is how the logs move side to side
        // we create markers point a and b then we move towards thoes markers
        transform.position = Vector3.MoveTowards(transform.position, nextPostition, moveSpeed * Time.deltaTime);
        // we need to check if the position of the log is the same as one of the markers we have
        // we use nextPosition to check if the vector3 we have inputed is the same as our current moving log
        if(transform.position == nextPostition)
        {
            // if it is, we change our next position to and or b and the cycle repeats 
            if(nextPostition == pointA.position)
            {
                nextPostition = pointB.position;
            }
            else if(nextPostition == pointB.position)
            {
                nextPostition = pointA.position;
            }
        }
    }
}
