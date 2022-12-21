using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public GameObject[] pointsImages;
    private float speed;
    private Transform trans;
    private ScoringSystemManager scoring;
    private AudioSystemManager audio;
    private ListOfDropPieces dropPieces;
    private PowerManager power;
    private MessageManager message;

    private void Start()
    {
        trans = GetComponent<Transform>();
        scoring = GameObject.Find("ScoringSystemManager").GetComponent<ScoringSystemManager>();
        audio = GameObject.Find("AudioSystemManager").GetComponent<AudioSystemManager>();
        dropPieces = GameObject.Find("DropPieces").GetComponent<ListOfDropPieces>();
        power = GameObject.Find("PowerManager").GetComponent<PowerManager>();
        message = GameObject.Find("MessageManager").GetComponent<MessageManager>();
        speed = SpeedManager._instance.speed;
    }

    private void Update()
    {
        trans.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void SetSpeed(float value) {
        speed = value;
    }
    public void OnMouseDown()
    {
        if (this.gameObject.tag == "Piece") {
            if (dropPieces.ControlToRemove(this.gameObject.name) && dropPieces.listOfDropPieces.Count > 0) {
                dropPieces.RemoveDropPiece();
                scoring.IncreaseScore(10);
                Instantiate(pointsImages[0],transform.position,Quaternion.identity);
                audio.PlayFx();
                StartCoroutine(DestroyPiece());
            }
        }
        else if (this.gameObject.tag== "Power") {
            string name = this.gameObject.name;
            power.ActivePower(name);
            message.ActivateMessage(name);
            Instantiate(pointsImages[1], transform.position, Quaternion.identity);
            audio.PlayFx();
            Destroy(this.gameObject);
        }
        
    }
    IEnumerator DestroyPiece()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("is here");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }


}
