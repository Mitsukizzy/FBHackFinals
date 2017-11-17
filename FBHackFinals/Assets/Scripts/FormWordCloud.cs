using UnityEngine;
using System.Collections.Generic;
//using LitJson;

public class Phrase
{
    public string term;
    public float occurrences;
}

public class FormWordCloud : MonoBehaviour
{
    public GameObject childObject;
    public float size = 10.0f;
    private List<Phrase> phrases = new List<Phrase>();

    private string jsonString = "[{\"term\":\"the\", \"occurrences\":504},{\"term\":\"to\",\"occurrences\":447},{\"term\":\"rt\",\"occurrences\":433},{\"term\":\"a\",\"occurrences\":382},{\"term\":\"in\",\"occurrences\":299},{\"term\":\"of\",\"occurrences\":274},{\"term\":\"adventure\",\"occurrences\":236},{\"term\":\"and\",\"occurrences\":216},{\"term\":\"for\",\"occurrences\":166},{\"term\":\"is\",\"occurrences\":157},{\"term\":\"on\",\"occurrences\":154},{\"term\":\"cars\",\"occurrences\":136},{\"term\":\"it\",\"occurrences\":122},{\"term\":\"you\",\"occurrences\":116},{\"term\":\"with\",\"occurrences\":100},{\"term\":\"from\",\"occurrences\":87},{\"term\":\"at\",\"occurrences\":85},{\"term\":\"i\",\"occurrences\":85},{\"term\":\"this\",\"occurrences\":85},{\"term\":\"that\",\"occurrences\":83}]";

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;

        // Tell each of the objects to look at the camera
        foreach (Transform child in transform)
        {
            child.LookAt(camera.position);
            child.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    private void Sphere()
    {
        float points = phrases.Count;
        float increment = Mathf.PI * (3 - Mathf.Sqrt(5));
        float offset = 2 / points;
        for (float i = 0; i < points; i++)
        {
            float y = i * offset - 1 + (offset / 2);
            float radius = Mathf.Sqrt(1 - y * y);
            float angle = i * increment;
            Vector3 pos = new Vector3((Mathf.Cos(angle) * radius * size), y * size, Mathf.Sin(angle) * radius * size);

            // Create the object as a child of the sphere
            GameObject child = Instantiate(childObject, pos, Quaternion.identity) as GameObject;
            child.transform.parent = transform;
            TextMesh phraseText = child.transform.GetComponent<TextMesh>();
            phraseText.text = phrases[(int)i].term;
        }
    }

    public void ProcessWords(string[] words)
    {
        //JsonData jsonvale = JsonMapper.ToObject(jsonString);
        //for (int i = 0; i < jsonvale.Count; i++)
        //{
        //    Phrase phrase = new Phrase();
        //    phrase.term = jsonvale[i]["term"].ToString();
        //    phrase.occurrences = float.Parse(jsonvale[i]["occurrences"].ToString());
        //    phrases.Add(phrase);
        //}
        for (int i = 0; i < words.Length; i++)
        {
            Phrase phrase = new Phrase();
            phrase.term = words[i];
            phrase.occurrences = 1;
            phrases.Add(phrase);
        }
        Sphere();
    }
}