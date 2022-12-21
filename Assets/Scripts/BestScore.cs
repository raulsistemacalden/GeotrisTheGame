using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    private static int bestScore;

    private ScoringSystemManager score;

    public Text txtScore;

    public PlayFabScore scores;

    private void Start()
    {
        score = GameObject.Find("ScoringSystemManager").GetComponent<ScoringSystemManager>();
        bestScore= PlayerPrefs.GetInt("highscore", bestScore);
        SetBestScore();
        scores.SubmitScore(score.GetScore());
        StartCoroutine(ShowLeaderboard());
    }
    IEnumerator ShowLeaderboard() {
        yield return new WaitForSeconds(1);
        scores.RequestLeaderboard();
    }
    private void SetBestScore() {
        if (score.GetScore() > bestScore) {
            bestScore = score.GetScore();
            
        }

        txtScore.text = "Best score: " + bestScore;
        PlayerPrefs.SetInt("highscore", bestScore);
    }
}
