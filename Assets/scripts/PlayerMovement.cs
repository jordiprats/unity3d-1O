using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0f;
    public float jumpforce = 8.0f;
    public float gravity = 10.0f;
    private Vector3 moveDir = Vector3.zero;
	
	void Update () {
        CharacterController controller = gameObject.GetComponent<CharacterController>();

        if(controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            moveDir = transform.TransformDirection(moveDir);

            moveDir *= speed;

            if(Input.GetButtonDown("Jump"))
            {
                moveDir.y = jumpforce;
            }
        }

        moveDir.y -= gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);
	}
}
