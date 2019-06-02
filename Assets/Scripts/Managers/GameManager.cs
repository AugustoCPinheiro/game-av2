using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameOver = true;

    private UIManager _uiManager;

    
   
    [SerializeField]
    private GameObject _playerPrefab;

    private int _score;
    
    [SerializeField]
    private float _dificultyTimer = 4f;

    private float _nextDificultyUpdate;
    private SpawnManager spawnManager; 
    
    [SerializeField]
    private float _dificultyMultiplier = 0.5f;
    private Player _player;

    private bool bossUnleashed = false;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _nextDificultyUpdate = Time.time + _dificultyTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(_score >= 400){
            EndGame();
        }

        if(Time.time > _nextDificultyUpdate){
            _dificultyMultiplier += 0.1f;
            _nextDificultyUpdate = Time.time + _dificultyTimer;
        }
        if (gameOver)
       {
            gameOver = !gameOver;
           // _uiManager.SetupUIStart();
    //        Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);

            spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
            StartCoroutine(spawnManager.SpawnEnemy());
        }
    }
    

    public void EndGame(){      
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
    }
    public void UpdatePlayerScore(int points){
        _score += points;
        _uiManager.UpdateScore(_score); 
    }

    private void unleasheTheBoss(){
        bossUnleashed = true;
        
    }

    public float DificultyMultiplier { get => _dificultyMultiplier; }
    }

   
