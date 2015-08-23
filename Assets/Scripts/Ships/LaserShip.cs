﻿using UnityEngine;
using System.Collections;

public class LaserShip : BaseShip
{
	private float Charge;
	private Vector2 laserpoint;
	private Vector2 endpoint;
	LineRenderer LR;
	private bool Shooting;

	// Use this for initialization
	public override void overrideStart() {
		this.HP = 3;
		this.Shield = 1;
		this.Speed = .1f;
		this.AttachPoint = new Vector2(0, 3);
		this.Charge = 0;
		this.source = this.GetComponent<AudioSource>();
		this.laserpoint = new Vector2 (1f, -.01f);
		this.endpoint = new Vector2 (0f, -10f);
		this.Shooting = false;
		LR = this.gameObject.AddComponent<LineRenderer> ();
		LR.SetWidth (.8f, .8f);
	}

	private void createLaser ()
	{
		LR.enabled = true;
		LR.SetPosition (0, this.transform.position+(Vector3)this.laserpoint);
	}

	public override void Shoot()
	{
		this.Shooting = true;
	}

    //adf
	public override void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Enemy" && this.tag == "PlayerShip") {
			ShipInterface si = coll.gameObject.GetComponent(typeof(ShipInterface)) as ShipInterface;
			si.TakeDamage(1);
		}
	}

	public void Update()
	{
		if (this.Shooting) {
			this.Speed = 0f;
			this.Charge += Time.deltaTime;
			if (this.Charge >= 1) {
				this.createLaser();
				this.Speed = 0;
				RaycastHit2D[] hit = Physics2D.RaycastAll(this.transform.position, this.transform.right, 200f);
				int size = hit.Length;
				for(int i = 0; i < size; i++) {
					if(hit[i].transform.name == "boundwall4" || hit[i].transform.name == "boundwall2")
					{
						endpoint = (Vector2)hit[i].point;
						Debug.Log("HERE: " + endpoint);
					}
				}
				if(this.endpoint.x == 0f && this.endpoint.y == -10f)
				{
					this.endpoint = (Vector2)this.transform.position + new Vector2(100,0);
				}
				Debug.Log("THERER: " + endpoint);
				LR.SetPosition(1, (Vector3)endpoint);
			}
			if (this.Charge >= 2) {
				LR.enabled = false;
				this.Charge = 0;
				this.Speed = .1f;
				this.Shooting = false;
				this.endpoint = new Vector2 (0f, -10f);
			}
		}
	}
}
