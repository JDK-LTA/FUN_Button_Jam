using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBox : MonoBehaviour
{
    Vector3 pointA, pointB;
    public Transform pointAt, pointBt;
    Vector3 activePoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnWorldChanging += SwitchPoint;
        pointA = pointAt.position;
        pointB = pointBt.position;
        activePoint = pointA;
        
    }

    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, activePoint, Time.deltaTime * speed);
    }

    void SwitchPoint()
    {
        if(activePoint == pointA)
        activePoint = pointB;
        else
        {
            activePoint = pointA;
        }
    }
}
