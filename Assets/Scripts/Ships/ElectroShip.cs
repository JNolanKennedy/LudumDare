using UnityEngine;
using System.Collections;

public class ElectroShip : BaseShip 
{
	public GameObject Bullet;

    private GameObject player;
    private bool Shooting;

	// Use this for initialization
	public override void overrideStart() {
		this.HP = 3;
		this.Shield = 3;
		this.Speed = .1f;
		this.AttachPoint = new Vector2(0, 3);
        this.Shooting = false;
		this.source = this.GetComponent<AudioSource>();
        this.player = GameObject.Find("Player");
	}

	public override void Shoot() 
	{
        if (!this.Shooting)
        {
            this.Shooting = true;
            GameObject clone = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
            BulletInterface BI = clone.GetComponent(typeof(BulletInterface)) as BulletInterface;
            BI.OnShoot(transform.right, this.tag);
            this.Shooting = false;
        }
	}
}