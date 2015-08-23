using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameObject myShip;
	public GameObject paraShip;
	ShipInterface currentShip;
	private bool changing = false;
	private bool pause;

	// Use this for initialization
	void Start () {
		myShip.tag = "PlayerShip";
		GameObject.Find ("GameManager").GetComponent<PauseManager> ().registerObject (this.gameObject);
		currentShip = myShip.GetComponent (typeof(ShipInterface)) as ShipInterface;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!pause)
			currentShip.Move (new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")));
	}

	void Update ()
	{
		if (!pause) {
			if (Input.GetButtonDown ("Jump") || Input.GetButtonDown ("Fire1")) {
				currentShip.Shoot ();
			} else if (Input.GetButtonDown ("Eject") && !this.currentShip.getIsParasite()) {
				GameObject newPara = Instantiate(paraShip, myShip.transform.position, myShip.transform.rotation) as GameObject;
				currentShip.OnDeath();
				this.SetNewShip(newPara);
			}
		}
	}

	public void SetNewShip(GameObject ship) {
		this.myShip = ship;
		myShip.tag = "PlayerShip";
		this.currentShip = myShip.GetComponent (typeof(ShipInterface)) as ShipInterface;
	}

	private void PauseHandler()
	{
		if (pause == false)
			pause = true;
		else
			pause = false;
	}
}
