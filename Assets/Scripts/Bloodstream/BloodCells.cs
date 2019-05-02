using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCells : MonoBehaviour
{
    
   
    // Start is called before the first frame update
 
    
    void Update(){
        
      
        if(transform.childCount == 0){
            Destroy(this.gameObject);
        }
    }
}
