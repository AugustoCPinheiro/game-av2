using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _bigShotPrefab;

    [SerializeField]
    private GameObject _deathAnimation;


    [SerializeField]
    private int _shootType = 0;

    [SerializeField]
    private bool _hasShield;

    private int _lifes = 3;

    [SerializeField]
    private float _fireRate = 1f;
    
    [SerializeField]
    private int _maxAmmo = 5;

    private int _currentAmmo;
    private float _nextFire = 0.0f;

    [SerializeField]
    private GameObject[] _engines;

    [SerializeField]
    private float _speedMultiplier = 8;

    public bool _isReloading = false;
    private UIManager _uiManager;
    private GameManager _gameManager;
    
    [SerializeField]
    private AudioClip _audioSource;
    
    private float _reloadSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        _currentAmmo = _maxAmmo;
        transform.position = new Vector3(0,0,0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
      //  _uiManager.UpdateLives(_lifes);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void FixedUpdate() {
        Shoot();
    }

    private void Shoot()
    {
        

        if((Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Mouse0))&& Time.time > _nextFire && !_isReloading)
        {
            _nextFire = Time.time + _fireRate;
            switch (_shootType) { 
                case 0:
                    Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f , 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(_bigShotPrefab, transform.position + new Vector3(0, 0.88f , 0), Quaternion.identity);
                    break;
            }
            _currentAmmo--;

            if (_currentAmmo == 0){
              reloadAmmo();
            }
            _uiManager.UpdateAmmo(_currentAmmo);
           
        }

  

    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        transform.Translate(Vector3.right * Time.deltaTime * _speedMultiplier * horizontalInput);

        transform.Translate(Vector3.up * Time.deltaTime * _speedMultiplier * verticalInput);


        if (transform.position.y > 10)
        {
            transform.position = new Vector3(transform.position.x, 10, 0);
        }
        else if (transform.position.y < -7.9f)
        {
            transform.position = new Vector3(transform.position.x, -7.9f, 0);

        }
        
        if (transform.position.x > 12.4f){
            transform.position = new Vector3(12.4f, transform.position.y, 0);
        }
        if (transform.position.x < -12.4f)
        {
            transform.position = new Vector3(-12.4f, transform.position.y, 0);
        }
       
       
    }
   private void reloadAmmo(){
           _isReloading = true;
           _uiManager.Reload(_isReloading);
           StartCoroutine(reload());
       
   }
    public void Damage(){
            _lifes--;
            _uiManager.UpdateLives(_lifes);

            if (_lifes < 1){
                Instantiate(_deathAnimation, transform.position, Quaternion.identity);
                 AudioSource.PlayClipAtPoint(_audioSource, Camera.main.transform.position);
                //_gameManager.gameOver = true;
                //_uiManager.SetupUIEnd();
                Destroy(this.gameObject);
            }
        
    }
    

    public void ReloadPowerupOn()
    {
        _reloadSpeed = 1f;
        StartCoroutine(ReloadPowerupDownRoutine());
    }

    public void SpeedPowerUpOn()
    {
        _speedMultiplier *=  1.5f;
        StartCoroutine(SpeedPowerUpDownRoutine());
    }

    public void BigShotPowerupOn()
    {
        _shootType = 1;
        StartCoroutine(BigShotPowerupDownRoutine());
       
    }

    IEnumerator ReloadPowerupDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _reloadSpeed = 1.5f;
    }

    IEnumerator SpeedPowerUpDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _speedMultiplier = 5;
    }

    IEnumerator BigShotPowerupDownRoutine(){
        yield return new WaitForSeconds(5.0f);
        _shootType = 0;
    }
    
    public int Lifes { get => Lifes; }
    //public int Ammo { get => _currentAmmo; }


    IEnumerator reload()
    {
        yield return new WaitForSeconds(_reloadSpeed);
        _isReloading = false;
        _currentAmmo = _maxAmmo;
        _uiManager.Reload(_isReloading);
    }


}
