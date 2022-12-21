using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public GameObject message;
    public Text messageTxt;
    private string name;

    private void Start()
    {
        messageTxt = message.GetComponentInChildren<Text>();
    }
    public void ActivateMessage(string namePower) {
        name = namePower;
        StartCoroutine("MessageTime");
    }

    IEnumerator MessageTime() {
        switch (name)
        {
            case "PP1(Clone)":
                messageTxt.text = "Destroy all";
                break;
            case "PP2(Clone)":
                messageTxt.text = "Destroy color";
                break;
            case "PP3(Clone)":
                messageTxt.text = "Score X2";
                break;
            case "PP4(Clone)":
                messageTxt.text = "Change velocity";
                break;


        }
        message.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        message.SetActive(false);


    }
}
