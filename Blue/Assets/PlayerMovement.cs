using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public GameObject ship;

	private float speed = 5f;
	private float maxTurnSpeed = 5f;
	private float currentTurnSpeed = 0f;
	private float turnSpeedDamping = 25f;

	public float moveModifier = 1;

	float currentXPos;
	float currentYPos;

	float xDir;
	float yDir;

	/**
	 * START
	 */
	void Start() {
		updatePositionVars();
	}

	/**
	 * FIXED UPDATE
	 */
	void FixedUpdate() {
		updatePlayerRotation();

		// update player speed
		GetComponent<Rigidbody>().AddForce(new Vector3(xDir * speed * moveModifier, yDir * speed * moveModifier, 0));
	}

	/**
	 * Update the player's position variables.
	 */
	void updatePositionVars() {		
		currentXPos = transform.position.x;
		currentYPos = transform.position.y;

		xDir = Input.GetAxisRaw("Horizontal");
		yDir = Input.GetAxisRaw("Vertical");
	}

	/**
	 * Handle player movement and rotation.
	 */
	void updatePlayerRotation() {
		updatePositionVars();

		//Player Rotation, possibly make own function
		Vector2 mouse_pos = Input.mousePosition;
		Vector2 player_pos = Camera.main.WorldToScreenPoint(transform.position);
		float deltaX = mouse_pos.x - player_pos.x;
		float deltaY = mouse_pos.y - player_pos.y;
		float angle = Mathf.Atan2(deltaX, deltaY) * Mathf.Rad2Deg;

		// convert -180 to 180 angle to a 0 to 360 angle
		if(angle < 0f) {
			angle += 360f;
		}

		float currentShipAngle = ship.transform.rotation.eulerAngles.z;
		float goalShipAngle = angle;

		float ccw = -1f;
		float cw = -1f;
		if(currentShipAngle > goalShipAngle) {
			ccw = currentShipAngle - goalShipAngle;
			cw = (360f - currentShipAngle) + goalShipAngle;
		} else if(currentShipAngle < goalShipAngle) {
			ccw = (360f - goalShipAngle) + currentShipAngle;
			cw = goalShipAngle - currentShipAngle;
		}

		if(cw != -1f && ccw != 1f) {
			if(ccw <= cw) {
				// rotate ccw
				currentTurnSpeed = ccw / (-1f * turnSpeedDamping);
				if(currentTurnSpeed <= maxTurnSpeed * -1) {
					currentTurnSpeed = maxTurnSpeed * -1;
				}
			} else {
				// rotate cw
				currentTurnSpeed = cw / turnSpeedDamping;
				if(currentTurnSpeed >= maxTurnSpeed) {
					currentTurnSpeed = maxTurnSpeed;
				}
			}
			ship.transform.Rotate(new Vector3(0, 0, currentTurnSpeed));
		}

	}
}