using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockParticleVFX;
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    Level level;
    Ball ballObject;

    // state variables
    [SerializeField] int timesHit;

    private void Start()
    {
        CountBreakableBlocks();
        ballObject = FindObjectOfType<Ball>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( tag == "Breakable")
        {
            HandleBlock();
        }
    }

    private void HandleBlock()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlockEvent();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null){
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Missing sprite");
        }
        
        /* for(int spriteIndex = 0; spriteIndex < hitSprites.Length; spriteIndex++){
           GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } */
    }

    private void DestroyBlockEvent()
    {
        BlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerParticleVFX();
        // AddMoreBalls();
    }

    private void BlockDestroySFX()
    {
        FindObjectOfType<GameSession>().addToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerParticleVFX(){
        GameObject blockParticle = Instantiate(blockParticleVFX, transform.position, transform.rotation);
        Destroy(blockParticle, 1f);
    }

    /* private void AddMoreBalls(){
        ballObject = Instantiate(ballObject,transform.position,transform.rotation);
        Destroy(ballObject, 1f);
    } */
}
