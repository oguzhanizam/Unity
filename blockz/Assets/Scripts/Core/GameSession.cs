using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] public float gameSpeed = 1f;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] public float score = 0;
    [SerializeField] public int blackBlockPoint = 15;
    [SerializeField] public int redBlockPoint = 25;
    [SerializeField] public int greenBlockPoint = 50;

    [SerializeField] public bool isAutoplayEnable;

    Block block;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>( ).Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = score.ToString( );
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool isAutoPlay()
    {
        return isAutoplayEnable;
    }
}
