using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public delegate void OnStart();
    public event OnStart OnWorldChanging;
    public event OnStart OnPlayerDeath;
    public event OnStart OnLevelEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
