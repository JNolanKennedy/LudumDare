using UnityEngine;
using System.Collections;

public class DroneShip : BaseShip {
    GameObject player;
    private bool Shooting;
	public GameObject Bullet;
	private float time = 1f;

    // Use this for initialization   
    void Start()
    {
        this.HP = 1;
        this.Shield = 1;
        this.Speed = .1f;
        this.AttachPoint = new Vector2(0, 3);
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
			BulletClass BI = clone.GetComponent (typeof(BulletClass)) as BulletClass;
			BI.OnShoot(this.tag);
			this.time = 5f;
        }

    }

    public void setSpeed()
    {
        Speed = .1f;
        Shooting = false;
    }

    public override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "PlayerShip")
        {
            OnDeath();
        }
        else if (coll.tag == "boundwall")
        {
            OnDeath();
        }
    }

	void Update()
	{
		if (this.time > 0)
			this.time -= Time.deltaTime;
		if (this.time < 4 && this.time > 3) {
			this.setSpeed ();
			this.Shooting = false;
		}
	}
}
