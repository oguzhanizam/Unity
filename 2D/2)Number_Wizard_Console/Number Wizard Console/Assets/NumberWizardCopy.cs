using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizardCopy : MonoBehaviour
{
    int max;
    int min;
    int guess;
    string name = "Oğuzhan";

    void Start(){
        StartGame();
    }

    void StartGame(){
        max = 1000;
        min = 1;
        guess = 500;

        Debug.Log("Hoşgeldin " + name + "!");
        Debug.Log("Bir sayı seç.");
        Debug.Log("Seçebileceğin maksimum sayı: " + max);
        Debug.Log("Seçebileceğin minimum sayı: " + min);
        Debug.Log("Tuttuğun sayı " + guess + "'den büyük veya küçükse söyle.");
        Debug.Log("Yukarı ok tuşu: Tahmini artır, Aşağı ok tuşu: Tahmini düşür, Enter tuşu: Doğru tahmin");
        max = max + 1;
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            min = guess;
            NextGuess();
        } else if(Input.GetKeyDown(KeyCode.DownArrow)){
            max = guess;
            NextGuess();
        } else if(Input.GetKeyDown(KeyCode.Return)){
            Debug.Log("Tuttuğun sayı: " + guess);
            StartGame();
        }
        
    }

    void NextGuess(){
        guess = (max + min) / 2;
        Debug.Log("Sayı " + guess + "'den büyük ya da küçük mü?");
    }
}
