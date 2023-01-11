using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public static HudManager _instance;
    
    public List<Sprite> backgroundImages;
    public Image panelImage;
    public GameObject transition;

    
    void Awake(){
        if(_instance!=null && _instance!=this){
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }
    

    public void UpdatePanelImage(Sprite newImage){
        panelImage.sprite= newImage;
    }

    public void ActivateTransition(){
        transition.SetActive(true);
        transition.GetComponent<Transition>().Activate();
    }
    
}
