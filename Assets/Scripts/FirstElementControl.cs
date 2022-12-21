using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstElementControl : MonoBehaviour
{
    private ListOfDropPieces list;
    private CurrentPiece piece;
    void Start()
    {
        list = GetComponent<ListOfDropPieces>();
        piece = GameObject.Find("Piece").GetComponent<CurrentPiece>();
    }

    // Update is called once per frame
    void Update()
    {
        if(list.listOfDropPieces.Count>0){
            piece.GetComponent<Image>().enabled=true;
            piece.ChagePiece(list.FirstPiece());
            
        }
        else{
            piece.GetComponent<Image>().enabled=false;            
        }
    }
}
