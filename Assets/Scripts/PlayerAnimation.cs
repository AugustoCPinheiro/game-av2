﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _animator.SetBool("Turn_Left", true);
            _animator.SetBool("Turn_Right", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)){
            _animator.SetBool("Turn_Right", true);
            _animator.SetBool("Turn_Left", false);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _animator.SetBool("Turn_Left", false);
            _animator.SetBool("Turn_Right", false);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _animator.SetBool("Turn_Right", false);
            _animator.SetBool("Turn_Left", false);
        }


    }
}
