using UnityEngine;
using System.Collections;

public class BasicAIBehavior : MonoBehaviour, AI {
	ShipInterface currentShip;

	// Use this for initialization
	void Start () {
		currentShip = this.GetComponent (typeof(ShipInterface)) as ShipInterface;
		this.transform.Rotate (Vector3.forward * 180);
	
	}
	
	// Update is called once per frame
	void Update () {
		currentShip.Move (new Vector2(-1, 0));
	
	}

	public void Infect () {
		//do nothing
	}
}
