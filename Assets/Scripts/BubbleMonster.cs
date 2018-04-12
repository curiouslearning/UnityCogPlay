using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverPattern;

public class BubbleMonster : MonoBehaviour {

	public Vector3 endPos;
	public float walkTime;
	Animator anim;
	Subject eventSystem;
	AudioSource audio;
	float timer = 0f;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		eventSystem = GetComponent<Subject> ();
		anim = GetComponent<Animator> ();
		anim.SetBool("MonsterWalk", true);
//		iTween.MoveTo (this.gameObject, endPos, speed);	
		iTween.MoveTo( this.gameObject, iTween.Hash(
			"position"    , endPos,
			"time"    , walkTime,
			"easeType", iTween.EaseType.linear));
		timer = 0f;
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.tag == "food" && timer >= 1f) {
			anim.SetTrigger ("MonsterAccept");
			Destroy (c.gameObject, 0.25f);
			eventSystem.notify (InputEvents.CorrectInput);
			timer = 0f;
		}
	}
	public void celebrateAudio() {
		audio.Play ();
	}
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x >= (endPos.x - 0.3f)) {
			anim.SetBool ("MonsterWalk", false);
		}
		timer += Time.deltaTime;
	}
}
