using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceFX : MonoBehaviour
{
    public GameObject[] fx1;
    

    public void ActivateFX1(Vector3 position, int number){
        GameObject fx1Piece = Instantiate(fx1[number], position, Quaternion.identity);
        Destroy(fx1Piece,1);
    }

    
}
