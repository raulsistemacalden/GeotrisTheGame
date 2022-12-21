using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundImages : MonoBehaviour
{
    private const int delay= 10;
    private float time;
    
    private List<Sprite> backgroundImages;
    private int currentBackground;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if(backgroundImages!=null){
            if(time<delay)
                time += Time.deltaTime; 
            else{ 
                time=0;
                currentBackground = currentBackground<backgroundImages.Count-1? currentBackground+1:0;
                HudManager._instance.UpdatePanelImage(backgroundImages[currentBackground]);
                
            }
                        
            
        }
        else{
            backgroundImages = HudManager._instance.backgroundImages;
            
        }
    }
    
}
