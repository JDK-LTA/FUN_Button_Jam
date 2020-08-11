using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float moveHorizontal = 1;
    public GameObject lworld;
    public GameObject dworld;
    SpriteRenderer playerRenderer;
    Camera cameraRef;
    bool isLightworld = true;


    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponentInChildren<SpriteRenderer>();
        ChangeWorld();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            moveHorizontal *= -1;
            isLightworld = !isLightworld;
            ChangeWorld();
        }

        transform.Translate(Vector3.right * moveHorizontal * Time.deltaTime * speed);

    }

    private void ChangeWorld()
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
    }

}

