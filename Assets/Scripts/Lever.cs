using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverPattern;

public class Lever : MonoBehaviour {

	Subject eventSystem;
	InputEvents eventList;
	BoxCollider2D leverTip;
	Animator anim;
	float idleCount;
	float startTime;
	BubbleSpawner parent;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		eventSystem = GetComponent<Subject> ();
		leverTip = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator>();
		idleCount = Time.time;
		parent = GetComponentInParent<BubbleSpawner> ();
		
	}

	public void OnMouseDown() {
		anim.SetBool ("LeverPress", true);
		audio.Play();
		idleCount = Time.time;
		startTime = Time.time;
		InputEvents e = InputEvents.InputBegan;
		eventSystem.notify (e);
		//parent.spawnBubble ();

	}

	public void OnMouseUp () {
		anim.SetBool ("LeverPress", false);	
		InputEvents e = InputEvents.InputEnded;
		eventSystem.notify (e);
	}
	// Update is called once per frame
	void Update () {
		/*if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			anim.SetBool ("LeverPress", true);
			idleCount = Time.time;
			startTime = Time.time;	
		} else if (Input.touchCount> 0 && Input.GetTouch (0).phase == TouchPhase.Ended){
			anim.SetBool ("LeverPress", false);	
		}
		if (idleCount-startTime > 5.00) {
			anim.SetTrigger ("Wiggle");
			idleCount = Time.time;
			startTime = Time.time;
		} else {*/
			idleCount+= Time.deltaTime;		
		//}
	}
}
