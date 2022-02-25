using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  Rigidbody2D rb;
  public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        // print("update");
    }

    void Move(){
      float xInput = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(xInput*speed, rb.velocity.y);
      // diff with that?
      // transform.position = new Vector3(transform.position.x+speed*Time.deltaTime, transform.position.y, transform.position.z);
      if(xInput !=0)
        transform.localScale = new Vector3(xInput, 1,1);
    }

    public void Die(){
      print("Die");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spike"))
        {
        Die(); 
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    { 
      if(other.gameObject.CompareTag("Spike"))
        {
          Die(); 
        }
    }
}
