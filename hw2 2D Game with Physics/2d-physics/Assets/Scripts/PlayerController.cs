using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  Rigidbody2D rb;
  public float speed;
  Animator anim;

  public float checkRadius;
  public bool isOnGround;
  public LayerMask platform;
  public GameObject groundCheck;

  public int life;
  
  public Text lifeLeft;
  private int fruitNum;
  public Text fruitScore;

  private Vector3 originalPos;

  public bool isRebirth;
  private float rebirthTime;

  private float rebirthTimeLimit;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originalPos = transform.position;
        rebirthTimeLimit = 3f;
        fruitNum =0;
    }

    // Update is called once per frame
    void Update()
    {
       isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position,checkRadius, platform);
       anim.SetBool("isOnGround", isOnGround);
       Move();
       rebirthTime += Time.deltaTime;
       if(rebirthTime >= rebirthTimeLimit){
         isRebirth=false;
         anim.SetBool("isRebirth",isRebirth);
         rebirthTime=0;
       }
        // print("update");
        lifeLeft.text ="Life:"+ life.ToString("0");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }

    void Move(){
      float xInput = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(xInput*speed, rb.velocity.y);
      // diff with that?
      // transform.position = new Vector3(transform.position.x+speed*Time.deltaTime, transform.position.y, transform.position.z);
      if(xInput !=0)
        transform.localScale = new Vector3(xInput, 1,1);
      anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));// run/idle
    }

    public void Die(){
      print("Die");
      anim.SetBool("isOnTop", true);
      life--;
      if(life <= 0)GameManager.GameOver(true);
      transform.position = originalPos;
      isRebirth=true;
      anim.SetBool("isRebirth",isRebirth);
    }

    private void Eat(){
      fruitNum++;
      fruitScore.text = "Fruit:"+fruitNum.ToString("00");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spike"))
        {
        Die(); 
        }
        if(other.CompareTag("Fruit")){
          Eat();
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
