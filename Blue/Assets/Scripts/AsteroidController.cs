using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {


	public int health = 100;
	public float minSpeed = 1f;
	public float maxSpeed = 1.5f;

	// Use this for initialization
	void Start() {
		
		float xSpin = Random.Range(minSpeed, maxSpeed);
		float ySpin = Random.Range(minSpeed, maxSpeed);
		float zSpin = Random.Range(minSpeed, maxSpeed);

		GetComponent < Rigidbody > ().AddTorque (new Vector3 (xSpin, ySpin, zSpin));
	}
	
	// Update is called once per frame
	void Update () {
			if (health <= 0){
			Destroy (transform.gameObject);
		}
	}
}
