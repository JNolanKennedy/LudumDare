using UnityEngine;
using System.Collections;

public class DroneShip : BaseShip {

    GameObject player;
    private bool Shooting;
	public GameObject Bullet;
	private float time = 1f;
    float cooldown = 1;

    // Use this for initialization   
    public override void overrideStart()
    {
        this.HP = 1;
        this.Shield = 1;
        this.Speed = .1f;
        this.AttachPoint = new Vector3(-.5f, -.4f, -1);
        this.Shooting = false;
        this.source = this.GetComponent<AudioSource>();
        player = GameObject.Find("Player");
    }

    public override void Shoot()
    {
        if (!this.Shooting && time <= 0f)
        {
            this.Shooting = true;
            Speed = 0;
            GameObject clone = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
			BaseBullet BI = clone.GetComponent (typeof(BaseBullet)) as BaseBullet;
			BI.OnShoot(this.tag);
			this.time = 2.5f;
        }
    }

    public void setSpeed()
    {
        Speed = .1f;
        Shooting = false;
    }

    public override void overrideOnTriggerEnter2D(Collider2D coll)
    {

    }
    public override float getCooldown()
    {
        return cooldown;
    }
	public override void overrideUpdate()
	{
		if (this.time > 0)
			this.time -= Time.deltaTime;
		if (this.time < 1 && this.time > 0) {
			this.setSpeed ();
			this.Shooting = false;
		}
	}
}
