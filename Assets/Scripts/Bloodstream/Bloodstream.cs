using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bloodstream{
public class Bloodstream : MonoBehaviour
{
    [SerializeField]
    private GameObject _bloodCells;

    private float _nextSpawm = 0.1f;
    // Update is called once per frame
    void Start(){
        for(int i = 0; i < 10; i++){
        Instantiate(_bloodCells, new Vector3(0, Random.Range(-12f, 12f), 0), Quaternion.identity);
        }
        StartCoroutine(SpawnBloodCells());

    }
    void Update()
    {
    }

    IEnumerator SpawnBloodCells(){ 
        while(true){
        yield return new WaitForSeconds(0.5f);
        Instantiate(_bloodCells, new Vector3(0, 12.3f, 0), Quaternion.identity);
    }
    }
}
}
