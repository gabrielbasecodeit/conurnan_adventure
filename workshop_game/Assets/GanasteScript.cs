using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanasteScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioSource ganasteMusic;
    void Start()
    {
        ganasteMusic = GetComponent<AudioSource>();
        ganasteMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
