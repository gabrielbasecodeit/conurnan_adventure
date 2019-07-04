using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour 
{    
	// The target we are following
	
	private Vector3 velocity = Vector3.zero;

    private float cameray = 1.625076f;
    private float cameraz = 5.046852f;

	// Place the script in the Camera-Control group in the component menu
//	[AddComponentMenu("Camera-Control/Smooth Follow")]
	void Update() 
    {
        //transform.LookAt(target.position);
        //transform.position += new Vector3(target.position.x * 1f * Time.deltaTime, transform.position.y, transform.position.z);
        //transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
		//transform.position = new Vector3(target.position.x,transform.position.y,transform.position.z);
	}

    private void ResetCamera()
    {
        transform.position = new Vector3(transform.position.x, cameray, cameraz);

    }
}