using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBreather : MonoBehaviour {

	[SerializeField] private float maxSize = 1.25f;
	[SerializeField] private float minSize = 0.75f;
	[SerializeField] private float growthFactor = 1.0f;
	
	private float currentSize = 1.0f;

	private void Update() {
		if (gameObject.activeSelf)
		{
			var range = maxSize - minSize;
			float value = (float) ((Mathf.Sin(Time.time * growthFactor) + 1.0)
			                       / 2.0 * range + minSize);
			gameObject.transform.localScale = new Vector3(value, value, value);
		}
	}
}
