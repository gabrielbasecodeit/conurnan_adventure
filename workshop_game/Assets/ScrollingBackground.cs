using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private float speed = 5f;
    private Vector3 originalPos = new Vector3(-31.379f, -3.5128f, 13.49f);
    private bool continueBackgroundRolling = true; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Stop()
    {
        continueBackgroundRolling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(continueBackgroundRolling)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            //speed += 0.1f;

            if(transform.position.x < -100)
            {
                transform.position = originalPos;
            }
        }
    }
}
