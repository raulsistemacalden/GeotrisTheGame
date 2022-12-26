using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    private ListOfDropPieces list;
    private Transform father;
    private GameObject[] pieces;
    private ScoringSystemManager score;    
    //save current speed
    private float currentSpeed;
    [SerializeField]
    private GameObject soldier;
    private void Start(){
        father=GameObject.Find("DropPieces").GetComponent<Transform>();
        list = father.GetComponent<ListOfDropPieces>();
        pieces = GeneratorManager._instance.pieces;
        score = GameObject.Find("ScoringSystemManager").GetComponent<ScoringSystemManager>();  
        
        
    }
    //this power removes all the pieces from the box
    private void Power1(){
        list.RemoveAllPieces();
                
    }
    //This power removes all pieces that are of the same type from the box.
    private void Power2(string name){
        for(int i=father.childCount-1;i>-1;i--){
            if(father.GetChild(i).name == name){
                Destroy(father.GetChild(i).gameObject);
                list.listOfDropPieces.RemoveAt(i);
                
            }
        }
        
    }
    //This power causes the value of the score multiplier to be 2
    private void Power3(){
        StartCoroutine("MultiplyScore");
        
    }
    //This power reduces the movement speed of the pieces
    private void Power4(){
        currentSpeed = SpeedManager._instance.speed;
        StartCoroutine("ChangeVelocity");
    }
    //This power activates the soldier who shoots projectiles
    private void Power5(){
        StartCoroutine(ActivateSoldier());
    }

    IEnumerator ActivateSoldier(){
        soldier.SetActive(true);
        yield return new WaitForSeconds(10);
        soldier.SetActive(false);
    }

    private string RandomPiece(){
        string name = pieces[Random.Range(0,GeneratorManager._instance.GetNumberOfPieces())].name + "(Clone)";
        Debug.Log("la pieza que se elimina es la "+name);
        return name;
    }
    
    IEnumerator MultiplyScore(){
        score.Multiplier = 2;
        yield return new WaitForSeconds(10);
        score.Multiplier = 1;
    }

    IEnumerator ChangeVelocity()
    {
        SpeedManager._instance.speed = 2f;
        GeneratorManager._instance.SetDelay(0.8f);
        yield return new WaitForSeconds(15);
        GeneratorManager._instance.SetDelay(0.5f);
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
            case "PP5(Clone)":
                Power5();
                break;
            

        }
    }

}
