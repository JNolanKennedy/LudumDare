using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameObject myShip;
	public GameObject paraShip;
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
		if (Input.GetButtonDown ("Jump")) {
			currentShip.Shoot ();
		} else if (Input.GetButtonDown ("Eject") && !this.currentShip.getIsParasite()) {
			GameObject newPara = Instantiate(paraShip, myShip.transform.position, myShip.transform.rotation) as GameObject;
			currentShip.OnDeath();
			myShip = newPara;
			currentShip = myShip.GetComponent (typeof(ShipInterface)) as ShipInterface;
		}
	}

	public void SetNewShip(GameObject ship) {
		this.myShip = ship;
		myShip.tag = "PlayerShip";
		this.currentShip = myShip.GetComponent (typeof(ShipInterface)) as ShipInterface;
	}
}
