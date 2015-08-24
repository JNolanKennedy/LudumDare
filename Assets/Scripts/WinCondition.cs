using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	private bool endPass = false;
	GameObject playerShip;

	// Use this for initialization
	void Start () {
	}
	
	void Update () {
		if (endPass == true) {
			this.GetComponent<MeshRenderer>().enabled = true;
			PlayerScript playa = (GameObject.FindGameObjectWithTag("Player")).GetComponent<PlayerScript>();
			//playa.Eject();
			playerShip = GameObject.FindGameObjectWithTag("PlayerShip");
			ShipInterface si = playerShip.GetComponent (typeof(ShipInterface)) as ShipInterface;
			Destroy(playerShip.GetComponent<Rigidbody2D>());
			si.Move(new Vector2(1, .5f));
			playa.enabled = false;
		}
	}
	
	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "endwall")
		{
			endPass = true;
		}
	}
	
	public void OnTriggerEnter2D(Collider2D coll) {

		if (coll.gameObject.name == "boundwall2") {
			if (Application.loadedLevelName == "level1") {
				Application.LoadLevel("level3");
			}
		}
	}
}
