﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterText : MonoBehaviour
{
    public float readingSpeed;
    float speedHelper;
    public string textToRead;
    string texttoToUpdate;
    int i = 0;
    TextMeshProUGUI textBox;
    float textFade = 1f;
    AudioSource audio;
 
    // Start is called before the first frame update
    private void Start()
    {
        speedHelper = readingSpeed;
        textBox = FindObjectOfType<TextMeshProUGUI>();
        audio = GetComponent<AudioSource>();
    }

    

    // Update is called once per frame
    void Update()
    {
        speedHelper -= Time.deltaTime;
        if (speedHelper <=0)
        {
            if (i <= textToRead.Length)
            {
                texttoToUpdate = textToRead.Substring(0, i);
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
                    textBox.text = "";
                    Destroy(gameObject);
                }
            }
            
            
        }
    }
}
