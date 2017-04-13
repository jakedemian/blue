using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	private float speed = 1f;

	// Use this for initialization
	void Start () {
		
	}

	void ClearConsole () {
		// This simply does "LogEntries.Clear()" the long way:
		var logEntries = System.Type.GetType("UnityEditorInternal.LogEntries,UnityEditor.dll");
		var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
		clearMethod.Invoke(null,null);
	}

	// Update is called once per frame

	void Update () {
		//Player Movement
		ClearConsole();
		if (Input.GetKey (KeyCode.W)) {
			transform.position = new Vector2 (transform.position.x, transform.position.y + speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position = new Vector2 (transform.position.x, transform.position.y - speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position = new Vector2 (transform.position.x - speed * Time.deltaTime, transform.position.y);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position = new Vector2 (transform.position.x + speed * Time.deltaTime, transform.position.y);
		}

		//Player Rotation
		Vector2 mouse_pos = Input.mousePosition;
		Vector2 player_pos = Camera.main.WorldToScreenPoint(transform.position);
		float deltaX = mouse_pos.x - player_pos.x;
		float deltaY = mouse_pos.y - player_pos.y;
		float angle = Mathf.Atan2 (deltaX, deltaY) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, -angle);
		Debug.Log ("angle  " + angle);
		Debug.Log ("mouse  " + mouse_pos);
		Debug.Log ("player " + player_pos);





	}
}
	