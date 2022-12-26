using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float speed;
    private float time;
    private float delay;

    public bool shot;

    void Start(){
        speed = 10; 
        delay = 2;
    }
    void Update(){
        if(shot)
            Move();
    }

    private void Move(){
        if(time<2){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            time += Time.deltaTime; 
        }
        else{
            Destroy(gameObject);
        }            
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Piece"){
            other.GetComponent<PieceMovement>().Destroy();
            
        }
    }
}
