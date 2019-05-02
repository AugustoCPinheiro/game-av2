using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShotPowerup : PowerUp
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Player"))
        {
            Player player = other.GetComponent<Player>();

            player.BigShotPowerupOn(); 
        }
        base.OnTriggerEnter2D(other);
    }
}
