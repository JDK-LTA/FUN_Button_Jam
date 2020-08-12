using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldConfigurator : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool isVisibleWhenDeactivated;
    public bool shouldHaveCollision;
    public Color ActiveColor;
    public Color UnactiveColor;
    SpriteRenderer sprtRend;
    Collider2D fkcme;
    public enum Worlds
    {
        Light,
        Dark
    };
    public Worlds World;

    private void Awake()
    {
        sprtRend = GetComponent<SpriteRenderer>();
        fkcme = GetComponent<BoxCollider2D>();
        if (World.ToString() == "Light")
        {
            sprtRend.color = ActiveColor;
        }
        else
        {
            sprtRend.color = UnactiveColor;
        }
    }

    public void ChangeWorlds(string ActiveWorld)
    {
        if (ActiveWorld == World.ToString())
        {
            fkcme.enabled = true;
            sprtRend.enabled = true;
            sprtRend.color = ActiveColor;
        }
        else
        {
            if (shouldHaveCollision)
            {

            }
            else
            {
                fkcme.enabled = false;
            }          
            if (isVisibleWhenDeactivated)
            {
                sprtRend.color = UnactiveColor;
            }
            else
            {
                sprtRend.enabled = false;
            }
        }
    }

}
