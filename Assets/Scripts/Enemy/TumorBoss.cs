﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumorBoss : EnemyBoss
{
    private float timeToMove = 2.0f;
    private float moveDirection;

    
    
    
    void Start()
    {
        cooldown = 1.5f;
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(MoveChange());
        StartCoroutine(ShootCoroutine());
        _lifes = 10;
    }

    private void FixedUpdate() {
    Move();    
    }
    
    protected override void Move(){
        if (transform.position.x > 12.4f){
           moveDirection = -1;
        }
        if (transform.position.x < -12.4f)
        {
                       moveDirection = 1;
        }
        transform.Translate(Vector3.right*_speed*moveDirection*Time.deltaTime);
    }

    protected override void Shoot(){
    Instantiate(bullet, transform.position, Quaternion.identity);
       
    }
    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator ShootCoroutine(){
        while(true){
            yield return new WaitForSeconds(cooldown);
            Shoot();
        }
    }
    IEnumerator MoveChange(){
        while(true){
            switch(Random.Range(0, 2)){
                case 0:
                    moveDirection = 1;
                    break;
                case 1:
                    moveDirection = -1;
                    break;
            }
            yield return new WaitForSeconds(cooldown);
        }
    }
}
