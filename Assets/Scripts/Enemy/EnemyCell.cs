using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCell : EnemyAi
{
    // Start is called before the first frame update
  void Start(){
      base.Start();
      _lifes = 2;
      _speed = 1f;
  }
    
    protected override void Move(){
    transform.Translate(Vector3.down * _speed * Time.deltaTime * gameManager.DificultyMultiplier);
    //Debug.Log(gameManager.DificultyMultiplier);
        if(transform.position.y < -10f)
        {
            float xPosition = Random.Range(-8f, 8f);
          transform.position = new Vector3(xPosition, transform.position.y * -1, 0);
        Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        base.Update();

    }

    void OnTriggerEnter2D(Collider2D other){
        base.OnTriggerEnter2D(other);
        
    }
}
