using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern{
	public enum InputEvents {CorrectInput, IncorrectInput, InputBegan, InputEnded};
	public class Subject : MonoBehaviour {

		List<Observer> observers = new List<Observer> (); 
		public void notify () {
			for (int i = 0; i < observers.Count; i++) {
				observers [i].onNotify ();
			}
		}

		public void notify (InputEvents e) {
			for (int i = 0; i < observers.Count; i++) {
				observers [i].onNotify (e);
			}
		}

		public void AddObserver(Observer observer)
		{
			observers.Add(observer);
		}

		public void RemoveObserver(Observer observer)
		{
			observers.Remove (observer);

		}
		void onDestroy () {
			observers.Clear ();
		}
	}
}