using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAnimation : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.OnWorldChanging += Butt;
    }

    void Butt()
    {
        GetComponent<Animator>().SetTrigger("Press");
    }
}
