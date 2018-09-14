using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour {

	private void Start() {
		Destroy(gameObject, 4.0f);
	}

	private void OnTriggerEnter(Collider other) {
        /*
		if (other.CompareTag("Enemy")) {
			Destroy(gameObject);
		}
        */
	}
}
