using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTowardsTo : MonoBehaviour
{
    public Transform t1;
    public Transform t2;
    private float speed = .5f;

    private bool moveToTarget1 = true;
    private bool moveToTarget2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime; // calculate distance to move
        
        if(moveToTarget1)
        {
            transform.position = Vector3.MoveTowards(transform.position, t1.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, t1.position) < 0.001f)
            {
                moveToTarget2 = true;
                moveToTarget1 =false;
            }
        } 
        else
        {
            if(moveToTarget2)
            {
                 transform.position = Vector3.MoveTowards(transform.position, t2.position, step);

                // Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(transform.position, t2.position) < 0.001f)
                {
                    moveToTarget2 = false;
                    moveToTarget1 =true;
                }
            }
        }
    }
}
