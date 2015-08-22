using UnityEngine;
using System.Collections;

public class DroneShip : MonoBehaviour, ShipInterface {

    public AudioClip Explosion;

    //Hull Points
    private int HP;
    //Shield
    private int Shield;
    //Ship Speed
    private float Speed;
    //Position on the ship the parastite shows up on (0,0) is upper left
    private Vector2 AttachPoint;
    private AudioSource source;
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

    public void Shoot()
    {

        if (!this.Shooting)
        {
            this.Shooting = true;
            Debug.Log("test");
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

    public void Move(Vector2 Direction)
    {
        //Takes the direction, multiplies by speed
        this.transform.position += (float)this.Speed * (Vector3)Direction;
    }

    public bool TakeDamage(int val)
    {
        if (this.Shield <= 0)
        {
            Speed = 0;
            this.Shield = 0;
            if (this.HP > 0)
            {
                this.HP -= val;
            }
        }
        else
        {
            this.Shield -= val;
        }

        if (this.HP <= 0)
        {
            this.OnDeath();
            return true;
        }
        return false;
    }

    public void OnDeath()
    {
        Debug.Log("test");
        //Change Animation to EXPLOSION!!!!
        this.HP = 0;
        this.source.PlayOneShot(Explosion, 1);
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
        if (coll.tag == "PlayerShip")
        {
            this.OnDeath();
        }
        else if (coll.tag == "boundwall")
        {
            this.OnDeath();
        }
    }
}
