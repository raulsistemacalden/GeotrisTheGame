using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    private GeneratorManager generator;
    private int dropPiecesCount;
    

    private void Start()
    {
        generator = GameObject.Find("GeneratorManager").GetComponent<GeneratorManager>();
         
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Piece") {
            Destroy(other.gameObject);
            if (dropPiecesCount < 3)
            {
                dropPiecesCount++;
            }
            else {
                dropPiecesCount = 0;
                generator.CreateDropPiece();

            }

        }
        else if(other.tag == "Power"){
            Destroy(other.gameObject);            
        }
    }

    
}
