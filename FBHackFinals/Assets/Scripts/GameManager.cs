using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class GameManager : FirebaseTest
{

    private VideoPlayer vid;
    private VideoClip clip;
    private Animation anim;
    public GameObject resultsCanvas;
    public GameObject speechCanvas;
    public GameObject cameraRig;
    public IBM.Watson.DeveloperCloud.Widgets.SpeechToTextWidget speechToText;
    public FormWordCloud cloud;
    public Text resultText;

    private string[] successTexts = new string[] {
        "Good job on avoiding potential unconscious bias with identifying gender! A person's role or presence in the office should not cause assumptions of their gender.",
        "Good job on avoiding potential unconscious bias with identifying sexual orientation!",
        "Good job on standing up against ageism! A person's age is not a way of measuring their skill or capability."
    };

    private string[] failureTexts = new string[] {
        "Watch out for unconscious bias with identifying gender! From the information given, Sam can possibly identify as a female.",
        "Watch out for unconscious bias with identifying sexual orientation! From the information given, the employee's partner could be male or female.",
        "Watch out for ageism! A person's age is not a way of measuring their skill or capability."
    };

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
        cameraRig.SetActive(true);

        // TODO: Replace with code that waits for response
        // Temporarily will just wait for 3 sec to calculate then show results
        StartCoroutine(Wait(7.0f));
    }    
    
    public void ShowResults()
    {
        StartWait();
        string[] collisions = speechToText.GetCollisions();
        int moduleNum = speechToText.moduleNum;
        
        if (moduleNum == 2)
        {
            resultText.text = "Look around! These were some of the words you used to describe your colleague. How would you feel if these words were described of you?";
            return; 
        }

        if(collisions.Length > 0)
        {
            resultText.text = failureTexts[moduleNum-1];
            resultText.text += "\nDetected words:";
            for(int i = 0; i < collisions.Length; i++)
            {
                resultText.text += "," + collisions[i];
            }
        }
        else
        {
            resultText.text = successTexts[moduleNum-1];
        }
    }

    private void StartWait()
    {
        StartCoroutine(WaitForResults(3.0f));
    }

    private IEnumerator WaitForResults(float duration)
    {
        anim.Play();
        yield return new WaitForSeconds(duration);
        speechCanvas.SetActive(false);
        cameraRig.SetActive(false);
        resultsCanvas.SetActive(true);

        if(cloud)
        {
            cloud.ProcessWords(speechToText.GetCollisions());
        }
    }

    private IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
        ShowResults();
    }
}
