using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMoveObj : MonoBehaviour
{
    // Start is called before the first frame update
     public float moveSpeed;
     public float moveRange;
     private float timePassed;
     Vector3 oriPos;
    void Start()
    {
       timePassed = 0;
       oriPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
      timePassed += Time.deltaTime;
      transform.position = new Vector3(oriPos.x, oriPos.y+moveRange* Mathf.Cos(timePassed*moveSpeed),transform.position.z);
    }
}
