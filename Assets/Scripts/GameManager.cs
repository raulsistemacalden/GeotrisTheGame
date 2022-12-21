using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public int level;
    public LevelScriptableObject[] levelStats;
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

    

    public void ChargeLevel(){
        switch(level){
            case 1:{
                SetInitialValues(levelStats[0]);
                break;
            }
            case 2:{
                SetInitialValues(levelStats[1]);
                break;
            }
            case 3:{
                SetInitialValues(levelStats[2]);
                break;
            }
        }
    }

    void SetInitialValues(LevelScriptableObject level){
        SpeedManager._instance.RecalculateSpeed(level.initialVelocity);
        ScoringSystemManager._instance.SetFinalScoreValue(level.finalScore);
    }
}
