using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    string currentWorld = "Light";
    SpriteRenderer playerRenderer;
    WorldConfigurator[] objects;
    // Start is called before the first frame update
    void Start()
    {
        objects = FindObjectsOfType<WorldConfigurator>();
        playerRenderer = FindObjectOfType<PlayerController>().GetComponentInChildren<SpriteRenderer>();
        Transition();
        Cursor.visible = false;
    }

    private void Transition()
    {
        
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].ChangeWorlds(currentWorld);
        }
    }

    // Update is called once per frame
    public void WorldSwap()
    {
        
        if (currentWorld == "Light")
        {
            currentWorld = "Dark";
            playerRenderer.color = Color.black;
            Camera.main.backgroundColor = Color.white;
        }
        else
        {
            currentWorld = "Light";
            playerRenderer.color = Color.white;
            Camera.main.backgroundColor = Color.black;
        }
        Transition();
    }
}
