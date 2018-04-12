using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
	public float velocity;
	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		body.velocity = new Vector2 (0, velocity);	
	}
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.name == "GarbageCollector") {
			Destroy (this.gameObject);
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
