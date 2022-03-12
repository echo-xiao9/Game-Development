using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
public class MoveBg : MonoBehaviour
{
  // Start is called before the first frame update
  private float speed;
  private float x;
	private float PontoDeDestino=-8.56f;
	private float PontoDeDestino2=8.56f;
	private float PontoOriginal  = 9.0f;
  public GameObject Camera;
  public float layer;
  private float times=0.1f;
  // public bool isSecond;
  void Start()
  {
    // speed = Common.BgSpeed;
    speed=layer*times;
    Camera = GameObject.Find("Main Camera");
    float move2 = Camera.transform.position.x - transform.position.x;
 
  }

  // Update is called once per frame
  void Update()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    x = transform.position.x;
    if(moveHorizontal >0.5 || moveHorizontal < -0.5) x += speed * Time.deltaTime * moveHorizontal;
    transform.position = new Vector3(x, transform.position.y, transform.position.z);
    float move2 = Camera.transform.position.x - transform.position.x;
    

    if( move2 >= PontoDeDestino2){
      // print("first move2: "+move2+"camera:"+Camera.transform.position.x+ " x:"+transform.position.x);
      x -= 2* PontoDeDestino;
      transform.position = new Vector3(x, transform.position.y, transform.position.z);    
    }


  }











}
