﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBoss : EnemyAi
{
    protected float cooldown;
    protected float nextShot;

    protected Player player;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
   
    protected abstract void Shoot();
}
