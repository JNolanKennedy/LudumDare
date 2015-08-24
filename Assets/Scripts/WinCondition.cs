using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	private bool endPass = false;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		if (endPass == true) {
			Debug.Log ("YOU ARE THE WINNERIST");
		}
	}
	
	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "endwall")
		{
			endPass = true;
		}
	}
}
