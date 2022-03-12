using UnityEngine;
using UnityEngine.UI;

namespace ClearSky
{
  public class SimplePlayerController : MonoBehaviour
  {
    public float movePower = 10f;
    public float jumpPower = 15f; //Set Gravity Scale in Rigidbody2D Component to 5

    private Rigidbody2D rb;
    private Animator anim;
    Vector3 movement;
    private int direction = 1;
    bool isJumping = false;
    private bool alive = true;
    public Transform prefab;

    public int life;
    public Slider lifeSlider;

    private float hurtTime;
    private bool isHurt=false;

    public Text gemNumText;
    public int gemNum;


    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();
      lifeSlider.minValue = 0;
      lifeSlider.maxValue = life;
      lifeSlider.value = life;
      lifeSlider.wholeNumbers = true;
      hurtTime =0;
      gemNum=0;
    }

    private void Update()
    {
      Restart();
      if (alive)
      {
        // Hurt();
        // Die();
        Attack();
        Jump();
        Run();

      }

      if(isHurt){
        hurtTime += Time.deltaTime;
        if(hurtTime >=0.5f){
          anim.SetBool("hurt",false);
          hurtTime = 0;
          isHurt = false;
        }
      }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      anim.SetBool("isJump", false);
      if (other.tag == "thorn")
      {
        print("DIe");
        Die();
      }
    }


    void Run()
    {
      Vector3 moveVelocity = Vector3.zero;
      anim.SetBool("isRun", false);


      if (Input.GetAxisRaw("Horizontal") < 0)
      {
        direction = -1;
        moveVelocity = Vector3.left;

        transform.localScale = new Vector3(direction, 1, 1);
        if (!anim.GetBool("isJump"))
          anim.SetBool("isRun", true);

      }
      if (Input.GetAxisRaw("Horizontal") > 0)
      {
        direction = 1;
        moveVelocity = Vector3.right;

        transform.localScale = new Vector3(direction, 1, 1);
        if (!anim.GetBool("isJump"))
          anim.SetBool("isRun", true);

      }
      transform.position += moveVelocity * movePower * Time.deltaTime;
    }
    void Jump()
    {
      if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
      && !anim.GetBool("isJump"))
      {
        isJumping = true;
        anim.SetBool("isJump", true);
      }
      if (!isJumping)
      {
        return;
      }

      rb.velocity = Vector2.zero;

      Vector2 jumpVelocity = new Vector2(0, jumpPower);
      rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

      isJumping = false;
      Vector3 moveVelocity = Vector3.zero;
      if (Input.GetAxisRaw("Horizontal") < 0)
      {
        direction = -1;
        moveVelocity = Vector3.left;

        transform.localScale = new Vector3(direction, 1, 1);
        if (!anim.GetBool("isJump"))
          anim.SetBool("isRun", true);

      }
      if (Input.GetAxisRaw("Horizontal") > 0)
      {
        direction = 1;
        moveVelocity = Vector3.right;

        transform.localScale = new Vector3(direction, 1, 1);
        if (!anim.GetBool("isJump"))
          anim.SetBool("isRun", true);

      }
      transform.position += moveVelocity * movePower * Time.deltaTime;



    }
    void Attack()
    {
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
        anim.SetTrigger("attack");
        // Object prefabObj = Resources.Load("AttackStar");
        // print("attack x:"+transform.position.x+" y:"+transform.position.y);
        Instantiate(prefab, new Vector3(transform.position.x + 0.3f, transform.position.y + 0.5f, 0), prefab.transform.rotation);

      }
    }
    void Hurt()
    {

      anim.SetTrigger("hurt");
      life --;
      if(life == 0){
        Die();return;
      }
      isHurt=true;
      hurtTime=0;
      UpdateLifeSlider();
      if (direction == 1)
        rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
      else
        rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
      
    }
    void Die()
    {

      anim.SetTrigger("die");
      alive = false;

    }
    void Restart()
    {
      if (Input.GetKeyDown(KeyCode.Alpha0))
      {
        anim.SetTrigger("idle");
        alive = true;
      }
    }

    void OnParticleCollision(GameObject obj){
      if (obj.tag == "MonsterAttack")
      {
        Hurt();
      }
    }
    
    void UpdateLifeSlider(){
      lifeSlider.value = life;
    }
    void OnCollisionEnter2D(Collision2D other){
       if (other.gameObject.tag == "Gem"){
        gemNum++;
        gemNumText.text = gemNum.ToString();
       }
    }
}
}