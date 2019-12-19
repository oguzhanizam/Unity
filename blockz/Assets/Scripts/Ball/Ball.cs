using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Parametreler
    Vector2 paddleToBallVector;
    float xPush = 2f;
    float yPush = 10f;
    float unitWidth = 16f;
    float unitHeight = 10f;


    // Eşlemeler
    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballCollisionSounds;

    // cached component ref
    Rigidbody2D rb;
    AudioSource audioSource;
    Block block;

    // Durumlar
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        rb = GetComponent<Rigidbody2D>(); // cache ref component tanımlama
        audioSource = GetComponent<AudioSource>(); // cache ref component tanımlama
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            //rb.velocity = new Vector2(mouseWidthInScreenUnits, mouseHeightInScreenUnits);
            rb.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            //GetComponent<AudioSource>().Play();
            AudioClip clip = ballCollisionSounds[UnityEngine.Random.Range(0, ballCollisionSounds.Length)];
            audioSource.PlayOneShot(clip);
            //AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        }
    }
}
