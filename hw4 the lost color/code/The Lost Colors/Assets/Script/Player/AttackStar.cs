using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStar : MonoBehaviour
{
    // Start is called before the first frame updat
    public float flySpeed=0.01f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x+flySpeed*Time.deltaTime, transform.position.y, transform.position.z);
    }
    void OnCollisionEnter2D(Collision2D other){
       Destroy(gameObject);
    }


}
