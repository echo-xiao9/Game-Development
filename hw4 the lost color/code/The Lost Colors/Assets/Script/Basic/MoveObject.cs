using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class MoveObject : MonoBehaviour
{
  // Start is called before the first frame update
  private float speed;
  private float x;
  private float PontoDeDestino = -8.56f;
  private float PontoOriginal = 9.0f;
  void Start()
  {
    speed = Common.BgSpeed;
  }

  // Update is called once per frame
  void Update()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");

    if(moveHorizontal==0)return;
    x = transform.position.x;
    x += speed * Time.deltaTime * (float)moveHorizontal;
    transform.position = new Vector3(x, transform.position.y, transform.position.z);
    if (x <= PontoDeDestino)
    {
      x = PontoOriginal;
      transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

  }

}


