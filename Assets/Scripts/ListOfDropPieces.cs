using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfDropPieces : MonoBehaviour
{
    public List<GameObject> listOfDropPieces=new List<GameObject>();
    
    public void AddDropPiece(GameObject piece) {
        listOfDropPieces.Add(piece);
        
    }

    //This method removes the first item from the list and also removes the object from the hierarchy.
    public void RemoveDropPiece(){
        listOfDropPieces.RemoveAt(0);
        Destroy(transform.GetChild(0).gameObject);
    }

    public void RemoveAllPieces(){
        foreach(GameObject piece in listOfDropPieces){
            Destroy(piece);
        }
        listOfDropPieces.Clear();
    }
        
    
    //method that returns true if the first object in the list matches the one that was clicked
    public bool ControlToRemove(string nameObject) {
        if (listOfDropPieces[0].gameObject.name == nameObject)
            return true;
        return false;
    }

    public GameObject FirstPiece() {
        return listOfDropPieces[0].gameObject;
    }
    
    

    
    
}
