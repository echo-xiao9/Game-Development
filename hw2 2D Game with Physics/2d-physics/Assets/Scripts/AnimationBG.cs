using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBG : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 speed;
    Material material;
    Vector2 movement;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        movement += speed;
        material.mainTextureOffset = movement;
    }
}
