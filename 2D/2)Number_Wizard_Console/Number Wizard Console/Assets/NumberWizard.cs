using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int max; // integer: using with numbers
    int min;
    int guess;
    
    /*// bool isAlive = false; // booelan(bool): using with true/false
    // float speed = 3.6f; // float: using with decimal numbers */
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame ()
    {
        max = 1000;
        min = 1;
        guess = 500;
        
        string name = "Oğuzhan"; // string: using with texts

        Debug.Log("Welcome to number wizard, " + name + ".");
        Debug.Log("Pick a number.");
        Debug.Log("The highest number is: " + max);
        Debug.Log("The lowest number is: " + min);
        Debug.Log("Tell me if your number is higher or lower than " + guess);
        Debug.Log("Push Up Arrow: Higher, Push Down Arrow: Lower, Push Enter: Correct");
        max = max + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            min = guess;
            NextGuess();
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            max = guess;
            NextGuess();
        } else if(Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("I won! I'm a genius!");
            StartGame();
        }
    }

    void NextGuess()
    {
        guess = (max + min) / 2;
        Debug.Log("Is it higher or lower than " + guess + "?");
    }
}
