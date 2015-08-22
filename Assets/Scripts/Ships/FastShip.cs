﻿using UnityEngine;
using System.Collections;

public class FastShip : MonoBehaviour, ShipInterface
{
	public AudioClip Explosion;

	//Hull Points
	private int HP;
	//Shield
	private int Shield;
	//Ship Speed
	private float Speed;
	private bool Shooting;
	public GameObject Bullet;
	//Position on the ship the parastite shows up on (0,0) is upper left
	private Vector2 AttachPoint;
	private AudioSource source;
	
	// Use this for initialization
	void Start () {
		this.HP = 3;
		this.Shield = 0;
		this.Speed = .2f;
		this.AttachPoint = new Vector2(0, 3);
		this.Shooting = false;
		this.source = this.GetComponent<AudioSource>();
	}
	
	public void Shoot()
	{
		if (!this.Shooting) {
			this.Shooting = true;
			GameObject clone = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
			BulletInterface BI = clone.GetComponent (typeof(BulletInterface)) as BulletInterface;
			BI.OnShoot(transform.right, this.tag);
			this.Shooting = false;
		}
	}
	
	public void Move(Vector2 Direction)
	{
		//Takes the direction, multiplies by speed
		this.transform.position += (float)this.Speed * (Vector3)Direction;
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
	
	public void OnDeath()
	{
		//Change Animation to EXPLOSION!!!!
		this.HP = 0;
		this.source.PlayOneShot(Explosion, 1);
		this.GetComponent<Animator> ().CrossFade ("death", .05f);
		this.GetComponent<BoxCollider2D> ().enabled = false;
		Destroy(this.gameObject, 1f);
	}
	
	public void Upgrade()
	{
	}

	public int getShields() 
	{
		return this.Shield;
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "endwall") {
			Destroy (this.gameObject);
		}
	}
}

