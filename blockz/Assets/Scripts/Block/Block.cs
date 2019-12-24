using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockDestroyVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;
    GameSession gameSession;

    // state
    [SerializeField] int timesHit;

    public void Start()
    {
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>( );
        if (tag != "Unbreakable")
        {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        if (tag != "Unbreakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextSprite();
            }
        }
    }

    private void ShowNextSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("No damaged sprite" + gameObject.name);
        }
        
    }

    

    private void DestroyBlock()
    {
        BlockDestroySFX();
        level.BlockDestroyed();
        //gameStatus.gameSpeed = 0.5f;
        AddToScore();
        BlockDestroyParticle();
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

    private void BlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
    }

    private void BlockDestroyParticle()
    {
        GameObject particle = Instantiate(blockDestroyVFX, transform.position, transform.rotation);
        Destroy(particle, 1f);
    }
}