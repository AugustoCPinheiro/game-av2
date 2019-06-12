using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAi : MonoBehaviour
{
  [SerializeField]
    protected float _speed = 5.0f;
    [SerializeField]
    protected int _lifes;

    [SerializeField]
    protected GameObject[] _powerUpDrops;

    [SerializeField]
    protected GameObject _deathAnimation;

    protected UIManager _uiManager;

    protected GameManager _gameManager;

    // Start is called before the first frame update
    protected void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
      
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    protected void Update()
    {
        Move();
    }

    protected abstract void Move();

    protected  void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag.Equals("Laser")){
            Laser laser = other.GetComponent<Laser>();
            _lifes = _lifes - laser.Damage;


            Destroy(other.gameObject);
            if( _lifes <= 0){
                if(other.transform.parent != null){
                    Destroy(other.transform.parent.gameObject);
                }
                Debug.Log("Laser kill");
         
                //Instantiate(_deathAnimation, transform.position, Quaternion.identity);
                GenerateDrop();
                Destroy(this.gameObject);
                _gameManager.UpdatePlayerScore(10);
            
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
        int random = Random.Range(1, 4);
        if (random == 1)
        {
            random = Random.Range(0, 3);
            Instantiate(_powerUpDrops[random], transform.position, Quaternion.identity);
        }
    }
}
