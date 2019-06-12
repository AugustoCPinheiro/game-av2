using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameOver = true;

    private UIManager _uiManager;

    [SerializeField]
    private GameObject boss;

    private int _score;

    public static int endScore;
    
    [SerializeField]
    private float _dificultyTimer = 4f;

    private float _nextDificultyUpdate;

    public bool shouldSpawn = true;
    private SpawnManager spawnManager; 
    
    [SerializeField]
    private float _dificultyMultiplier = 0.5f;
    private Player _player;

    private bool bossUnleashed = false;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _player = GameObject.Find("Player").GetComponent<Player>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _nextDificultyUpdate = Time.time + _dificultyTimer;
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        if(_score >= 200){
           UnleasheTheBoss();
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
        shouldSpawn = false;   
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
        endScore = _score;
    }
    public void UpdatePlayerScore(int points){
        _score += points;
        _uiManager.UpdateScore(_score); 
    }

    public void BossDefeated(){
        _uiManager.SetupUIEndWin();
        _player.enabled = false;
        EndGame();
    }

    private void UnleasheTheBoss(){       
        if(!bossUnleashed){
        Instantiate(boss, new Vector3(0,15f,0), Quaternion.identity);        
        bossUnleashed = true;
       
        }else{

        }
    }

    public float DificultyMultiplier { get => _dificultyMultiplier; }
    }

   
