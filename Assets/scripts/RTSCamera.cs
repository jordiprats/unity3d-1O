using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour {

	public float panSpeed = 20f;
	public float minPanSpeed = 5f;
	public float panBorderThickness = 50f;
	public Vector2 panLimit;
	public Vector2 scrollLimit;
	public float scrollSpeed = 5f;
	
	// Update is called once per frame
	void Update () {
		Vector3 new_pos = transform.position;

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		if(scroll!=0)
		{
			RaycastHit hit;
			Ray ray = this.transform.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			Vector3 desiredPosition;

			if (Physics.Raycast(ray , out hit))
				desiredPosition = hit.point;
			else
				desiredPosition = transform.position;
			float distance = Vector3.Distance(desiredPosition , transform.position);
			Vector3 direction = Vector3.Normalize( desiredPosition - transform.position) * (distance * scroll * scrollSpeed);

			new_pos += direction;
			if(new_pos.x < panLimit.x && new_pos.x > -panLimit.x && new_pos.y < scrollLimit.y && new_pos.y > scrollLimit.x && new_pos.z < panLimit.y && new_pos.z > -panLimit.y)
				transform.position = new_pos;
			else
				new_pos = transform.position;
		}

		float zoom_factor = (new_pos.y-scrollLimit.x)/(scrollLimit.y-scrollLimit.x);
		//Debug.Log("zoom_factor: "+zoom_factor);

		//Debug.Log("mouse x: "+Input.mousePosition.x+" vs "+(Screen.height - panBorderThickness));
		//Debug.Log("mouse y: "+Input.mousePosition.y+" vs "+(Screen.width - panBorderThickness));
		if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
		{
			new_pos.z += (minPanSpeed + panSpeed * zoom_factor) * Time.deltaTime;
		}

		if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
		{
			new_pos.z -= (minPanSpeed + panSpeed * zoom_factor) *  Time.deltaTime;
		}

		if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
		{
			new_pos.x += (minPanSpeed + panSpeed * zoom_factor) * Time.deltaTime;
		}

		if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
		{
			new_pos.x -= (minPanSpeed + panSpeed * zoom_factor) * Time.deltaTime;
		}

		new_pos.x = Mathf.Clamp(new_pos.x, -panLimit.x, panLimit.x);
		new_pos.y = Mathf.Clamp(new_pos.y, scrollLimit.x, scrollLimit.y);
		new_pos.z = Mathf.Clamp(new_pos.z, -panLimit.y, panLimit.y);

		transform.position = new_pos;
	}
}
