using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    private static int bestScore;

    
    public Text txtScore;

    public PlayFabScore scores;

    private void Start()
    {
        bestScore= PlayerPrefs.GetInt("HighScore", bestScore);
        SetBestScore();        
        StartCoroutine(UpdateScore());
        StartCoroutine(ShowLeaderboard());
    }

    IEnumerator UpdateScore(){
        scores.SubmitScore(ScoringSystemManager._instance.GetScore());
        yield return new WaitForSeconds(1);
    }
    IEnumerator ShowLeaderboard() {
        scores.RequestLeaderboard();
        yield return new WaitForSeconds(1);        
    }
    private void SetBestScore() {
        if (ScoringSystemManager._instance.GetScore() > bestScore) {
            bestScore = ScoringSystemManager._instance.GetScore();
            
        }

        txtScore.text = "Best score: " + bestScore;
        PlayerPrefs.SetInt("highscore", bestScore);
    }
}
