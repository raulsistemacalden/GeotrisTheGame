using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    private RaycastHit2D hit;
    
    private ListOfDropPieces dropPieces;
    private CurrentPiece pieceImage;

    private GameObject piece;

    private ScoringSystemManager scoring;

    private PowerManager power;

    private MessageManager message;

    private AudioSystemManager audio;

    


    private void Start()
    {
        dropPieces = GameObject.Find("DropPieces").GetComponent<ListOfDropPieces>();
        pieceImage = GameObject.Find("Piece").GetComponent<CurrentPiece>(); 
        scoring = GameObject.Find("ScoringSystemManager").GetComponent<ScoringSystemManager>();
        power = GameObject.Find("PowerManager").GetComponent<PowerManager>();
        message = GameObject.Find("MessageManager").GetComponent<MessageManager>();
        audio = GameObject.Find("AudioSystemManager").GetComponent<AudioSystemManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray2D laserWithDirection = CreateRay();
            if (Physics2D.Raycast(laserWithDirection.origin, laserWithDirection.direction))
            {
                if(hit.collider.tag == "Piece"){
                    if (dropPieces.ControlToRemove(hit.collider.name) && dropPieces.listOfDropPieces.Count>0){
                        dropPieces.RemoveDropPiece();
                        scoring.IncreaseScore(10);
                        audio.PlayFx();
                        piece = hit.collider.gameObject;
                        StartCoroutine(DestroyPiece());
                        
                    
                    }
                }
                else if(hit.collider.tag == "Power"){
                    string name = hit.collider.name;
                    power.ActivePower(name);
                    message.ActivateMessage(name);
                    audio.PlayFx();
                    Destroy(hit.collider.gameObject);    
                }
                 
                
            }
        }
    }

    IEnumerator DestroyPiece(){
        piece.GetComponent<SpriteRenderer>().enabled=false;
        piece.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("is here");
        yield return new WaitForSeconds(0.5f);
        Destroy(piece);        
    }

    private Ray2D CreateRay() {
        Ray2D laser = new Ray2D(new Vector2(Input.mousePosition.x,Input.mousePosition.y), new Vector2(0, 0));
        return laser;
    }

    
}
