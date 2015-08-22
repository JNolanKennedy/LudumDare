using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour, BulletInterface {

	public AudioClip shootSound;

	private float Speed;
	private Vector2 Direction;
	private int Damage;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		this.source = this.GetComponent<AudioSource>();
		this.Speed = 500f;
		this.source.PlayOneShot (shootSound, 1);
		this.GetComponent<Rigidbody>().AddForce(this.Direction * this.Speed);

	}

	public void OnShoot(Vector2 direc) {
		this.Direction = direc;
	}

    public void OnCollisionEnter2D(Collision2D coll)
    {
        ;
    }
	// Update is called once per frame
	void Update () {
	}
}
