using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
  private Animator monsterAnim;
  private float beingAttackTime = 0;
  private bool beingAttack;
  public int life = 4;
  public float attackRange = 3.0f;
  public float attackPeriod = 1.0f;
  public float attackTime;
  private GameObject hero;

  public Transform attackPfb;



  // Start is called before the first frame update
  void Start()
  {
    monsterAnim = GetComponent<Animator>();
    beingAttackTime = 0.0f;
    beingAttack = false;
    hero = GameObject.Find("Hero");
    attackTime = 0.0f;
  }

  // Update is called once per frame
  void Update()
  {

    if (beingAttack)
    {
      beingAttackTime += Time.deltaTime;
      print("Attack time: " + beingAttackTime);
      if (beingAttackTime >= 0.5f)
      {
        beingAttack = false;
        beingAttackTime = 0.0f;
        monsterAnim.SetBool("hurt", false);
      }
    }
    if (Mathf.Abs(transform.position.x - hero.transform.position.x) < 2*attackRange)
    {
      attackTime += Time.deltaTime;
      if (attackTime >= attackPeriod)
      {
        attack();
        attackTime = 0.0f;
      }
    }
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    // anim.SetBool("isJump", false);
    monsterAnim.SetBool("hurt", true);

    print(other.gameObject.name + " attacked Monster");
    // if(other.gameObject.CompareTag("Attack")){
    //    anim.SetTrigger("hurt");
    // }
    beingAttackTime = 0;
    if (other.gameObject.tag == "Attack")
      life--;
    if (life <= 0)
    {
      Destroy(gameObject);
    }

  }
  void attack()
  {
    Instantiate(attackPfb, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.3f, 0), attackPfb.transform.rotation);
  }

  void OnParticleCollision(GameObject obj)
  {

    print(obj.name + " attacked Monster");
    if (obj.tag == "Attack")
    {
      monsterAnim.SetBool("hurt", true);
      // print(obj.name + " attacked Monster");
      beingAttackTime = 0;
      life--;
      if (life <= 0)
      {
        Destroy(gameObject);
      }
    }
    
  }


}
