using UnityEngine;
using System.Collections;

public class FireLight : MonoBehaviour {

	float rnd;
	bool burning = true;

	void Start()
	{
		rnd = Random.value * 50;

	}

	void Update()
	{		
		if (burning)
		{
			GetComponent<Light>().intensity = 1 * Mathf.PerlinNoise(rnd+Time.time,rnd+0.5f+Time.time*0.5f);
			float x = Mathf.PerlinNoise(rnd+0+Time.time*0.5f,rnd+1+Time.time*2)-0.5f;
			float y = Mathf.PerlinNoise(rnd+2+Time.time*0.5f,rnd+3+Time.time*2)-0.5f;
			float z = Mathf.PerlinNoise(rnd+4+Time.time*0.5f,rnd+5+Time.time*2)-0.5f;
			transform.localPosition = Vector3.up + new Vector3(x,y,z)*1;
        }
	}

	public void Extinguish()
	{
		burning = false;
		GetComponent<Light>().enabled = false;
	}
}
