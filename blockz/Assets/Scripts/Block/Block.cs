using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //cached reference
    Level level;
    GameSession gameSession;

    public void Start()
    {
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>( );
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed( );
        //gameStatus.gameSpeed = 0.5f;
        AddToScore();
    }

    private void AddToScore()
    {
        if (this.tag == "Black Block")
        {
            gameSession.score += gameSession.blackBlockPoint;
        }
        if (this.tag == "Green Block")
        {
            gameSession.score += gameSession.greenBlockPoint;
        }
        if (this.tag == "Red Block")
        {
            gameSession.score += gameSession.redBlockPoint;
        }
    }
}