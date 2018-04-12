using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverPattern;

public class GarbageCollector : MonoBehaviour {

	Subject eventSystem;
	// Use this for initialization
	void Start () {
		eventSystem = GetComponent<Subject> ();
		
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.tag == "target"){
			eventSystem.notify(InputEvents.IncorrectInput);
		}
		Destroy (c.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
