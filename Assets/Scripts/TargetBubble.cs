using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverPattern;

public class TargetBubble : MonoBehaviour {
	Subject eventSystem;
	Animator anim;
	Rigidbody2D body;
	public GameObject popFood;
	public float duration;
	Vector3 endPos;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		endPos = new Vector3 (0.43f, 6.58f, this.transform.position.z);
		eventSystem = GetComponent<Subject> ();
		anim = GetComponent<Animator> ();
//		iTween.MoveTo (this.gameObject, endPos, duration);
		iTween.MoveTo (this.gameObject, iTween.Hash (
			"position" , endPos,
			"time", duration,
			"easetype" , iTween.EaseType.linear));
	}

	public void setDuration(float v) {
		duration = v;
	}

	void pop () {
		GameObject go =	Instantiate (popFood, this.transform.position, this.transform.rotation) as GameObject;
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.name == "GarbageCollector") {
			Destroy (this.gameObject);
		}
	}

	public void OnMouseDown (){
		eventSystem.notify ();
		pop ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
