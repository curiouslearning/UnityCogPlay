using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverPattern;
using UnityEngine.SceneManagement;

public class GameController : Observer {
	float gameStartTime;
	const float timeout = 60000f;
	const float STEP_SIZE = 0.2f;
	List <bool>  targetPopped = new List <bool> ();
	enum stepDirection {FASTER, SLOWER, NEITHER};
	stepDirection currentDirection;
	float currentVelocity;
	public BubbleSpawner machine;
	public Subject monster;
	public Subject garbageCollector;
	// Use this for initialization
	void Awake (){
		gameStartTime = Time.time;
	}
	void Start () {
		currentDirection = stepDirection.NEITHER;
		monster.AddObserver (this);
		garbageCollector.AddObserver (this);
		currentVelocity = Screen.height / 10;
		
	}
	public override void onNotify (InputEvents e) { 
		if (e == InputEvents.CorrectInput) {
			targetPopped.Add (true);
		} else if (e == InputEvents.IncorrectInput) {
			targetPopped.Add (false);
		}
		currentDirection = fasterOrSlower ();
		currentVelocity = updateVelocity (currentDirection);
		machine.updateVelocity (currentVelocity);

	}
	public override void onNotify () {}

	stepDirection fasterOrSlower () {
		int len = targetPopped.Count;
		if (!targetPopped [len - 1]) {
			return stepDirection.SLOWER;
		}
		if (len < 2) {
			return stepDirection.NEITHER;
		}
		if (targetPopped [len - 1] && targetPopped [len - 2]) {
			targetPopped.Clear ();
			return stepDirection.FASTER;
		}
		return stepDirection.NEITHER;
	}

	float updateVelocity (stepDirection currentDirection) {
		switch (currentDirection) {
		case stepDirection.FASTER:
			return (currentVelocity + currentVelocity * STEP_SIZE);
		case stepDirection.SLOWER:
			return (currentVelocity - currentVelocity * STEP_SIZE);
		case stepDirection.NEITHER:
			return currentVelocity;
		default:
			return currentVelocity;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - gameStartTime >= timeout) {
			SceneManager.UnloadSceneAsync ("BubblePop");
		}
	}
}
