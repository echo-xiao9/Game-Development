# hw1 Roll a ball

1. prefab的好处在于修改了一个其他都会改，类似类和继承的关系
2. 控制物体的移动 transform.position(这个是个Vector3),相机追随只要把这个脚本绑定Main camera上，把player 拖到脚本上。注意这里学会了一种引用其他物体的方式，就是在脚本里声明一个public GameObject, 然后把对应要引用的对象拖过去就OK。

```java
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public GameObject player;
  private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        **transform.position= player.transform.position + offset;**
    }
}
```

3. 旋转物体

```java
// Rotater.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
    }
}
```

Time.deltaTime 代表的是帧与帧的间隔 时间。将两者相乘，代表以[(15, 30, 45) * Time.deltaTime/帧]的速率自动旋转物 体，等同于以[(15, 30, 45) /s]的速率自动旋转物体。

4. 碰撞检测

给物体一个rigidbox（自带的刚体脚本），这样物体就可以和其他物体碰撞了。

private void OnTriggerEnter(Collider other) 这个是和其他物体碰撞被触发的行为。

```java
Rigidbody.AddForce
public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);
```

```java
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  public float speed;
  private int count;
  public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        setCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate(){
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
      GetComponent<Rigidbody>().AddForce(movement*speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other){
      if(other.gameObject.tag == "PickUp"){
        // 代表让方块不显示，并不代表删除方块，你可 以在任意时刻通过调用 SetActive(true)让它重新显示。
        other.gameObject.SetActive(false);
        count++;
        setCountText();
      }
    }

    void setCountText(){
      countText.text = "Count:"+count;
    }
}
```

5. 方向输入

这里第一句 GetAxis 其实就是获 取上述按键按下的程度(这里全左为-1，全右为 1)。同理第二句 GetAxis 其实就 是获取上下按键或 WS 按键按下的程度(这里全上为 1，全下为-1）

```java
float moveHorizontal = Input.GetAxis("Horizontal");
float moveVertical = Input.GetAxis("Vertical");
```

### reference

[Roll-a-Ball - Unity Learn](https://learn.unity.com/project/roll-a-ball?language=en&signup=true&tab=overview)

[GP-hw1 Roll-A-Ball.pdf](hw1%20Roll%20a%207a0de/GP-hw1_Roll-A-Ball.pdf)