using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {


	public int health = 100;
	public float minSpeed = 1f;
	public float maxSpeed = 1.5f;
	private float minFragmentSpinSpeed = 30f;
	private float maxFragmentSpinSpeed = 35f;
	private float minFragmentSpeed = 3f;
	private float maxFragmentSpeed = 6f;

	public GameObject AsteroidFragment;


	void spawnAsteroidParticle(){
		GameObject go = Instantiate (AsteroidFragment, transform.position, Quaternion.identity);

		float speed = Random.Range (minFragmentSpeed, maxFragmentSpeed);
		Vector3 randomUnitOnSphere = Random.onUnitSphere;

		go.transform.position = new Vector3 (go.transform.position.x + randomUnitOnSphere.x, go.transform.position.y + randomUnitOnSphere.y, go.transform.position.z);
		go.GetComponent<Rigidbody>().velocity = randomUnitOnSphere * speed;
		go.GetComponent<Rigidbody>().angularVelocity = randomUnitOnSphere * speed;


	}



	void Start() {
		float xSpin = Random.Range(minSpeed, maxSpeed);
		float ySpin = Random.Range(minSpeed, maxSpeed);
		float zSpin = Random.Range(minSpeed, maxSpeed);

		GetComponent < Rigidbody > ().AddTorque (new Vector3 (xSpin, ySpin, zSpin));
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0){
			
			int numberOfParticles = Random.Range (5, 10);

			for (int i = 0; i < numberOfParticles; i++){
				spawnAsteroidParticle();
			}

			Destroy (transform.gameObject);
		}
	}
}
