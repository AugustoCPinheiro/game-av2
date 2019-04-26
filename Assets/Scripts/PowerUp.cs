using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.5f;

    [SerializeField]
    private int _powerupId;

    [SerializeField]
    private AudioClip _clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if(transform.position.y < -5.55f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player")) { 
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                switch (_powerupId) {
                    case 0:
                        player.TripleShootPowerUpOn();
                        break;
                    case 1:
                        player.SpeedPowerUpOn();
                        break;
                    case 2:
                        player.ShieldPowerupOn();
                        break;
                }
        }
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
           
            Destroy(this.gameObject);
        }
    }
}
