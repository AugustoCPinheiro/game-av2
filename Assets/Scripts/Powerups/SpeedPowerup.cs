using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : PowerUp{
    void Start()
    {
        _powerupId = 1;
    }

     void OnTriggerEnter2D(Collider2D other) {
         if (other.tag.Equals("Player"))
         {
             Player player = other.gameObject.GetComponent<Player>();
             player.SpeedPowerUpOn();
         }
            base.OnTriggerEnter2D(other);
    }
}
