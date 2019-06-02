using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    private float speed = 5.0f;
    private Player player;
    
    private Rigidbody2D rigidBody;
    private Vector2 moveDirection;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
        if(player == null){
            Destroy(this.gameObject);
        }
        moveDirection = (player.transform.position - transform.position).normalized * speed;
        rigidBody.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    void Update(){
        Vector3 position = this.transform.position;
        if(position.y < -7.9f || position.x > 12.4f || position.x < -12.4f){
            Destroy(this.gameObject);
        }
    }
 
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag.Equals("Player")){
            player.Damage();

            Destroy(this.gameObject);
        }
    }
    

    
}
