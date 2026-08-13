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

    // --- feedback visual del marcador ---
    private Vector3 scoreBaseScale = Vector3.one;
    private Coroutine punchRoutine;

    void Start(){
        if(txtScore != null){
            Vector3 s = txtScore.transform.localScale;
            scoreBaseScale = (s == Vector3.zero) ? Vector3.one : s;
        }
    }

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
        if(txtScore == null) return;
        txtScore.text = "Score: "+score.ToString();
        if(punchRoutine != null) StopCoroutine(punchRoutine);
        punchRoutine = StartCoroutine(PunchScore());
    }

    // Pequeño "latido" del texto del marcador al cambiar el puntaje.
    private IEnumerator PunchScore(){
        Transform t = txtScore.transform;
        Vector3 big = scoreBaseScale * 1.15f;
        float dur = 0.08f, e = 0f;
        while(e < dur){ e += Time.unscaledDeltaTime; t.localScale = Vector3.Lerp(scoreBaseScale, big, e/dur); yield return null; }
        e = 0f;
        while(e < dur){ e += Time.unscaledDeltaTime; t.localScale = Vector3.Lerp(big, scoreBaseScale, e/dur); yield return null; }
        t.localScale = scoreBaseScale;
    }

    public int GetScore() {
        return score;
    }

    public void SetFinalScoreValue(int value){
        this.finalScoreValue = value;
    }

    void Update(){
        int lvl = GameManager._instance.GetLevel();
        LevelScriptableObject[] stats = GameManager._instance.levelStats;
        // Only evaluate progression while we are on a valid level index.
        if(stats != null && lvl >= 0 && lvl < stats.Length && score >= stats[lvl].finalScore){
            GameManager._instance.UpdateLevel();
            GameManager._instance.ChargeLevel();
        }
    }
}
