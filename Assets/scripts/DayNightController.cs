using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour {
	
	public float daynightFactor=0.1f;
	// Update is called once per frame
	void Update () 
	{
		transform.RotateAround(Vector3.zero,Vector3.right, daynightFactor*Time.deltaTime);
		transform.LookAt(Vector3.zero);
	}
}
