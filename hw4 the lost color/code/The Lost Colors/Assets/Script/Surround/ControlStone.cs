using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlStone : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveStoneSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
          print("stone");
          float moveHorizontal = Input.GetAxis("Horizontal");
          transform.position = new Vector3(transform.position.x + moveHorizontal*moveStoneSpeed*Time.deltaTime , transform.position.y,transform.position.z);
        } 
    }
}
