using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  public float speed;
  private int count;
  public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        setCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate(){
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
      GetComponent<Rigidbody>().AddForce(movement*speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other){
      if(other.gameObject.tag == "PickUp"){
        // 代表让方块不显示，并不代表删除方块，你可 以在任意时刻通过调用 SetActive(true)让它重新显示。
        other.gameObject.SetActive(false);
        count++;
        setCountText();
      }
    }

    void setCountText(){
      countText.text = "Count:"+count;
    }
}
