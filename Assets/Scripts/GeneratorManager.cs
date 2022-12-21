using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    public GameObject[] pieces;
    public GameObject[] powers;
    public Transform[] trans;
    public Transform dropPosition;

    private float time;
    private float delay;

    private ListOfDropPieces dropPieces;

    

    private Transform parentOfPieces;

    private void Start()
    {
        delay = 1f;
        dropPieces = GameObject.Find("DropPieces").GetComponent<ListOfDropPieces>();
        parentOfPieces = GameObject.Find("Pieces").GetComponent<Transform>();
    }

    private void Update()
    {
        if (GameManager._instance.GetState() == GameManager.State.Play) {
            if (time < delay)
            {
                time += Time.deltaTime;
            }
            else
            {
                GeneratePieces();
            }

        }
        
    }

    //we generate a normal piece or a power
    private void GeneratePieces() {
        GameObject newPiece;
        if ((int)Random.Range(0, 40) == 30)
        {
            newPiece = CreatePower(powers[RandomNumberOfPower()], trans[RandomNumber()]);
        }
        else
        {
            newPiece = CreatePiece(pieces[RandomNumberOfPieces()], trans[RandomNumber()]);
        }
        newPiece.transform.parent = parentOfPieces;
        time = 0;
    }
    private GameObject CreatePiece( GameObject piece, Transform trans) {
        return Instantiate(piece, trans.position, Quaternion.identity);
    }
    
    private GameObject CreatePower( GameObject power, Transform trans) {
        return Instantiate(power, trans.position, Quaternion.identity);
    }

    public void CreateDropPiece() {
        GameObject drop = CreatePiece(pieces[RandomNumberOfPieces()], dropPosition);
        drop.GetComponent<PieceCollider>().ChangeCollider();
        Destroy(drop.GetComponent<PieceMovement>());
        drop.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        drop.transform.parent = dropPieces.transform;
        dropPieces.AddDropPiece(drop);
    }

    // Esto se tiene que modificar, cuanto se agregue otra pieza
    private int RandomNumber() {
        return (int)Random.Range(0, 3);
    }
    private int RandomNumberOfPieces(){
        return (int)Random.Range(0,pieces.Length);
    }

    private int RandomNumberOfPower(){
        return (int)Random.Range(0,powers.Length);
    }

    public void SetDelay(float value) {
        delay = value;
    }


}
