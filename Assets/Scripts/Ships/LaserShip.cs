using UnityEngine;
using System.Collections;

public class LaserShip : BaseShip
{
	private float Charge;
	private Vector2 laserpoint;
	private Vector2 endpoint;
	LineRenderer LR;
	private bool Shooting;
	private int Damage;

	// Use this for initialization
	public override void overrideStart() {
		this.HP = 3;
		this.Shield = 0;
		this.Speed = .1f;
		this.AttachPoint = new Vector3(-.15f, -.06f, -1);
		this.Charge = 0;
		this.Damage = 1;
		this.source = this.GetComponent<AudioSource>();
		this.laserpoint = new Vector2 (1f, -.01f);
		this.endpoint = new Vector2 (0f, -10f);
		this.Shooting = false;
		LR = this.gameObject.AddComponent<LineRenderer> ();
		LR.SetWidth (.8f, .8f);
		LR.material = Resources.Load("LAZORBEAM") as Material;
		//Color lazor = new Color (1, .1f, .1f, 1);
		//LR.SetColors (lazor, lazor);
		this.transform.Rotate(new Vector3(0,0,180));
	}

	private void createLaser ()
	{
		LR.enabled = true;
		Vector3 newDirec = this.transform.position + 
			new Vector3(this.transform.right.x * this.laserpoint.x, this.transform.right.y * this.laserpoint.y, 0);
		LR.SetPosition (0, newDirec);

	}

	public override void Shoot()
	{
		this.Shooting = true;
	}

	public override void overrideOnTriggerEnter2D(Collider2D coll)
	{

	}

	public override void overrideUpdate()
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
					if (this.tag == "PlayerShip") {
						if (hit[i].transform.tag == "Enemy") {
							ShipInterface enem = hit[i].transform.gameObject.GetComponent (typeof(ShipInterface)) as ShipInterface;
							enem.TakeDamage (this.Damage);
						}
					}
					else if (this.tag == "Enenmy") {
						if (hit[i].transform.tag == "PlayerShip") {
							ShipInterface playa = hit[i].transform.gameObject.GetComponent (typeof(ShipInterface)) as ShipInterface;
							playa.TakeDamage (this.Damage);
						}
					}
					if(hit[i].transform.name == "boundwall4" || hit[i].transform.name == "boundwall2")
					{
						endpoint = (Vector2)hit[i].point;
					}
				}
				if(this.endpoint.x == 0f && this.endpoint.y == -10f)
				{
					this.endpoint = (Vector2)this.transform.position + new Vector2(100,0);
				}
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
		
		if (this.tag == "PlayerShip" && this.invincablity > 0) {
			this.GetComponent<SpriteRenderer>().color = Color.yellow;
			this.invincablity -= Time.deltaTime;
		}
		else if (this.tag == "PlayerShip" && this.GetComponent<SpriteRenderer>().color != Color.white && this.invincablity <= 0) {
			this.GetComponent<SpriteRenderer>().color = Color.white;
			this.invincablity -= Time.deltaTime;
		}
	}
}
