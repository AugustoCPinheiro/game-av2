using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadPowerup : PowerUp
{
    // Start is called before the first frame update
    void Start()
    {
     _powerupId = 0;   
    }

    private void OnTriggerEnter2D(Collider2D other) {
            if(other.tag.Equals("Player")){                
                Player player = other.gameObject.GetComponent<Player>();
                player.ReloadPowerupOn();
            }
            base.OnTriggerEnter2D(other);
                
    }
}
