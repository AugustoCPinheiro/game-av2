using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //private CharacterController _controller;
    
    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private float _jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        //_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move(){
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * _moveSpeed * horizontalInput);
        
        transform.Translate(Vector3.up * Time.deltaTime * _jumpForce * verticalInput);
        
        //if(Input.GetKeyDown(KeyCode.Space)){
          //  direction.y += _jumpForce;
        //}

        //velocity = transform.transform.TransformDirection(velocity);

        //_controller.Move(velocity * Time.deltaTime);
            
    }
}
