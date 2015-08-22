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
		this.Damage = 1;
		this.Speed = 500f;
		this.source.PlayOneShot (shootSound, 1);
		this.GetComponent<Rigidbody2D>().AddForce(this.Direction * this.Speed);

	}

	public void OnShoot(Vector2 direc) {
		this.Direction = direc;
	}

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy") {
			BehaviorInterface enem = coll.gameObject.GetComponent (typeof(BehaviorInterface)) as BehaviorInterface;
			enem.TakeDamage (this.Damage);
			Destroy (this);
		} else {
			Debug.Log("HERE");
			Destroy (this);
		}
    }
	// Update is called once per frame
	void Update () {
	}
}
