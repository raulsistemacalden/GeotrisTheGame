using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCollider : MonoBehaviour
{
    public Collider2D coll1;
    
    // Start is called before the first frame update
    void Start()
    {
        coll1.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCollider() {
        Destroy(coll1);
        
    }
}
