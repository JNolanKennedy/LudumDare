using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	private bool endPass = false;
	GameObject playerShip;
	PlayerScript playa;
	public string NextLevel;
	private bool istime = false;
	ShipInterface si;

	// Use this for initialization
	void Start () {
	}
	
	void Update () {
		if (endPass == true) {
			this.GetComponent<MeshRenderer>().enabled = true;
			//playa.Eject();
			playerShip = GameObject.FindGameObjectWithTag("PlayerShip");
			si = playerShip.GetComponent (typeof(ShipInterface)) as ShipInterface;
			Destroy(playerShip.GetComponent<Rigidbody2D>());
			playa.enabled = false;
			endPass = false;
			istime = true;
		}
		if (istime)
			si.Move(new Vector2(1, .5f));
	}
	
	public void OnTriggerExit2D(Collider2D coll)
	{
		playa = (GameObject.FindGameObjectWithTag("Player")).GetComponent<PlayerScript>();
		if (coll.gameObject.tag == "endwall" && playa.Alive())
		{
			endPass = true;
		}
	}
	
	public void OnTriggerEnter2D(Collider2D coll) {

		if (coll.gameObject.name == "boundwall2") {
			persistentvars vars = GameObject.Find ("PersistentVarsManager").GetComponent<persistentvars> ();
			vars.loadNext(NextLevel, NextLevel);
		}
	}
}
