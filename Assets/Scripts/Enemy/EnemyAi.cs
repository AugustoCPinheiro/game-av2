﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAi : MonoBehaviour
{
  [SerializeField]
    protected float _speed = 5.0f;
    [SerializeField]
    protected float _lifes;

    [SerializeField]
    protected GameObject[] _powerUpDrops;

    [SerializeField]
    protected GameObject _deathAnimation;

    protected UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
//        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    protected void Update()
    {
        Move();
    }

    protected abstract void Move();

    protected void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag.Equals("Laser")){
            _lifes--;
            Destroy(other.gameObject);
            if( _lifes == 0){
                if(other.transform.parent != null){
                    Destroy(other.transform.parent.gameObject);
                }
                Debug.Log("Laser kill");
         
                //Instantiate(_deathAnimation, transform.position, Quaternion.identity);
                GenerateDrop();
                Destroy(this.gameObject);
                _uiManager.UpdateScore(10);
            
            }

        }

        if(other.tag.Equals("Player")){
            Player player = other.GetComponent<Player>();
            
            if(player != null){
            player.Damage();
            }

            Destroy(this.gameObject);
//            Instantiate(_deathAnimation, transform.position, Quaternion.identity);
        }
    }

    private void GenerateDrop()
    {
        int random = Random.Range(1, 5);
        if (random == 1)
        {
            random = Random.Range(0, 3);
            Instantiate(_powerUpDrops[1], transform.position, Quaternion.identity);
        }
    }
}