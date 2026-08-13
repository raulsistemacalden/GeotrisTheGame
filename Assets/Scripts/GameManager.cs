using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public LevelScriptableObject[] levelStats;
    private int level;
    
    public string playerName;
    
    public enum State{
        Play,
        Pause,
        Stop
    }

    private State gameState;

    
    void Awake(){
        if(_instance!=null && _instance!=this){
            Destroy(gameObject);
            return;
        }
        _instance=this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        gameState = State.Pause;

    }
    public void Play(){
        gameState = State.Play;
    }
    public void Pause(){
        gameState = State.Pause;
    }

    public void Stop(){
        gameState = State.Stop;
    }

    public State GetState(){
        return gameState;
    }

    

    // total number of playable levels (defensive: never exceed the wired array)
    public int TotalLevels(){
        return levelStats != null ? levelStats.Length : 0;
    }

    public void UpdateLevel(){
        level++;
    }
    public int GetLevel(){
        return level;
    }

    //This method calls the level loader and passes it the scriptable object for that level.
    public void ChargeLevel(){
        // The player finished the last level -> submit score and go to the final scene.
        if(level > TotalLevels() - 1){
            GameObject pfObj = GameObject.Find("PlayFabScore");
            if(pfObj != null){
                PlayFabScore pFScore = pfObj.GetComponent<PlayFabScore>();
                if(pFScore != null)
                    pFScore.SubmitScore(ScoringSystemManager._instance.GetScore());
            }
            // Show an ad before leaving the run, then load the final scene.
            if(AdsManager._instance != null)
                AdsManager._instance.ShowInterstitial();
            SceneManager.LoadScene(3);
            return; // avoid indexing levelStats out of range
        }
        SetInitialValues(levelStats[level]);
    }
    /*  this method loads the values ​​of the level using scriptableobjects
        sets the speed of the level.
        sets the final score of the level.
        sets the number of pieces of the level.
        sets the number of powers of the level.
        Clear all the pieces from the previous level.
        activates the transition effect of the current level.
     */
    void SetInitialValues(LevelScriptableObject level){
        SpeedManager._instance.RecalculateSpeed(level.initialVelocity);
        ScoringSystemManager._instance.SetFinalScoreValue(level.finalScore);
        GeneratorManager._instance.UpdateNumberOfPieces(level.numberOfPieces);
        GeneratorManager._instance.UpdateNumberOfPowers(level.numberOfPowers);
        GeneratorManager._instance.RemoveAllPieces();
        GameObject.FindObjectOfType<ListOfDropPieces>().RemoveAllPieces();
        HudManager._instance.ActivateTransition();
    }

    

    
}
