using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject hero;
    private float timePassed;
    void Start()
    {
         hero = GameObject.Find("Hero");
         timePassed =0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed>5.0f)Destroy(gameObject);
    }
}
