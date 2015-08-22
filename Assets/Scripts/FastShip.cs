using UnityEngine;
using System.Collections;

public class FastShip : MonoBehaviour, BehaviorInterface
{
	//Hull Points
	private int HP;
	//Shield
	private int Shield;
	//Ship Speed
	private float Speed;
	//Damage the ship can do
	private int Damage;
	private bool Shooting;
	public GameObject Bullet;
	//Position on the ship the parastite shows up on (0,0) is upper left
	private Vector2 AttachPoint;
	
	// Use this for initialization
	void Start () {
		this.HP = 3;
		this.Shield = 1;
		this.Speed = .2f;
		this.Damage = 2;
		this.AttachPoint = new Vector2(0, 3);
		this.Shooting = false;
	}
	
	public void Shoot()
	{
		if (!this.Shooting) {
			this.Shooting = true;
			GameObject clone = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
			Rigidbody rb = clone.GetComponent(typeof(Rigidbody)) as Rigidbody;
			rb.AddForce(this.transform.forward*5f);

			//BulletInterface BI = clone.GetComponent (typeof(BulletInterface)) as BulletInterface;
			//BI.OnShoot((Vector2)this.transform.forward);
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
	}
	
	public void Infect()
	{
	}
	
	public void Upgrade()
	{
	}
}

