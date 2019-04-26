using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private GameObject[] _powerUpDrops;

    [SerializeField]
    private GameObject _deathAnimation;

    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -7f)
        {
            float xPosition = Random.Range(-8f, 8f);
          transform.position = new Vector3(xPosition, transform.position.y * -1, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag.Equals("Laser")){

            if(other.transform.parent != null){
                Destroy(other.transform.parent.gameObject);
            }
            Debug.Log("Laser kill");
         
            Instantiate(_deathAnimation, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            _uiManager.UpdateScore(10);
            
            GenerateDrop();
        }

        if(other.tag.Equals("Player")){
            Player player = other.GetComponent<Player>();
            
            if(player != null){
            player.Damage();
            }

            Destroy(this.gameObject);
            Instantiate(_deathAnimation, transform.position, Quaternion.identity);
        }
    }

    private void GenerateDrop()
    {
        int random = Random.Range(1, 5);
        if (random == 1)
        {
            random = Random.Range(0, 3);
            Instantiate(_powerUpDrops[random], transform.position, Quaternion.identity);
        }
    }
}
