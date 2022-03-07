using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
  private Animator monsterAnim;
  private float attackTime=0;
  private bool beingAttack;
  public int life=4;
    // Start is called before the first frame update
    void Start()
    {
        monsterAnim = GetComponent<Animator>();
        attackTime =0.0f;
        beingAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(beingAttack){
          attackTime += Time.deltaTime;
          print("Attack time: "+attackTime);
          if(attackTime >= 0.5f){
            beingAttack=false;
            attackTime = 0.0f;
            monsterAnim.SetBool("hurt", false);
          }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
        {
            // anim.SetBool("isJump", false);
            monsterAnim.SetBool("hurt", true);
            
            print(other.gameObject.name+" attacked Monster");
            // if(other.gameObject.CompareTag("Attack")){
            //    anim.SetTrigger("hurt");
            // }
            attackTime=0;
            if(other.gameObject.tag =="Attack")
            life--;
            if(life<=0){
              Destroy(gameObject);
            }



        }

    
}
