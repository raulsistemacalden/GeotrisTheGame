using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    
    private int dropPiecesCount;
    
    public void DestroyPiece(GameObject other){
        if (dropPiecesCount < 2)
            dropPiecesCount++;
        else {
            dropPiecesCount = 0;
            GeneratorManager._instance.CreateDropPiece();
        }
        Destroy(other);
    }
     
}
