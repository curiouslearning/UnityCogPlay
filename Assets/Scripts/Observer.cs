using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{


	public abstract class Observer : MonoBehaviour {

		public abstract void onNotify (InputEvents  e);
		public abstract void onNotify ();

	}

	public abstract class MachineEvents
	{
		public abstract void CorrectInput ();
		public abstract void IncorrectInput ();
		public abstract void InputBegan ();
		public abstract void InputEnded ();
	}

	public class Machine : Observer {
		GameObject machineObj;

		MachineEvents machineEvent;
		public override void onNotify () {}
		public override void onNotify (InputEvents e) {}
	}

}