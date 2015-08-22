using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject myShip;
	BehaviorInterface currentShip;

	// Use this for initialization
	void Start () {
		myShip.tag = "PlayerShip";
		currentShip = myShip.GetComponent (typeof(BehaviorInterface)) as BehaviorInterface;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentShip.Move (new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")));
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Jump")) 
		{
			currentShip.Shoot ();
		}
	}
}
