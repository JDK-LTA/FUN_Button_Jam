﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float moveHorizontal = 1;
    //public GameObject lworld;
    //public GameObject dworld;
    SpriteRenderer playerRenderer;
    Camera cameraRef;
    bool isLightworld = true;
    WorldManager WMRef;
    Animator anim;
    Camera cam;
    float originalZoom;
    bool exitedZoomZone;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        playerRenderer = GetComponentInChildren<SpriteRenderer>();
        WMRef = FindObjectOfType<WorldManager>();
        anim = transform.GetComponentInChildren<Animator>();

        cam = Camera.main;
        originalZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                WMRef.WorldSwap();
                GameManager.Instance.ChangeWorld();
                moveHorizontal *= -1;
                anim.SetTrigger("Switch");
            }


        }

        transform.Translate(Vector3.right * moveHorizontal * Time.deltaTime * speed);
        CameraControlZoom();

    }

    private void CameraControlZoom()
    {
        if (exitedZoomZone)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, originalZoom, Time.deltaTime * 3);
            if (cam.orthographicSize > originalZoom && cam.orthographicSize - 0.1f <= originalZoom ||
               cam.orthographicSize < originalZoom && cam.orthographicSize + 0.1f >= originalZoom)
            {
                exitedZoomZone = false;
            }
        }
    }

    /*private void ChangeWorld()
    {
         
        if (isLightworld)
        {
            dworld.SetActive(false);
            lworld.SetActive(true);
            playerRenderer.color = Color.white;
            Camera.main.backgroundColor = Color.black;
        }
        else
        {
            dworld.SetActive(true);
            lworld.SetActive(false);
            playerRenderer.color = Color.black;
            Camera.main.backgroundColor = Color.white;
        }
    }*/

    public void DIE()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<ZoomZone>())
        {
            exitedZoomZone = false;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, collision.GetComponent<ZoomZone>().targetZoom, Time.deltaTime*collision.GetComponent<ZoomZone>().transitionSpeed);
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ZoomZone>())
        {
            exitedZoomZone = true;
        }
    }

}

