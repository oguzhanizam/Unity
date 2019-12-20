using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;
    

    //cached reference
    SceneLoader sceneLoader;
    // GameStatus gameStatus;

    
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>( );
        // gameStatus = FindObjectOfType<GameStatus>( );
    }
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        /*if (breakableBlocks == 5)
        {
            gameStatus.gameSpeed = 1.5f;
        }*/
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene( );
        }
    }
}