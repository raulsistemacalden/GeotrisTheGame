using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPiece : MonoBehaviour
{
    public Sprite[] pieces;
    private Image image;

    private ListOfDropPieces listOfPieces;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    

    public void ChagePiece(GameObject nameOfPiece) {
        string name = nameOfPiece.name;
        switch (name) {
            case "P1(Clone)":
                image.sprite = pieces[0];
                break;
            case "P2(Clone)":
                image.sprite = pieces[1];
                break;
            case "P3(Clone)":
                image.sprite = pieces[2];
                break;
            case "P4(Clone)":
                image.sprite = pieces[3];
                break;
            case "P5(Clone)":
                image.sprite = pieces[4];
                break;
            case "P6(Clone)":
                image.sprite = pieces[5];
                break;
            case "P7(Clone)":
                image.sprite = pieces[6];
                break;
            case "P8(Clone)":
                image.sprite = pieces[7];
                break;
            case "P9(Clone)":
                image.sprite = pieces[8];
                break;


        }
        
    }

}
