using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameObject myShip;
	ShipInterface currentShip;
	private bool changing = false;

	// Use this for initialization
	void Start () {
		myShip.tag = "PlayerShip";
		currentShip = myShip.GetComponent (typeof(ShipInterface)) as ShipInterface;
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

	public void SetNewShip(GameObject ship) {
		this.myShip = ship;
		myShip.tag = "PlayerShip";
		this.currentShip = myShip.GetComponent (typeof(ShipInterface)) as ShipInterface;
	}
}
