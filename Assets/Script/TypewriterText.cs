using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;
using UnityEditor.Experimental.GraphView;

public class TypewriterText : MonoBehaviour
{
    public float readingSpeed;
    public string preTextToRead;
    float speedHelper;
    public string textToRead;
    string texttoToUpdate;
    int i = 1;
    TextMeshPro textBox;
    public float textFade = 1f;
    AudioSource audio;
    public bool shouldDelete = false;
    public bool hasFirstDeathMessage;
    public string fistDeathMessage = "";
    public bool hasNumber = false;
    int number;
    public string afterNumber = "";

 
    // Start is called before the first frame update
    private void Start()
    {
        speedHelper = readingSpeed;
        textBox = FindObjectOfType<TextMeshPro>();
        audio = GetComponent<AudioSource>();
        number = 5294 - Blackboard.deathCounter * 7;
        if (hasNumber)
        {
            textToRead = textToRead + number.ToString() + afterNumber;
        }
        
        if (!Blackboard.shouldReadStory)
        {
            textBox.text = preTextToRead + textToRead;
            if (!hasFirstDeathMessage)
            {
                Destroy(gameObject);
            }
            else
            {
                preTextToRead = textToRead;
                textToRead = fistDeathMessage;
            }
            
        }
    }

    

    // Update is called once per frame
    void Update()
    {

        speedHelper -= Time.deltaTime;
        if (speedHelper <=0)
        {
            if (i <= textToRead.Length)
            {
                texttoToUpdate = preTextToRead + textToRead.Substring(0, i);
                textBox.text = texttoToUpdate;
                speedHelper = readingSpeed;
                i++;
                audio.pitch = Random.Range(0.8f, 1.2f);
                audio.Play();
            }
            else
            {
                textFade -= Time.deltaTime;
                if (textFade <= 0)
                {
                    if (shouldDelete)
                    {
                        textBox.text = "";
                    }
                    Destroy(gameObject);
                }
            }
            
            
        }
    }
}
