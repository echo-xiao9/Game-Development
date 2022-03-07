using UnityEngine;
using System.Collections;

public class Waterfall : MonoBehaviour 
{

	public float speed = 20.0f;
	
	
	void Update () 
	{
	
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (0,Time.time * speed);
	}
}
