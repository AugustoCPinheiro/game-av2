using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameOver = true;

    private UIManager _uiManager;
   
    [SerializeField]
    private GameObject _playerPrefab;
    
    [SerializeField]
    private float _dificultyTimer = 4f;

    private float _nextDificultyUpdate;
    
    [SerializeField]
    private float _dificultyMultiplier = 0.5f;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        //_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _nextDificultyUpdate = Time.time + _dificultyTimer;

    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time > _nextDificultyUpdate){
            _dificultyMultiplier += 0.1f;
            _nextDificultyUpdate = Time.time + _dificultyTimer;
        }
        if (gameOver && Input.GetKey(KeyCode.Space))
       {
            gameOver = !gameOver;
           // _uiManager.SetupUIStart();
    //        Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);

            SpawnManager spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
            StartCoroutine(spawnManager.SpawnEnemy());
        }
    }

    public float DificultyMultiplier { get => _dificultyMultiplier; }
    }

   
