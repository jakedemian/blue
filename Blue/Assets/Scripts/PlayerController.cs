using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Image currentHealth;
	public Text ratioText;

	public int currentPlayerHealth = 100;
	public int maxPlayerHealth = 100;

	void Start(){
		UpdateHealthbar ();
	}

	void OnGUI(){
		UpdateHealthbar ();
	}
		
	void UpdateHealthbar(){
		float ratio = (float) currentPlayerHealth / (float) maxPlayerHealth;
		currentHealth.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		ratioText.text = (ratio * 100).ToString ("0") + '%';
	}


	void Update(){
		if (currentPlayerHealth > maxPlayerHealth){
			currentPlayerHealth = maxPlayerHealth;
		
		} else if (currentPlayerHealth < 0){
			currentPlayerHealth = 0;
		}

	}



}
