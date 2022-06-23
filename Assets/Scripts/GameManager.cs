using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //game manager handles scene management
    //singleton format
    public static GameManager _instance;

    //dont destroy the game manager unless theres a duplicate
    void Awake() {
        if(_instance == null){
            _instance = this;
            DontDestroyOnLoad(_instance);
        } else {
            Destroy(gameObject);
        }
    }

    void Update() {
        
    }

    public void unpause(){
        Time.timeScale = 1;
    }

    public void quitGame(){

        //console log
        Debug.Log("Quit Game");

        //closes app
        Application.Quit();
    }
} 