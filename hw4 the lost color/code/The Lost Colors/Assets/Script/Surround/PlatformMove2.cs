using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
public class PlatformMove2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveRange=0.01f;
    public float moveSpeed=3.0f;
    
    private float timePassed;
    private bool isPlayerOn;
    GameObject player;
    void Start()
    {
      isPlayerOn = false;
      timePassed=0.0f;
    }

    // Update is called once per frame
    void Update()
    {
      timePassed += Time.deltaTime;
      float delta=moveRange*Mathf.Cos(moveSpeed*timePassed);
      float moveHorizontal = Input.GetAxis("Horizontal");
      delta += Common.BgSpeed * Time.deltaTime * (float)moveHorizontal;  
      transform.position =  new Vector3(transform.position.x+delta, transform.position.y, transform.position.z);
      if(isPlayerOn && Mathf.Abs(moveHorizontal)<0.2){
        player.transform.position = new Vector3(player.transform.position.x+delta, player.transform.position.y, player.transform.position.z);
      }
      else if(isPlayerOn && Mathf.Abs(moveHorizontal)>=0.2){
        player.transform.position = new Vector3(player.transform.position.x+moveRange*Mathf.Cos(moveSpeed*timePassed), player.transform.position.y, player.transform.position.z);
      }
      
      
      
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        print("开始碰撞" + other.collider.gameObject.name);
        if(other.gameObject.CompareTag("Player")){
          isPlayerOn=true;
          player = other.collider.gameObject;
        }
    }
  //   void OnCollisionEnter2D(Collision2D other){
  //   if(other.gameObject.CompareTag("Player")){
  //     Destroy(gameObject);
  //   }
  // }

    void OnCollisionExit2D(Collision2D col)
    {
        print("碰撞结束" + col.collider.gameObject.name);
        if(col.gameObject.CompareTag("Player")){
          isPlayerOn=false;
          player=null;
        }
    }




}
