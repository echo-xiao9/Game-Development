// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms;
    //定义多少时间生成平台
    public float spawnTime;
    //record how much time passed
    private float countTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        // print(countTime);
        if(countTime >=spawnTime){
          SpawnPlatform();
          // can calculate time again
          countTime = 0;
        }
    }

    public void SpawnPlatform(){
      // the posiion is the same at the buttomline
      Vector3 spawnPosition = transform.position;
      // the range of x
      spawnPosition.x = Random.Range(-3.5f, 3.5f);
      // the kind of the platform
      int index = Random.Range(0, platforms.Count);
      print("generate new plateform:"+index);
      // use Instantiate to generate platforms, angle: Quaternion.identity
      GameObject go = Instantiate(platforms[index], spawnPosition,
      Quaternion.identity);
      go.transform.SetParent(this.gameObject.transform);
    }


}
