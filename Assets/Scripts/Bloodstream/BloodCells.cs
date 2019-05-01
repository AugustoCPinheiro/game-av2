using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCells : MonoBehaviour
{
    
   
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< transform.childCount; i++){
            transform.GetChild(i).transform.Translate(new Vector3(Random.Range(-14f, 12f), Random.Range(10f, 12.3f), 0));
        }
    }
    
    void Update(){
        
      
        if(transform.childCount == 0){
            Destroy(this.gameObject);
        }
    }
}
