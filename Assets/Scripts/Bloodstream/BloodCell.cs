using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCell : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.1f;
  
    void  Start() {
            transform.Translate(new Vector3(Random.Range(-14f, 12f), Random.Range(10f, 12.3f), 0));
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed);

        if(transform.position.y < -10f){
            Destroy(this.gameObject);
        }
    }
}
