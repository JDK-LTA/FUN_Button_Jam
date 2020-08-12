using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float moveHorizontal = 1;
    public GameObject lworld;
    public GameObject dworld;
    SpriteRenderer playerRenderer;
    Camera cameraRef;
    bool isLightworld = true;
    WorldManager WMRef;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        playerRenderer = GetComponentInChildren<SpriteRenderer>();
        WMRef = FindObjectOfType<WorldManager>();
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
                WMRef.WorldSwap();    //Perdon a quien estuviera con esto, estoy probando música.
                GameManager.Instance.ChangeWorld();
                moveHorizontal *= -1;
            }

           
        }

        transform.Translate(Vector3.right * moveHorizontal * Time.deltaTime * speed);

    }

    private void ChangeWorld()
    {
         //Lo comentado anterior es para poder ejecutar esto.
         // El jugador no se movía, he puesto aqui su control.
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

    public void DIE()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

