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
    public GameObject speechCanvas;

    // Use this for initialization
    void Start()
    {
        vid = GameObject.Find("VideoScreen").GetComponent<VideoPlayer>();
        clip = vid.clip;
        anim = vid.GetComponent<Animation>();

        vid.Play();
        vid.loopPointReached += ListenForResponse;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Video finished playing, wait for response
    public void ListenForResponse(UnityEngine.Video.VideoPlayer vp)
    {
        // Show mic listener text
        speechCanvas.SetActive(true);

        // TODO: Replace with code that waits for response
        // Temporarily will just wait for 3 sec to calculate then show results
        StartCoroutine(Wait(3.0f));


        ShowResults();
    }    
    
    public void ShowResults()
    {
        StartWait();
    }

    private void StartWait()
    {
        StartCoroutine(WaitForResults(3.0f));
    }

    private IEnumerator WaitForResults(float duration)
    {
        anim.Play();
        yield return new WaitForSeconds(duration);
        resultsCanvas.SetActive(true);
    }

    private IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}
