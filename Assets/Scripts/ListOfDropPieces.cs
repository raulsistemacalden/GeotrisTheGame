using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfDropPieces : MonoBehaviour
{
    public List<GameObject> listOfDropPieces=new List<GameObject>();
    
    public void AddDropPiece(GameObject piece) {
        listOfDropPieces.Add(piece);
        
    }

    public void RemoveDropPiece(){
        listOfDropPieces.RemoveAt(0);
        Destroy(transform.GetChild(0).gameObject);
    }
    
    
    public bool ControlToRemove(string nameObject) {
        if (listOfDropPieces[0].gameObject.name == nameObject)
            return true;
        return false;
    }

    public GameObject FirstPiece() {
        return listOfDropPieces[0].gameObject;
    }
    
    

    
    
}
