using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Piece") {
            GameManager._instance.Stop();
            gameOverPanel.SetActive(true);
            // Anuncio intersticial al perder (no bloquea si no hay ads disponibles).
            if (AdsManager._instance != null)
                AdsManager._instance.ShowInterstitial();
        }
    }
}
