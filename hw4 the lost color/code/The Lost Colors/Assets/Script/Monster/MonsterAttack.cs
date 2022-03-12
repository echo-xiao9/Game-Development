using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
   private GameObject hero;
   public float steps=30; 
   private Vector3 delta;
    void Start()
    {
        hero = GameObject.Find("Hero");
        Vector3 distance = new Vector3(hero.transform.position.x-transform.position.x, hero.transform.position.y-transform.position.y, 0);
        delta = new Vector3(distance.x/steps, distance.y/steps, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x+delta.x, transform.position.y+delta.y,0);
        if(Mathf.Abs(transform.position.x - hero.transform.position.x)>5.0f)Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other){
       Destroy(gameObject);
    }
}
