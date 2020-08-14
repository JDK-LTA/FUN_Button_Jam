using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float moveHorizontal = 0;
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
    Vector3 targetCamera;
    private Vector3 velocity;
    

    // Start is called before the first frame update
    void Start()
    {
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
            if (moveHorizontal == 0)
            {
                moveHorizontal = 1;
            }
            else
            {
                WMRef.WorldSwap();
                GameManager.Instance.ChangeWorld();
                moveHorizontal *= -1;
                anim.SetTrigger("Switch");
            }


        }
        if (Input.GetKeyDown("r"))
        {
            DIE();
        }

        if (Input.GetKeyDown("p"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKeyDown("o"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        transform.Translate(Vector3.right * moveHorizontal * Time.deltaTime * speed);
        CameraControlZoom();

    }

    private void CameraControlZoom()
    {
        if (exitedZoomZone)
        {
            Vector3 playerCamerapos = transform.position - Vector3.forward * 10;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, originalZoom, Time.deltaTime * 3);
            if(Vector2.Distance(cam.transform.position, transform.position) >= 0.1f)
                cam.transform.position = Vector3.SmoothDamp(cam.transform.position, playerCamerapos, ref velocity, 0.5f);
            if (cam.orthographicSize > originalZoom && cam.orthographicSize - 0.1f <= originalZoom ||
               cam.orthographicSize < originalZoom && cam.orthographicSize + 0.1f >= originalZoom && Vector2.Distance(cam.transform.position, transform.position)<= 0.1f)
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
        Blackboard.shouldReadStory = false;
        Blackboard.deathCounter++;
        Blackboard.firstDeath = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void NextLevel(string scene)
    {
        //SceneManager.LoadScene(scene);
        Blackboard.shouldReadStory = true;
        Blackboard.firstDeath = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<ZoomZone>())
        {
            exitedZoomZone = false;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, collision.GetComponent<ZoomZone>().targetZoom, Time.deltaTime*collision.GetComponent<ZoomZone>().transitionSpeed);
            if (collision.GetComponent<ZoomZone>().focusPoint != Vector3.zero)
            {
                targetCamera = collision.GetComponent<ZoomZone>().focusPoint;
                var bounds = new Bounds(transform.position, Vector3.zero);
                bounds.Encapsulate(transform.position);
                bounds.Encapsulate(targetCamera);
                cam.transform.position = Vector3.SmoothDamp(cam.transform.position, bounds.center, ref velocity, 0.5f);
            }
            
            
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

