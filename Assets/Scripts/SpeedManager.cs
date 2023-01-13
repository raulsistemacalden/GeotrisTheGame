using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager _instance;
    public float speed;
    private const float delay = 10;
    private float time;
    
    void Awake(){
        if(_instance!=null & _instance!=null){
            Destroy(gameObject);
            return;
        } 
        _instance = this;
        
    }
    private void Start()
    {
        RecalculateSpeed(3);
          
    }

    private void Update(){
        if(time<delay){
            time+=Time.deltaTime;
        }
        else{
            time=0;
            speed+=0.1f;
        }
    }

    public void RecalculateSpeed(float speed){
        this.speed= speed;    
    }    


}
