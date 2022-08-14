using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothController : MonoBehaviour
{
    //用于渲染
    public GameObject cloth;
    // 碰撞的ball
    public GameObject ball;
    //compute shader线程数
    private const int THREAD_X = 8;
    private const int THREAD_Y = 8;
    //compute shader组数
    private int _groupX;
    private int _groupY;
    //系统参数
    public Vector3 springKs = new Vector3(10000, 10000, 10000);
    public float mass = 1;
    public float stepTime = 0.08f;
    // public float stepTime = 0.8f;
    //cloth尺寸
    public int sizeX = 120;
    public int sizeY = 120;
    //cloth控制顶点个数
    public int _vertexCountX = 32;
    public int _vertexCountY = 32;
    private int _totalVertexCount;
    //cloth相邻顶点的间距
    private float distance;
    //ComputeShader对象定义
    public ComputeShader clothSimulate;
    //ComputeBuffer定义
    private ComputeBuffer _positionBuffer;
    private ComputeBuffer _velocityBuffer;
    //kernel函数标识
    private int _initKernel;
    private int _stepKernel;
    //控制顶点的位置信息
    private Vector3[] position;

    public void Initialize()
    {
        //根据顶点数和线程数,计算实际的组数
        _groupX = _vertexCountX / THREAD_X;
        _groupY = _vertexCountY / THREAD_Y;
        //计算顶点总数
        _totalVertexCount = _vertexCountX * _vertexCountY;

        //设置系统参数
        clothSimulate.SetVector("springKs", springKs);
        clothSimulate.SetFloat("mass", mass);
        clothSimulate.SetFloat("dt", stepTime);

        //计算顶点规模及弹簧原长
        distance = (float)sizeX / (float)(_vertexCountX - 1);
        clothSimulate.SetInts("size", _vertexCountX, _vertexCountY, _totalVertexCount);
        clothSimulate.SetVector("restLengths", new Vector3(distance, distance * Mathf.Sqrt(2), distance * 2));

        //绑定kernel函数
        _initKernel = clothSimulate.FindKernel("Init");
        _stepKernel = clothSimulate.FindKernel("Step");

        //开辟并绑定缓存
        position = new Vector3[_totalVertexCount];
        _positionBuffer = new ComputeBuffer(_totalVertexCount, 12);
        _velocityBuffer = new ComputeBuffer(_totalVertexCount, 12);
        System.Action<int> setBufferForKernel = (k) =>
        {
            clothSimulate.SetBuffer(k, "velocities", _velocityBuffer);
            clothSimulate.SetBuffer(k, "positions", _positionBuffer);
        };
        setBufferForKernel(_initKernel);
        setBufferForKernel(_stepKernel);

        //执行init kernel
        clothSimulate.Dispatch(_initKernel, _groupX, _groupY, 1);

    }

    void Start()
    {
        Initialize();
        UpdateBall();
    }

    void Update()
    {
        //执行step kernel
        clothSimulate.Dispatch(_stepKernel, _groupX, _groupY, 1);

        //获取顶点位置缓存
        _positionBuffer.GetData(position);

        //绘制cloth
        RenderCloth(cloth, 1);
       
    }
  
    public void UpdateBall(){
        var ballParams = (Vector4)ball.transform.position;
        ballParams.w = ball.transform.localScale.x ;
        print("ball:"+ballParams);
        clothSimulate.SetVector("collisionBall",ballParams);
    }
    private void OnDestroy()
    {
        //释放Buffer
        _positionBuffer?.Release();
        _positionBuffer = null;
        _velocityBuffer?.Release();
        _velocityBuffer = null;

        Array.Clear(position, 0, position.Length);
        position = null;
    }
    //绘制布料
    public void RenderCloth(GameObject obj, int flag)
    {
        int vertexCountPerDim = _vertexCountX;
        int[] indices = new int[6 * (vertexCountPerDim - 1) * (vertexCountPerDim - 1)];
        for (var x = 0; x < vertexCountPerDim - 1; x++)
        {
            for (var y = 0; y < vertexCountPerDim - 1; y++)
            {
                var vertexIndex = (y * vertexCountPerDim + x);
                var quadIndex = y * (vertexCountPerDim - 1) + x;
                var upVertexIndex = (vertexIndex + vertexCountPerDim);
                var offset = quadIndex * 6;
                indices[offset] = vertexIndex;
                indices[offset + 1] = (vertexIndex + 1);
                indices[offset + 2] = upVertexIndex;

                indices[offset + 3] = upVertexIndex;
                indices[offset + 4] = (vertexIndex + 1);
                indices[offset + 5] = (upVertexIndex + 1);
            }
        }

        //已有mesh，更新信息
        if (flag == 1)
        {
            Mesh mesh = obj.GetComponent<MeshFilter>().mesh;
            mesh.vertices = position;
            mesh.triangles = indices;
            mesh.RecalculateNormals();
        }
        else
        {
            // 没有mesh，创建新mesh
            Mesh msh = new Mesh();
            msh.vertices = position;
            msh.triangles = indices;
            msh.RecalculateNormals();
            msh.RecalculateBounds();
            obj.AddComponent<MeshRenderer>();

            MeshFilter filter;
            filter = obj.AddComponent<MeshFilter>();
            filter.mesh = msh;

            obj.AddComponent<MeshCollider>();
            obj.GetComponent<MeshRenderer>().material = Resources.Load("Resources/CubeMat2") as Material;
            obj.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}

