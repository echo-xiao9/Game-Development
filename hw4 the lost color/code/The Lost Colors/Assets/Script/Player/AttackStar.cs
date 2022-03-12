using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStar : MonoBehaviour
{
    // Start is called before the first frame updat
    public float flySpeed=0.01f;
    GameObject Camera;
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x+flySpeed*Time.deltaTime, transform.position.y, transform.position.z);
        if(Mathf.Abs(transform.position.x - Camera.transform.position.x)>5.0f)Destroy(gameObject);
        
    }
    void OnCollisionEnter2D(Collision2D other){
       Destroy(gameObject);
    }


}
