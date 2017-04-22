using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningLaser : MonoBehaviour {


	public int laserDamage = 1;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton(1)){
			Ray ray = new Ray (transform.position, new Vector3 (0f, 1f, 0f));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				// our raycast hit something! :)
				GameObject go = hit.collider.gameObject;
				go.GetComponent < AsteroidController > ().health -= laserDamage;
			}

			GameObject myLine = new GameObject ();
			myLine.transform.position = new Vector3 (0f, 0f, 0f);
			myLine.AddComponent<LineRenderer> ();
			LineRenderer lr = myLine.GetComponent<LineRenderer> ();
			lr.material = new Material (Shader.Find ("Particles/Alpha Blended Premultiply"));
			lr.startColor = Color.red;
			lr.endColor = Color.red;
			lr.startWidth = 0.1f;
			lr.endWidth = 0.1f;
			lr.SetPosition (0, new Vector3 (0f, 0f, 0f));
			lr.SetPosition (1, new Vector3 (0f, 5f, 0f));
		}
	}
}
