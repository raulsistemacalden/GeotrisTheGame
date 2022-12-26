using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    [SerializeField]private GameObject laser;
    private float delay;
    private float time;
    private Vector3 pos1;
    private Vector3 pos2;

    
    

    void Start(){
        delay = 0.5f;   
        
    }
    void Update()
    {
        if(time<delay){
            time += Time.deltaTime;
        }
        else{
            pos1 = transform.Find("pos1").position;
            pos2 = transform.Find("pos2").position;
            GameObject laser1 = Instantiate(laser);
            GameObject laser2 = Instantiate(laser);
            laser1.transform.position = pos1;
            laser2.transform.position = pos2;
            laser1.transform.Rotate(new Vector3(0,0,90));
            laser2.transform.Rotate(new Vector3(0,0,90));
            laser1.GetComponent<Laser>().shot = true;
            laser2.GetComponent<Laser>().shot = true;
            time = 0;
        }    
    }
}
