using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    
    private float posX;    
    private Transform tf;
    private Vector3 pos;
    // Update is called once per frame
    void Start(){
        tf= transform;
    }
    void Update()
    {
          posX = Camera.main.ScreenPointToRay(Input.mousePosition).origin.x;
          pos = tf.position;
          transform.position = new Vector3(Mathf.Clamp(posX, -2, 0.77f),pos.y,pos.z);
          
    }
}
