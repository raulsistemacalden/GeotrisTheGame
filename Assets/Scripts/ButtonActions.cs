using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    public InputField name;    
    private Ads ads;
    private bool isPaused;

    

    public void ButtonStart() {

        ads = GameObject.Find("Ads").GetComponent<Ads>();
        ads.ShowNormalVideo();
        SceneManager.LoadScene(2);
    }
    public void ButtonContinue() {
        SceneManager.LoadScene(2);
    }
    public void ButtonStartFirst() {
        GameManager._instance.playerName = name.text!=""?name.text:"Unknow";
        SceneManager.LoadScene(1);
    }
    public void ButtonPause() {
        isPaused = !isPaused;
        if (isPaused)
        {
            ads = GameObject.Find("Ads").GetComponent<Ads>();
            ads.ShowNormalVideo();
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }


    public void ButtonExit()
    {
        Application.Quit();
    }
    public void ButtonPlay() {
        GameManager._instance.Play();
        AudioSystemManager audio = GameObject.Find("AudioSystemManager").GetComponent<AudioSystemManager>();
        audio.PlayMusic();
        Destroy(gameObject);
    }
    public void ButtonMainMenu()
    {
        GameManager._instance.Stop();
        ads = GameObject.Find("Ads").GetComponent<Ads>();
        ads.ShowNormalVideo();
        SceneManager.LoadScene(0);
    }
}
