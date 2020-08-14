using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnWorldChanging += LightSwitch;
    }

    void LightSwitch()
    {
        GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
    }
}
