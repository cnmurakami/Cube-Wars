using UnityEngine;
using System.Collections;

public class RotatingY : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate() {
		this.transform.Rotate(0, -2f, 0*Time.deltaTime);

	}
}
