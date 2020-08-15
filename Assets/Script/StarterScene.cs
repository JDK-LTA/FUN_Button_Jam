using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StarterScene : MonoBehaviour
{

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameManager.Instance.ChangeWorld();
            GetComponent<DelayScript>().enabled = true;
            
        }
    }
}
