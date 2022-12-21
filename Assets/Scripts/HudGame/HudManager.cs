using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public static HudManager _instance;
    
    public List<Sprite> backgroundImages;
    public Image panelImage;
    
    void Awake(){
        if(_instance!=null && _instance!=this){
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    public void UpdatePanelImage(Sprite newImage){
        panelImage.sprite= newImage;
    }
    
}
