﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;

	void Start () {
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
	}
	
	void Update () {
		if(transform.position != target.transform.position){
			transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
		}
	}
}
