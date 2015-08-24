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
			//this.transform.position = 
			playerShip = GameObject.FindGameObjectWithTag("PlayerShip");
			//playerShip.GetComponent<PlayerScript>().enabled = false;
			ShipInterface si = playerShip.GetComponent (typeof(ShipInterface)) as ShipInterface;
			Destroy(playerShip.GetComponent<Rigidbody2D>());
			si.Move(new Vector2(1, .5f));
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
			Debug.Log ("YOU ARE THE WINNERIST:  " + coll.name);
			//Go to next level or end the game or whatever.
			Application.Quit();
		}
	}
}
