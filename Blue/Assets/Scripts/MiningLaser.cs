using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningLaser : MonoBehaviour {


	public int laserDamage = 1;
	private GameObject laserLine;
	public GameObject ship;
	public int miningLaserHittableLayer = 1 << 8;


	// Use this for initialization
	void Start() {
		
	}

	void Update() {
		transform.localRotation = ship.transform.localRotation;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if(laserLine != null) {
			Destroy(laserLine);
		}

		if(Input.GetMouseButton(1)) {
			Ray ray = new Ray(transform.position, transform.up);
			RaycastHit hit;
			Vector3 hitPosition = Vector3.zero;
			if(Physics.Raycast(ray, out hit, Mathf.Infinity, miningLaserHittableLayer)) {
				GameObject go = hit.collider.gameObject;
				go.GetComponent < AsteroidController >().health -= laserDamage;

				hitPosition = hit.point;
			}

			drawMiningLaserLine(hitPosition);
		}
	}

	void drawMiningLaserLine(Vector3 hitPos) {
		if(laserLine != null) {
			Destroy(laserLine);
		}		

		laserLine = new GameObject();
		laserLine.transform.position = new Vector3(0f, 0f, 0f);
		laserLine.AddComponent<LineRenderer>();

		LineRenderer lr = laserLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.startColor = Color.red;
		lr.endColor = Color.red;
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;
		lr.SetPosition(0, transform.position);

		if(hitPos != Vector3.zero) {
			lr.SetPosition(1, hitPos);
		} else {
			lr.SetPosition(1, transform.position + (transform.up * 30));
		}
	}
}
