using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    private Animator _animator;
    Vector3 oldTouch;

    void Start() {
        _animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.acceleration.x < 0) {
            TurnLeft();
        } else if (Input.acceleration.x > 0) {
            TurnRight();
        }
        /*if (Input.touchCount > 0) {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
                if (oldTouch == Vector3.negativeInfinity) {
                    oldTouch = touchedPos;
                }
                var x = oldTouch.x - touchedPos.x;
                if (x > 0) {
                    TurnLeft();
                } else if (x < 0) {
                    TurnRight();
                }
                oldTouch = touchedPos;
            }
        } else {
            oldTouch = Vector3.negativeInfinity;
        }*/
        if (Input.GetKeyDown(KeyCode.LeftArrow)) TurnLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow)) TurnRight();
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) Normalize();
    }

    void TurnLeft() {
        _animator.SetBool("Turn_left", true);
        _animator.SetBool("Turn_right", false);
    }

    void TurnRight() {
        _animator.SetBool("Turn_left", false);
        _animator.SetBool("Turn_right", true);
    }

    void Normalize() {
        _animator.SetBool("Turn_right", false);
        _animator.SetBool("Turn_left", false);
    }
}
