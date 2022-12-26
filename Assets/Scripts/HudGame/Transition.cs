using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Transition : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tMesh;
    private string levelName;
    
    public void Activate(){
        StartCoroutine(StartGame());
    }
    IEnumerator StartGame() {
        GameManager._instance.Pause();
        tMesh = GetComponentInChildren<TextMeshProUGUI>();
        levelName = "LEVEL " + (GameManager._instance.GetLevel()+1).ToString();
        tMesh.text = levelName;
        yield return new WaitForSeconds(5);
        GameManager._instance.Play();
        AudioSystemManager audio = GameObject.Find("AudioSystemManager").GetComponent<AudioSystemManager>();
        audio.PlayMusic();
        gameObject.SetActive(false);
    }

    
}
