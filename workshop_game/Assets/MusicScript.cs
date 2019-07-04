using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioSource startMusic;
    void Start()
    {
        startMusic = GetComponent<AudioSource>();
        startMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
