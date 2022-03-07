using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
   
    
  }
  void OnCollisionEnter2D(Collision2D other){
    print(other);
    if(other.gameObject.CompareTag("Player")){
      Destroy(gameObject);
    }
  }












}
