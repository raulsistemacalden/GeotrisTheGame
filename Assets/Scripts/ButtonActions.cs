using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    public InputField _name;    
    private bool isPaused;
    public GameObject transitionPanel;
    

    

    public void ButtonStart() {

        SceneManager.LoadScene(2);
    }
    //scene load 2 (Game Scene)
    public void ButtonContinue() {
        SceneManager.LoadScene(2);
    }

    //method to start the game with the name entered, otherwise a name is entered it starts with 'unknow'
    //scene load 1 (Instructions scene)
    public void ButtonStartFirst() {
        GameManager._instance.playerName = _name.text!=""? _name.text : "Unknow";
        SceneManager.LoadScene(1);        
    }
    public void ButtonPause() {
        isPaused = !isPaused;
        if (isPaused) 
            GameManager._instance.Pause();
        else 
            GameManager._instance.Play();
    }


    //Exit to the game
    public void ButtonExit()
    {
        Application.Quit();
    }
    // start the game 
    // loading game levels
    //
    public void ButtonPlay() {
        GameManager._instance.ChargeLevel();
        HudManager._instance.ActivateTransition();
        Destroy(gameObject);
    }
    public void ButtonMainMenu()
    {
        GameManager._instance.Stop();
        SceneManager.LoadScene(0);
    }
}
