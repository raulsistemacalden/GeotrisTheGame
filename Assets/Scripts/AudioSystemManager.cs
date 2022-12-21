using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystemManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource fx;

    public void PlayMusic() {
        music.Play();
    }

    public void PlayFx() {
        fx.PlayOneShot(fx.clip);
    }
}
