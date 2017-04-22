using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {


	public int health = 100;


	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		Debug.Log(health);
		if(health <= 0) {
			Destroy(transform.gameObject);
		}
	}
}
