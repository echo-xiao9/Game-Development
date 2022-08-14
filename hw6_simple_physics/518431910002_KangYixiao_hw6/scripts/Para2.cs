// 实验B：模拟抛物运动
// TODO:
// 1. 参考注释补全代码，用Explicit Euler方法模拟抛物运动
// 2. 设置不同的初速度，观察运动效果
// 3. 尝试不同大小的时间步长，通过修改step的值来控制步长
// 4. 不同时间步长之间进行对比，以及与解析式方式对比
class Para2 : MonoBehaviour
{
    // current position
    private float height;
    private float x;
    private float z;
    // current velocity
    private Vector3 v = new Vector3(15,0,0); // try different initial values
    private float g = 9.79f; // gravity
    private int step = 2; // You can change this!
    private int count; // used to control the frequency of updates

    // TODO: complete the function
    void UpdatePosition()
    {
    	float t = Time.deltaTime;
        // 1. update position, move at speed of v for one time step 
		x= x + t*v.x*step;
        z= z + t*v.z*step;
        height = height + step*t*v.y;
        // 2. calculate v in the next time step
		v.y = v.y - g*t*step;
        // 3. check whether reach the bottom
		if(height <= transform.localScale.y/2){
        v.y= 0;
		v.x=0;
        v.z=0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // set initial values
        height = transform.position.y;
        x = transform.position.x;
        z = transform.position.z;
        count = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count >= step)
        {
            // calculate new position
            UpdatePosition();
            // set new position
            transform.position = new Vector3(x, height, z);
            count = 0;
        }
    }
}
