using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyShipPrefab;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public IEnumerator SpawnEnemy(){

        while(_gameManager.shouldSpawn){
           Instantiate(_enemyShipPrefab, new Vector3(Random.Range(-12.4f, 12.4f), 12f, 0), Quaternion.identity);
           yield return new WaitForSeconds(1f/(_gameManager.DificultyMultiplier/ 5) );
        }
   }
   
}
