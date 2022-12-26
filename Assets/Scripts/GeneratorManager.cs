using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    public static GeneratorManager _instance;
    public GameObject[] pieces; // game pieces
    private List<GameObject> piecesList = new List<GameObject>(); // list of generated pieces 
    private int numberOfPieces; // number of pieces of the current level
    public GameObject[] powers; // game powers
    private int numberOfPowers; // number of powers of the current level
    public Transform[] trans; // positions from which pieces are created
    public Transform dropPosition; // position from where the lost pieces fall

    // time and delay control the speed of creation of the pieces
    private float time;
    private float delay;

    // control over missing pieces
    private ListOfDropPieces dropPieces;    

    // parentOf pieces used to locate pieces within the pieces object in the hierarchy
    private Transform parentOfPieces;

    private void Awake(){
        if(_instance!=null && _instance!=this){
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        delay = 0.8f;
        dropPieces = GameObject.Find("DropPieces").GetComponent<ListOfDropPieces>();
        parentOfPieces = GameObject.Find("Pieces").GetComponent<Transform>();
    }

    private void Update()
    {
        // generation of game pieces or powers, if it is in Play state
        if (GameManager._instance.GetState() == GameManager.State.Play) {
            if (time < delay)
            {
                time += Time.deltaTime;
            }
            else
            {
                GeneratePieces();
                time = 0;
            }
        }        
    }

    //we generate a normal piece or a power
    private void GeneratePieces() {
        GameObject newPiece;
        if ((int)Random.Range(0, 30) == 5)
        {
            newPiece = CreateObj(powers[RandomPos(numberOfPowers)], trans[RandomPos(trans.Length)]);
            
        }
        else
        {
            newPiece = CreateObj(pieces[RandomPos(numberOfPieces)], trans[RandomPos(trans.Length)]);
        }
        piecesList.Add(newPiece);
        newPiece.transform.parent = parentOfPieces;
        
    }

    private GameObject CreateObj( Object obj, Transform trans){
        return Instantiate((GameObject)obj, trans.position, Quaternion.identity);
    }
    
    public void CreateDropPiece() {
        dropPosition.position = new Vector3(dropPosition.transform.position.x+Random.Range(-0.05f,0.05f),dropPosition.transform.position.y,dropPosition.transform.position.z);
        GameObject drop = CreateObj(pieces[RandomPos(numberOfPieces)], dropPosition);
        drop.GetComponent<PieceCollider>().ChangeCollider();
        Destroy(drop.GetComponent<PieceMovement>());
        drop.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        drop.transform.parent = dropPieces.transform;
        dropPieces.AddDropPiece(drop);
    }

    public void RemoveAllPieces(){
        if(piecesList!=null){
            foreach(GameObject piece in piecesList){
                Destroy(piece);
            }
            piecesList.Clear();
        }
    }

    // Esto se tiene que modificar, cuanto se agregue otra pieza
    private int RandomPos(int elements){
        return (int) Random.Range(0, elements);
    }

    public void SetDelay(float value) {
        delay = value;
    }

    public void UpdateNumberOfPowers(int newNumber){
        numberOfPowers = newNumber;
    }
    public int GetNumberOfPowers(){
        return numberOfPowers;
    }
    public void UpdateNumberOfPieces(int newNumber){
        numberOfPieces = newNumber;
    }
    public int GetNumberOfPieces(){
        return numberOfPowers;
    }


}
