using UnityEngine;
using System.Collections;

public class DroneShip : BaseShip {
    GameObject player;
    private bool Shooting;
	public GameObject Bullet;

    // Use this for initialization   
    void Start()
    {
        this.HP = 1;
        this.Shield = 1;
        this.Speed = .15f;
        this.AttachPoint = new Vector2(0, 3);
        this.Shooting = false;
        this.source = this.GetComponent<AudioSource>();
        player = GameObject.Find("Player");
    }

    public override void Shoot()
    {

        if (!this.Shooting)
        {
            this.Shooting = true;
            Speed = 0;
            GameObject clone = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
            droneattack BI = clone.GetComponent<droneattack>();
            BI.OnShoot(gameObject, this.tag);
        }
    }

    public void setSpeed()
    {
        Speed = .15f;
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
}
