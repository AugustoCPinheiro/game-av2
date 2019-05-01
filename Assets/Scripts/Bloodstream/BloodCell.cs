using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCell : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.1f;
  

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed);

        if(transform.position.y < -10f){
            Destroy(this.gameObject);
        }
    }
}
