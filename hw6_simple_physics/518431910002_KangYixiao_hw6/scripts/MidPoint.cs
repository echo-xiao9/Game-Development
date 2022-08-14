// 实验C：模拟单摆运动
// TODO:
// 1. 分别使用Explicit Euler, Midpoint, Trapezoid方法实现单摆模拟
// 2. 创建一个名为fixP的对象，scale设为(1, 1, 1),其位置即为单摆运动的固定点
// 3. 创建一个名为line的立方体对象，scale设为(1, length, 1)，将被作为单摆的摆线
// 4. 设置摆长和初始角度，可以修改对应参数，length和theta
// 5. 尝试不同的时间步长，修改step的值
class MidPoint : MonoBehaviour
{
    private float g = 9.79f;
    private Vector3 fixedPos; // position of the fixed point
    public float length = 50; // length of pendulum. you can change it!
    public float theta = -15; // initial angle, range [-90 degree, 90 degree]. you can change it!
    private float omega; // angular velocity
    private int step = 2; // time step, you can change it, too!
    private int count; // used to control the frequency of updates

    // TODO: complete the function
    void UpdatePosition()
    {
    	float t= Time.deltaTime;
        // the difference in angles during this time step
		float thetaTmp = theta + omega * t*step/2;
        float omegaTmp = omega -g*Mathf.Sin(theta)/length*t*step/2;
        float deltaTheta = step*omegaTmp*t;
        omega = omega - g*Mathf.Sin(thetaTmp)/length*t*step;
		theta = theta + deltaTheta;
        // 5. move the object to the new postion
        SetPosition(deltaTheta);
    }

    // Start is called before the first frame update
    void Start()
    {
        // set the fixed position by gameobjtect
        fixedPos = fixP.transform.position;
        // set the initial position
        theta = theta * Mathf.Deg2Rad;
        SetPosition(theta);
        omega = 0;
        count = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count >= step)
        {
            UpdatePosition();
            count = 0;
        }
    }

    // calculate the position according to the pendulum length, angle and fixed point
    // angle: angle of rotation since last update, unit is Rad
    void SetPosition(float angle)
    {
        Vector3 pos = fixedPos;
        pos.x = fixedPos.x + length * Mathf.Sin(theta);
        pos.y = fixedPos.y - length * Mathf.Cos(theta);
        transform.position = pos;
        transform.Rotate(new Vector3(0, 0, angle * Mathf.Rad2Deg));
        // update position of the line
        Vector3 linePos = fixedPos;
        linePos.x = fixedPos.x + length * Mathf.Sin(theta) / 2;
        linePos.y = fixedPos.y - length * Mathf.Cos(theta) / 2;
        line.transform.position = linePos;
        line.transform.Rotate(new Vector3(0, 0, angle * Mathf.Rad2Deg));
    }
}
