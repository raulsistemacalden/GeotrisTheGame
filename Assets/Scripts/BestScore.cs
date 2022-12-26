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
        scores.SubmitScore(ScoringSystemManager._instance.GetScore());
        bestScore= PlayerPrefs.GetInt("HighScore", bestScore);
        SetBestScore();
        StartCoroutine(ShowLeaderboard());
    }
    IEnumerator ShowLeaderboard() {
        yield return new WaitForSeconds(1);
        scores.RequestLeaderboard();
    }
    private void SetBestScore() {
        if (ScoringSystemManager._instance.GetScore() > bestScore) {
            bestScore = ScoringSystemManager._instance.GetScore();
            
        }

        txtScore.text = "Best score: " + bestScore;
        PlayerPrefs.SetInt("highscore", bestScore);
    }
}
