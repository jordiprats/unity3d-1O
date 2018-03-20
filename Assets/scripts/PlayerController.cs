using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour {

	public Camera cam;
	private NavMeshAgent agent;
	private int clicks = 0;
	private float click_last_time=0;
	public float max_click_delay=0.2f;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () 
	{
		//if(Input.GetMouseButtonDown(0))
		if(Input.GetMouseButtonUp(0))
		{
			if(click_last_time!=0)
			{
				//Debug.Log(Time.time - click_last_time);
				clicks=((Time.time - click_last_time) < max_click_delay)?clicks+1:1;
				click_last_time=Time.time;
			}
			else
			{
				click_last_time=Time.time;
				clicks++;
			}
			//Debug.Log(clicks);
			if(clicks>=2)
			{
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if(Physics.Raycast(ray, out hit))
				{
					agent.SetDestination(hit.point);
				}
			}
		}	
	}
}
