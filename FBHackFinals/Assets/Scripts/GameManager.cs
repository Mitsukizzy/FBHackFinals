using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : FirebaseTest
{

    private VideoPlayer vid;
    private VideoClip clip;
    public GameObject resultsCanvas;

    // Use this for initialization
    void Start()
    {
        //SaveScore (13);
        vid = GameObject.Find("VideoScreen").GetComponent<VideoPlayer>();
        clip = vid.clip;
        vid.Play();
        vid.loopPointReached += ShowResults;
        StartWait();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowResults(UnityEngine.Video.VideoPlayer vp)
    {
        resultsCanvas.SetActive(true);
    }


    IEnumerator StartWait()
    {
        float dur = (float)clip.length;
        yield return StartCoroutine(Wait(dur));
    }

    private IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}
