using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripeShotPrefab;

    [SerializeField]
    private GameObject _deathAnimation;

    [SerializeField]
    private GameObject _shieldGameObject;
    
    [SerializeField]
    private int _shootType = 0;

    [SerializeField]
    private bool _hasShield;

    [SerializeField]
    private int _maxLifes = 3;

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

    private bool _isReloading = false;
    private UIManager _uiManager;
    private GameManager _gameManager;
    private AudioSource _audioSource;
    
    private float _reloadSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        _currentAmmo = _maxAmmo;
       transform.position = new Vector3(0,0,0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uiManager.UpdateLives(_lifes);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        reloadAmmo();
        Movement();
        Shoot();
    }

    private void Shoot()
    {
        

        if((Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Mouse0))&& Time.time > _nextFire && !_isReloading)
        {
            switch (_shootType) { 
                case 0:
                    _nextFire = Time.time + _fireRate;
                    Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f , 0), Quaternion.identity);
                    break;
                case 1:
                    _nextFire = Time.time + _fireRate;
                    Instantiate(_tripeShotPrefab, transform.position, Quaternion.identity);
                    break;
            }
            _currentAmmo--;
            _audioSource.Play();
    }

  

        //Maybe for fast shooting
        /*float fireAxis = Input.GetAxis("Fire1");
        Debug.Log(fireAxis + "");
        if(fireAxis == 1)
        {
            Instantiate(laserPrefab);
        }*/
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        transform.Translate(Vector3.right * Time.deltaTime * _speedMultiplier * horizontalInput);

        transform.Translate(Vector3.up * Time.deltaTime * _speedMultiplier * verticalInput);


        if (transform.position.y > 3)
        {
            transform.position = new Vector3(transform.position.x, 3, 0);
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
       if(_currentAmmo == 0){
           _isReloading = true;
           StartCoroutine(reload());
       }
   }
    public void Damage(){
        if(_hasShield){
            _hasShield = !_hasShield;
            _shieldGameObject.SetActive(false);

        }else{
            _lifes--;
//            _uiManager.UpdateLives(_lifes);
            BreakEngine();

            if (_lifes < 1){
                Instantiate(_deathAnimation, transform.position, Quaternion.identity);
                _gameManager.gameOver = true;
                _uiManager.SetupUIEnd();
                Destroy(this.gameObject);
            }
        }
    }
    
    private void BreakEngine()
    {

       if(_maxLifes - _lifes == 1)
        {
            _engines[0].SetActive(true);
        }
        else
        {
            _engines[1].SetActive(true);
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

    public void ShieldPowerupOn()
    {
        _hasShield = true;
        _shieldGameObject.SetActive(true);
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
    
    public int Lifes { get => Lifes; }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(_reloadSpeed);
        _isReloading = false;
        _currentAmmo = _maxAmmo;
        //_uiManager.updateAmmo(_currentAmmo);
    }


}
