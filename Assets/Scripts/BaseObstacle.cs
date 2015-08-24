using UnityEngine;
using System.Collections;
using System;

public class BaseObstacle : MonoBehaviour {
	private Boolean passWall = false;

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (String.Equals (coll.gameObject.tag, "PlayerShip")) {
			ShipInterface player = coll.gameObject.GetComponent (typeof(ShipInterface)) as ShipInterface;
			player.TakeDamage (1);
		} else if (coll.gameObject.tag == "endwall" & passWall == true) {
			Destroy (this.gameObject);
		} else if (coll.gameObject.tag == "endwall"){
			this.passWall = true;
		}
	}
}