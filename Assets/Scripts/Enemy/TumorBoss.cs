using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumorBoss : EnemyBoss
{
    private float timeToMove = 2.0f;
    private float moveDirection;
    private GameManager gameManager;

    private float firstCooldown;
    
    
    
    void Start()
    {
        cooldown = 2f;
        firstCooldown = cooldown;
        player = GameObject.Find("Player").GetComponent<Player>();
       
        StartCoroutine(MoveChange());
        StartCoroutine(ShootCoroutine());
        _lifes = 12;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    private void FixedUpdate() {
        Move();  
        if (cooldown > 0.8f)
        {
            cooldown = firstCooldown - (gameManager.DificultyMultiplier/10); 
            Debug.Log(cooldown);
        }
    }
    
    protected override void Move(){
        if (transform.position.y > 9f)
        {
            transform.Translate(Vector3.up*2*-1*Time.deltaTime);
        }else{
        if (transform.position.x > 12.4f){
           moveDirection = -1;
        }
        if (transform.position.x < -12.4f)
        {
                       moveDirection = 1;
        }
        transform.Translate(Vector3.right*_speed*moveDirection*Time.deltaTime);
        }
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

    protected  void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Laser"))
        {
            Debug.Log("IF CERTo");
            _lifes--;
            Destroy(other.gameObject);
            if (_lifes == 0)
            {
                Destroy(this.gameObject);
                gameManager.BossDefeated();
            }
        }
    }   
}
