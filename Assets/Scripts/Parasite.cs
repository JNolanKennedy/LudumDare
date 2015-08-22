using UnityEngine;
using System.Collections;
using System;

public class Parasite : MonoBehaviour, ShipInterface {

	//Hull Points
	private int HP;
	//Shield
	private int Shield;
	//Ship Speed
	private float Speed;
	public GameObject Bullet;
	//Position on the ship the parastite shows up on (0,0) is upper left
	private Vector2 AttachPoint;
	
	// Use this for initialization
	void Start () {
		this.HP = 1;
		this.Shield = 0;
		this.Speed = .1f;
		this.AttachPoint = new Vector2(0, 3);
	}

	public void Shoot()
	{
		;//The parasite cannot shoot!
	}
	
	public void Move(Vector2 Direction)
	{
		//Takes the direction, multiplies by speed
		this.transform.position += (float)this.Speed * (Vector3)Direction;
	}
	
	public bool TakeDamage(int val)
	{
		//Techincally has no shields, but we'll leave this for now.
		if (this.Shield <= 0) {
			this.Shield = 0;
			if (this.HP > 0) {
				this.HP -= val;
			}
		} else {
			this.Shield -= val;
		}
		
		if (this.Shield <= 0) {
			OnDeath();
			return true;
		}
		return false;
	}
	
	public void OnDeath()
	{
		//Change Animation to EXPLOSION!!!!
		this.HP = 0;
	}
	
	void Infect(GameObject ship, ShipInterface enem)
	{
		//remove the AI controller on the ship
		Destroy (ship.GetComponent (typeof(AI)));
		//Flip the ship 180
		ship.transform.rotation = this.transform.rotation;
		ship.GetComponent<BoxCollider2D> ().isTrigger = false;
		//Set the player to control this new ship now.
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<PlayerScript>().SetNewShip(ship);
		//Delete your current ship, the infection guy.
		Destroy (this.gameObject);
	}
	
	public void Upgrade()
	{
	}

	public int getShields() 
	{
		return 0;
	}
	
	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (String.Equals (coll.gameObject.tag, "Enemy")) {
			ShipInterface enem = coll.gameObject.GetComponent (typeof(ShipInterface)) as ShipInterface;
			if (enem.getShields() > 0) {
				this.OnDeath();
			}
			else {
				this.Infect(coll.gameObject, enem);
			}
		}
	}
}
