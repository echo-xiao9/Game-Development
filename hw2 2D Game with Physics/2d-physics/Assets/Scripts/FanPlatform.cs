using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPlatform : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other){
      if(other.gameObject.CompareTag("Player")){
        animator.Play("Fan_run");
      }
    }

}
