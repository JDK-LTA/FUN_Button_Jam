using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypewriterStarter : MonoBehaviour
{
    TypewriterText textTostart;
    private void Start()
    {
        textTostart = GetComponent<TypewriterText>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            textTostart.enabled = true;
            this.enabled = false;
        }
    }
}
