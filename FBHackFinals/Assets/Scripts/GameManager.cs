using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : FirebaseTest
{

    private VideoPlayer vid;
    private VideoClip clip;
    private Animation anim;
    public GameObject resultsCanvas;

    // Use this for initialization
    void Start()
    {
        vid = GameObject.Find("VideoScreen").GetComponent<VideoPlayer>();
        clip = vid.clip;
        anim = vid.GetComponent<Animation>();

        vid.Play();
        vid.loopPointReached += ShowResults;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowResults(UnityEngine.Video.VideoPlayer vp)
    {
        StartWait();
    }


    private void StartWait()
    {
        StartCoroutine(Wait(3.0f));
    }

    private IEnumerator Wait(float duration)
    {
        anim.Play();
        yield return new WaitForSeconds(duration);
        resultsCanvas.SetActive(true);
    }
}
