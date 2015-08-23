using UnityEngine;
using System.Collections;
using System;

public class droneattack : MonoBehaviour {

    public AudioClip shootSound;

    private int Damage;
    private AudioSource source;
    private string Shooter;
    private string Foe;
    private float time = 1f;
    GameObject drone;

    // Use this for initialization
    void Start()
    {
        this.source = this.GetComponent<AudioSource>();
        this.Damage = 1;
        this.source.PlayOneShot(shootSound, 1);
    }

    public void OnShoot(GameObject d, string shooter)
    {
        drone = d;
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
            drone.GetComponent<DroneShipAI>().setCooldown();
            drone.GetComponent<DroneShip>().setSpeed();
            Destroy(this.gameObject);
        }
        else if (coll.gameObject.tag == "endwall")
        {
            drone.GetComponent<DroneShipAI>().setCooldown();
            drone.GetComponent<DroneShip>().setSpeed();
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            drone.GetComponent<DroneShipAI>().setCooldown();
            drone.GetComponent<DroneShip>().setSpeed();
            Destroy(gameObject);
        }
    }
}
