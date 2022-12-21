using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    private ListOfDropPieces list;
    private Transform father;
    private GameObject[] pieces;
    private ScoringSystemManager score;    
    private GeneratorManager generator;
    //save current speed
    private float currentSpeed;
    private void Start(){
        father=GameObject.Find("DropPieces").GetComponent<Transform>();
        list = father.GetComponent<ListOfDropPieces>();
        generator = GameObject.Find("GeneratorManager").GetComponent<GeneratorManager>();
        pieces = generator.pieces;
        score = GameObject.Find("ScoringSystemManager").GetComponent<ScoringSystemManager>();  
        
        
    }
    private void Power1(){
        for(int i=0;i<father.childCount;i++){
            Destroy(father.GetChild(i).gameObject);
        }
        list.listOfDropPieces.Clear();
        list.listOfDropPieces.TrimExcess();
            
    }
    private void Power2(string name){
        for(int i=father.childCount-1;i>-1;i--){
            if(father.GetChild(i).name == name){
                Destroy(father.GetChild(i).gameObject);
                list.listOfDropPieces.RemoveAt(i);
                
            }
        }
        
    }

    private void Power3(){
        StartCoroutine("MultiplyScore");
        
    }

    private void Power4(){
        currentSpeed = SpeedManager._instance.speed;
        StartCoroutine("ChangeVelocity");
    }

    private string RandomPiece(){
        return pieces[Random.Range(0,pieces.Length)].name + "(Clone)";
    }
    
    IEnumerator MultiplyScore(){
        score.Multiplier = 2;
        yield return new WaitForSeconds(10);
        score.Multiplier = 1;
    }

    IEnumerator ChangeVelocity()
    {
        SpeedManager._instance.speed = 2f;
        generator.SetDelay(0.8f);
        yield return new WaitForSeconds(15);
        generator.SetDelay(0.5f);
        SpeedManager._instance.speed= currentSpeed;
        PieceMovement[] pieces = GameObject.Find("Pieces").transform.GetComponentsInChildren<PieceMovement>();
        foreach (var childPiece in pieces) {
            childPiece.SetSpeed(currentSpeed);
        }
    }


    public void ActivePower(string name){
        switch(name){
            case "PP1(Clone)":
                Power1();
                break;
            case "PP2(Clone)":
                Power2(RandomPiece());
                break;
            case "PP3(Clone)":
                Power3();
                break;
            case "PP4(Clone)":
                Power4();
                break;
            

        }
    }

}
