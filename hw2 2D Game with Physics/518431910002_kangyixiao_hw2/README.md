# hw2: 2d game

学习备注和附加创新实现

## 加分项

### 增加寿命

增加寿命到3条，并增加*显示*

### 增加额外动作

![Untitled](hw2%202d%20gam%209c2d9/Untitled.png)

每次死亡会触发hit动作，hit动作（闪烁）的持续时间为三秒，在下一轮（寿命-1）的开头出现闪烁动作。

hit触发机制是 bool isRebirth =  true;当update 更新重生时间到了3s之后，返回到idle状态

![Untitled](hw2%202d%20gam%209c2d9/Untitled%201.png)

![Untitled](hw2%202d%20gam%209c2d9/Untitled%202.png)

### 碰到水果可以增加积分

![Untitled](hw2%202d%20gam%209c2d9/Untitled%203.png)

使用了两种水果，并且设计了Fruit：01 来记录吃到的水果个数。

![Untitled](hw2%202d%20gam%209c2d9/Untitled%204.png)

### 增加跳跃平台

![Untitled](hw2%202d%20gam%209c2d9/Untitled%205.png)

当物体碰触到火箭平台的时候，player 可以获得一个很大的向上的速度。

![Untitled](hw2%202d%20gam%209c2d9/Untitled%206.png)

![Untitled](hw2%202d%20gam%209c2d9/Untitled%207.png)

### spring joint 2d

给上方的倒刺增加一个弹簧的效果，在游戏开始的时候会向下不断弹动。

![Untitled](hw2%202d%20gam%209c2d9/Untitled%208.png)

## 实现可以挪动的背景

脚本内获取当前物体上的材质，并修改材质 中贴图的UV坐标偏移量 material.mainTextureOffset 来实现背景移动。

```java
public Vector2 speed;
Material material;
Vector2 movement;
// Start is called before the first frame update
void Start()
{
    material = GetComponent<Renderer>().material;
}
// Update is called once per frame
void Update()
{
    movement+=speed;
    material.mainTextureOffset = movement;
}
```

### 素材处理

![Untitled](hw2%202d%20gam%209c2d9/Untitled%209.png)

根据分辨率设置pixel per unit

## collider

几种碰撞体的区别：box、polygon

添加动画

选择物体， animation 设置sample rate， 把帧动画拖动进去

![Untitled](hw2%202d%20gam%209c2d9/Untitled%2010.png)

如果选定了 Is trigger, 只会判断碰撞，两个collider碰撞不会有实际的效果

<aside>
💡 Note: Collider 的 isTrigger 属性决定了物体碰撞时的效果。当 isTrigger=false ，当两个物体碰撞时会产 生碰撞效果，并且会触发 OnCollisionEnter/Stay/Exit 函数;而当 isTrigger=true ，当两个物体碰撞时不 会出现碰撞效果，且触发的是 OnTriggerEnter/Stay/Exit 函数。本次作业中将 TopSpikes 设成 trigger 使 之不与 Spiked Ball 发生碰撞，而其他平台障碍物则是普通 collider ，用于计算物理碰撞。

</aside>

加分项：构建其他平台障碍

选择freeze rotation, 就不会旋转了

![Untitled](hw2%202d%20gam%209c2d9/Untitled%2011.png)

![capsule collider, 胶囊状的collider](hw2%202d%20gam%209c2d9/Untitled%2012.png)

capsule collider, 胶囊状的collider

### move

使用了transform.localScale, 这个是用于放缩针对父对象的比例的。我一开是想要用transform.postion来进行位置变换发现这个还可以改变物体的朝向。因为输入xInput只取-1，+1， 所以大小不变，方向改变

![Untitled](hw2%202d%20gam%209c2d9/Untitled%2013.png)

![Untitled](hw2%202d%20gam%209c2d9/Untitled%2014.png)

### 删除和生成物体

Destory(gameObject);

gameObject直接指的是自己

```java
GameObject topLine;
// Start is called before the first frame update
void Start()
{
...
    topLine = GameObject.Find("TopLine");// 竟然可以直接用找
}

void Move(){
    ...
    if(transform.position.y>topLine.transform.position.y)
        Destroy(gameObject);
}

```

<aside>
💡 unity报错：MissingReferenceException: The object of type 'GameObject' has been destroyed but you are still trying to access it.

</aside>

原因是：，拖动到list里的应该是prefab而不是场景里的object…… 新生成的物体应该是从类生成。

### 动画切换

![Untitled](hw2%202d%20gam%209c2d9/Untitled%2015.png)

## reference

[Unity入门教程:快速制作一个游戏03：制作游戏人物&可视化范围检测（Gizmos.Draw)_哔哩哔哩_bilibili](https://www.bilibili.com/video/BV1VJ411C7Jp/?spm_id_from=333.788.recommend_more_video.-1)

[M_Studio的个人空间_哔哩哔哩_Bilibili](https://space.bilibili.com/370283072/channel/seriesdetail?sid=212000)

[Unity3D Transform.localScale 简析_SpikeTsui的博客-CSDN博客_localscale](https://blog.csdn.net/qq_24662995/article/details/105443116)