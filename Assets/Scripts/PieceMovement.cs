using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    //Images of points when a piece is removed
    public GameObject[] pointsImages;
    //pieces speed
    private float speed;
    // transform to move the pieces
    private Transform trans;
    //reference to the scoring system
    private ScoringSystemManager scoring;
    //reference to the audio system 
    private AudioSystemManager _audio;
    //reference for the control of missing pieces
    private ListOfDropPieces dropPieces;
    //reference to the powers system
    private PowerManager power;
    //reference to the message system of the game's powers
    private MessageManager message;

    private void Start()
    {
        trans = GetComponent<Transform>();
        scoring = GameObject.Find("ScoringSystemManager").GetComponent<ScoringSystemManager>();
        _audio = GameObject.Find("AudioSystemManager").GetComponent<AudioSystemManager>();
        dropPieces = GameObject.Find("DropPieces").GetComponent<ListOfDropPieces>();
        power = GameObject.Find("PowerManager").GetComponent<PowerManager>();
        message = GameObject.Find("MessageManager").GetComponent<MessageManager>();
        speed = SpeedManager._instance.speed;
    }

    private void Update()
    {
        if(GameManager._instance.GetState() == GameManager.State.Play)
            trans.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void SetSpeed(float value) {
        speed = value;
    }
    public void OnMouseDown()
    {
        if (this.gameObject.tag == "Piece") {
            if (dropPieces.listOfDropPieces.Count > 0 && dropPieces.ControlToRemove(this.gameObject.name) ) {
                dropPieces.RemoveDropPiece();
                scoring.IncreaseScore(10);
                Instantiate(pointsImages[0],transform.position,Quaternion.identity);
                _audio.PlayFx();
                StartCoroutine(DestroyPiece());
            }
        }
        else if (this.gameObject.tag== "Power") {
            string name = this.gameObject.name;
            power.ActivePower(name);
            message.ActivateMessage(name);
            Instantiate(pointsImages[1], transform.position, Quaternion.identity);
            _audio.PlayFx();
            Destroy(this.gameObject);
        }
        
    }
    IEnumerator DestroyPiece()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    public void Destroy(){
        scoring.IncreaseScore(10);
        _audio.PlayFx();
        StartCoroutine(DestroyPiece());
    }


}
