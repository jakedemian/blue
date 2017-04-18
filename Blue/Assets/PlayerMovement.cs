using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public GameObject ship;

	private float speed = 1f;

	public float moveModifier = 1;

	float currentXPos;
	float currentYPos;

	float xDir;
	float yDir;

	void updatePosVariables(){
		
		currentXPos = transform.position.x;
		currentYPos = transform.position.y;

		xDir = Input.GetAxisRaw ("Horizontal");
		yDir = Input.GetAxisRaw ("Vertical");
	}


	void Start () {
		//make variables open, then manipulate in updates

		currentXPos = transform.position.x;
		currentYPos = transform.position.y;

		xDir = Input.GetAxisRaw ("Horizontal");
		yDir = Input.GetAxisRaw ("Vertical");
	}
		
	void updatePlayerMovement (){
		
		//Player Rotation, possibly make own function
		Vector2 mouse_pos = Input.mousePosition;
		Vector2 player_pos = Camera.main.WorldToScreenPoint(transform.position);
		float deltaX = mouse_pos.x - player_pos.x;
		float deltaY = mouse_pos.y - player_pos.y;
		float angle = Mathf.Atan2 (deltaX, deltaY) * Mathf.Rad2Deg;
		ship.transform.rotation = Quaternion.Euler (this.transform.eulerAngles.x, this.transform.eulerAngles.y, angle); 
	}




	void Update (){


		currentXPos = transform.position.x;
		currentYPos = transform.position.y;

		xDir = Input.GetAxisRaw ("Horizontal");
		yDir = Input.GetAxisRaw ("Vertical");


	}

	void FixedUpdate () {
		updatePlayerMovement();

		GetComponent<Rigidbody>().AddForce(new Vector3(-xDir * speed * moveModifier, 0, yDir * speed * moveModifier));


	}
}
	



// froze rotation in rigidbody






//credit keith eventually (steal that shit)