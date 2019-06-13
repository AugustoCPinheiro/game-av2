using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumorBossAnimation : MonoBehaviour
{

    private Animator bossAnimator;
    // Start is called before the first frame update
    void Start()
    {
        bossAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toLeft(){
        bossAnimator.SetBool("toLeft", true);
        bossAnimator.SetBool("toRight", false);
        bossAnimator.SetBool("toIdle", false);
    }
    public void toRight(){
        bossAnimator.SetBool("toLeft", false);
        bossAnimator.SetBool("toRight", true);
        bossAnimator.SetBool("toIdle", false);
    }

    public void toIdle(){
        bossAnimator.SetBool("toLeft", false);
        bossAnimator.SetBool("toRight", false);
        bossAnimator.SetBool("toIdle", true);

    }
}
