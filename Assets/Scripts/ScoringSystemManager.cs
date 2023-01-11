using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystemManager : MonoBehaviour
{
    public static ScoringSystemManager _instance;
    public Text txtScore;
    public int Multiplier = 1;
    private int score;
    private int finalScoreValue;

    void Awake(){
        if(_instance!=null && _instance!=this){
            Destroy(gameObject);
            return;
        }
        _instance = this;
         
    }


    public void IncreaseScore(int value){
        score+=value*Multiplier;
        UpdateScore();
    }
    public void DecreaseScore(int value){
        score-=value;
        UpdateScore();
    }
    private void UpdateScore(){
        txtScore.text = "Score: "+score.ToString();

    }

    public int GetScore() {
        return score;
    }

    public void SetFinalScoreValue(int value){
        this.finalScoreValue = value;
    }

    void Update(){
        if(score>=GameManager._instance.levelStats[GameManager._instance.GetLevel()].finalScore){
            GameManager._instance.UpdateLevel();
            GameManager._instance.ChargeLevel();
            
        }
    }
}
