using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    
    private int dropPiecesCount;
    

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Piece") {
            Destroy(other.gameObject);
            if (dropPiecesCount < 2)
            {
                dropPiecesCount++;
            }
            else {
                dropPiecesCount = 0;
                GeneratorManager._instance.CreateDropPiece();

            }

        }
        else if(other.tag == "Power"){
            Destroy(other.gameObject);            
        }
    }

    
}
