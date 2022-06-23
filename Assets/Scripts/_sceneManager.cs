using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//_sceneManager manages menus and loading scenes
public class _sceneManager : MonoBehaviour
{
    //variables
    //menu variables
    public GameObject mainMenuObj, pauseMenuObj, settingsMenuObj;

    //pause state variable
    private bool isPaused = false;

    //Start is called before first frame is loaded
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        getPauseInput();
    }

    //scene management methods
    // call to change scene to desired scene, set desired scene with public var in the editor
    public void sceneManager(int sceneIndex){
        SceneManager.LoadScene(sceneIndex);
    } 

    public void reloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

        //pause menu methods
    public void getPauseInput(){
        if (Input.GetButtonDown("Cancel") && SceneManager.GetActiveScene().buildIndex != 0){
            if(!isPaused){
                pauseMenu();
            } else {
                resumeGame();
            }
        }
    }

    public void pauseMenu() {

        //pause time
        isPaused = true;
        Time.timeScale = 0;

        //enable pause menu visibility
        pauseMenuObj.SetActive(true);
    }

    public void resumeGame(){
            isPaused = false;
            Time.timeScale = 1;
            pauseMenuObj.SetActive(false);
        
    }

    public void setMainMenuActive(){
        mainMenuObj.SetActive(true);
    }

    public void setMainMenuDisabled(){
        mainMenuObj.SetActive(false);
    }
}
