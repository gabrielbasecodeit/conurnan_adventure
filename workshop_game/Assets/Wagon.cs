using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    public Transform target;  
    private float speed = .001f; // Speed in units per second
    private float restrictedY =  1.37f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!target)
            return;
    
        var dir=(target.position - transform.position);
    
        // Then add the direction * the speed to the current position:
        transform.position += dir * speed * Time.deltaTime;
        
        transform.position = new Vector3(transform.position.x, restrictedY, 0);
        //transform.Translate(dir * Time.deltaTime);
        //speed += 0.001f;

        
    }
}
