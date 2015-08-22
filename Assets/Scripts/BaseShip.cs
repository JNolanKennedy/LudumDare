using UnityEngine;
using System.Collections;

public class BaseShip : MonoBehaviour, ShipInterface {

	public AudioClip Explosion;

	//Hull Points
	protected int HP;
	//Shield
	protected int Shield;
	//Ship Speed
	protected float Speed;
	protected int Charge;
	//Position on the ship the parastite shows up on (0,0) is upper left
	protected Vector2 AttachPoint;
	protected AudioSource source;
	
	public void Shoot()
	{
		this.Charge += (int)Time.deltaTime;
		if (this.Charge >= 2) {
			this.Charge = 0;
		}
	}
	
	public void Move(Vector2 Direction)
	{
		//Takes the direction, multiplies by speed
		this.transform.position += (float)this.Speed * (Vector3)Direction;
	}
	
	public void OnDeath()
	{
		//Change Animation to EXPLOSION!!!!
		this.HP = 0;
		this.source.PlayOneShot(Explosion, 1);
		this.GetComponent<Animator> ().CrossFade ("death", 1);
	}
	
	public void Upgrade()
	{
	}
	
	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "endwall") {
			Destroy (this.gameObject);
		}
	}

	public bool TakeDamage(int val)
	{
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

	public int getShields() 
	{
		return this.Shield;
	}
}
