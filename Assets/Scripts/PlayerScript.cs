using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameObject myShip;
	public GameObject paraShip;
	ShipInterface currentShip;
	//private bool changing = false;
	private bool pause;
    float cooldown;

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
			if (Input.GetButton ("Jump") || Input.GetButton ("Fire1")) {
                if (cooldown <= 0)
                {
                    currentShip.Shoot();
                    cooldown = currentShip.getCooldown();
                }
			} else if (Input.GetButtonDown ("Eject") && !this.currentShip.getIsParasite()) {
				this.Eject();
			}
            cooldown -= Time.deltaTime;
		}

		if (myShip == null) {
			gameOver();
			Destroy(this);
		}

	}

	public void Eject()
	{
		GameObject newPara = Instantiate(paraShip, myShip.transform.position, myShip.transform.rotation) as GameObject;
		currentShip.OnDeath();
		this.SetNewShip(newPara);
	}

	public bool Alive()
	{
		if (this.currentShip.getHP () > 0) {
			return true;
		}
		return false;
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

	private void gameOver()
	{
		persistentvars vars = GameObject.Find ("PersistentVarsManager").GetComponent<persistentvars> ();
		vars.storeLevel (Application.loadedLevel);
		vars.loadBetween ();
		                                                                                   
	}
}
