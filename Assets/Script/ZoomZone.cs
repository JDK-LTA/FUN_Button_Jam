using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomZone : MonoBehaviour
{
    public float targetZoom, transitionSpeed;
    public Transform point;
    public Vector3 focusPoint;
    private void Start()
    {
        if(point != null)
        {
            focusPoint = point.position;
        }
            
    }
}
