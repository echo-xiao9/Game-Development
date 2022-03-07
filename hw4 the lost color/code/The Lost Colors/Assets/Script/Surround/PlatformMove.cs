using System;


using UnityEngine;
using System.Collections;


public class PlatformMove : MonoBehaviour
{
    public Transform platform1;
    public Transform platform2;

    private GameObject player=null;

    public float moveRange=0.01f;
    public float moveSpeed=3.0f;

    private float speed = -2.0f;
    private float timePassed;

    void Start()
    {
        //Assigns the transform of the first child of the Game Object this script is attached to.
        platform1 = this.gameObject.transform.GetChild(0);
        platform2 = this.gameObject.transform.GetChild(1);
        timePassed = 0.0f;
    }
    void Update(){
      timePassed += Time.deltaTime;
      float x1 = platform1.position.x+  moveRange*Mathf.Sin(moveSpeed*timePassed- 1.73f);
      float x2 = platform2.position.x+  moveRange*Mathf.Cos(moveSpeed*timePassed);
      float moveHorizontal = Input.GetAxis("Horizontal");
      x1 += speed * Time.deltaTime * (float)moveHorizontal;  
      x2 += speed * Time.deltaTime * (float)moveHorizontal;  
      platform1.position =  new Vector3(x1, platform1.position.y, platform1.position.z);
      platform2.position =  new Vector3(x2, platform2.position.y, platform2.position.z);

    } 



}