using UnityEngine;
using System.Collections;
using System;

public class droneattack : BulletClass {

    // Use this for initialization
    void Start()
    {
        this.source = this.GetComponent<AudioSource>();
        this.Damage = 1;
        this.source.PlayOneShot(shootSound, 1);
    }

    public override void OnShoot(string shooter)
    {
        this.Shooter = shooter;
        if (this.Shooter == "PlayerShip")
        {
            this.Foe = "Enemy";
        }
        else
        {
            this.Foe = "PlayerShip";
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (String.Equals(coll.gameObject.tag, this.Foe))
        {
            ShipInterface enem = coll.gameObject.GetComponent(typeof(ShipInterface)) as ShipInterface;
            enem.TakeDamage(this.Damage);
            //drone.GetComponent<DroneShipAI>().setCooldown();
            //Destroy(this.gameObject);
        }
		Destroy (this.gameObject, 1);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
