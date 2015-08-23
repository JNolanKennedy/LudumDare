using UnityEngine;
using System.Collections;

public class BaseShip : MonoBehaviour, ShipInterface {

	public AudioClip Explosion;

	//Hull Points
	protected int HP;
	//Shield
	protected int Shield;
	//Ship Speed
	protected float Speed;
	//Position on the ship the parastite shows up on (0,0) is upper left
	protected Vector2 AttachPoint;
	protected AudioSource source;
	protected bool isParasite = false;
	
	//RegisterSelf is used for tallying purposes in the (future) pause manager
	void Start()
	{
		//generic start for any future requirements
		registerSelf ();
		overrideStart ();
        gameObject.GetComponentInChildren<healthbar>().start();
        gameObject.GetComponentInChildren<shieldbar>().start();
	}
	//This is the function you override by default for your own method calls during start
	public virtual void overrideStart()
	{

	}
	
	public virtual void Shoot()
	{
		;
	}
	
	public virtual void Move(Vector2 Direction)
	{
		//Takes the direction, multiplies by speed
		this.transform.position += (float)this.Speed * (Vector3)Direction;
	}
	
	public virtual void OnDeath()
	{
		//Change Animation to EXPLOSION!!!!
		this.HP = 0;
		this.source.PlayOneShot(Explosion, 1);
		this.GetComponent<Animator> ().CrossFade ("death", 0);
		this.GetComponent<BoxCollider2D> ().enabled = false;
		Destroy(this.GetComponent(typeof(AI)));
		Destroy(this.gameObject, 1f);
	}
	
	public virtual void Upgrade()
	{
	}
	
	public virtual void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "endwall") {
			Destroy (this.gameObject);
		}
	}

	public virtual bool TakeDamage(int val)
	{
		if (this.Shield <= 0) {
			this.Shield = 0;
			if (this.HP > 0) {
				this.HP -= val;
			}
		} else {
			this.Shield -= val;
		}
		
		if (this.HP <= 0) {
			OnDeath();
			return true;
		}
		return false;
	}

	public virtual int getShields() 
	{
		return this.Shield;
	}

	public int getHP()
	{
		return this.HP;
	}

	public bool getIsParasite()
	{
		return this.isParasite;
	}

	private void registerSelf()
	{

	}

	private void onDestroy()
	{
		//deregs self
	}
}
