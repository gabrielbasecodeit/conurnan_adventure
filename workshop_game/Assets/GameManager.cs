using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float startTime;
    public static bool glewEstationReached;
    public ScrollingBackground scrollingBackground;
    public GameObject stationSignPrefab;
    private bool inStation = false;
    private bool gameOver = false;

    void awake()
    {
        startTime = Time.time;
        inStation = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameOver()
    {
        gameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > 60 && !inStation)
        {
            inStation = true;
            glewEstationReached = true;
            scrollingBackground.Stop();

            //play audio boca

        }

        if(gameOver)
        {
            scrollingBackground.Stop();
            GetComponents<AudioSource>()[0].Play();
            SceneManager.LoadScene("Title");            
        }
    }
}
