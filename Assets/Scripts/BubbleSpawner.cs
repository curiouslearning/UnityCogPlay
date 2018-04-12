using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverPattern;

public class BubbleSpawner : Observer {
	bool running;
	bool targetBubbleActive;
	AudioSource audio;
	public GameObject[] targetBubbleArray;
	public GameObject[] standardBubbleArray;
	public Transform spawnPoint;
	public Subject lever;
	public Subject garbageCollector;
	public float spawnInterval;
	public float offsetMax;

	public GameObject topOfFountain;
	float targetVelocity;
	float distanceTraveled;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		lever.AddObserver (this);
		garbageCollector.AddObserver (this);
		running = false;
		targetBubbleActive = false;
		targetVelocity = Screen.height/10;
		distanceTraveled = Screen.height - Camera.main.WorldToScreenPoint (topOfFountain.transform.position).y;
	}

	public override void onNotify (InputEvents e) {
		if (e == InputEvents.InputBegan) {
			running = true;
			StartCoroutine (startMachine ());
		} else if (e == InputEvents.InputEnded) {
			running = false;
			StopCoroutine (startMachine ());
		} else if (e == InputEvents.IncorrectInput) {
			targetBubbleActive = false;
		}
	}
	public override void onNotify () {
		audio.Play ();
		targetBubbleActive = false;
	}

	public void updateVelocity (float newVelocity) {
		updateVelocityInternal (newVelocity);
	}

	void updateVelocityInternal (float newVelocity) {
		targetVelocity = newVelocity;
	}

	IEnumerator startMachine () {
		while (running) {
			spawnBubble ();
			yield return new WaitForSeconds (spawnInterval);
		}
	}
	void spawnBubble(){
		bool displayTargetBubble = Random.value < 0.25;
		bool createTargetBubble = displayTargetBubble && !targetBubbleActive;
		if (createTargetBubble) {
			spawnTargetBubble ();
		} else {
			spawnStandardBubble ();
		}
	}

	void spawnStandardBubble () {
		int rangeMax = standardBubbleArray.Length - 1;
		int size = Random.Range (0, rangeMax);
		float offset = Random.Range ((offsetMax * -1), offsetMax);
		Vector3 newPos = new Vector3 (spawnPoint.position.x + offset, spawnPoint.position.y, spawnPoint.position.z+1);
		GameObject bubble = Instantiate (standardBubbleArray[size], newPos, spawnPoint.rotation);
	}

	void spawnTargetBubble () {
		int rangeMax = targetBubbleArray.Length - 1;
		int type = Random.Range (0, rangeMax);
		GameObject bubble = Instantiate (targetBubbleArray [type], spawnPoint.position, spawnPoint.rotation) as GameObject;
		bubble.GetComponent<TargetBubble> ().setDuration (distanceTraveled/targetVelocity);
		targetBubbleActive = true;
		bubble.GetComponent<Subject> ().AddObserver (this);	
	}
	void OnDestroy () {
		lever.RemoveObserver (this);
	}
	// Update is called once per frame
	void Update () {
	}
}
