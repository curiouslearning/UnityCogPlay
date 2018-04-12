using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFall : MonoBehaviour {
	Vector2 startPos;
	Vector2 endPos;
	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
		endPos = GameObject.Find ("Monster").transform.position;
		iTween.MoveTo (this.gameObject, endPos, 3f);

	}
	
	// Update is called once per frame
	void Update () {
		
		/*//increment timer once per frame
		currentLerpTime += Time.deltaTime;
		if (currentLerpTime > lerpTime) {
			currentLerpTime = lerpTime;
		}

		//lerp!
		float t = currentLerpTime / lerpTime;
		t = t * t * (3f - 2f * t);
		transform.position = Vector2.Lerp(startPos, endPos, t);*/
	}	

} //(-5.72, -4.13, 0)
