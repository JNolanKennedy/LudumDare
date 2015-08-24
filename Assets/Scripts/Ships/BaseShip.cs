using UnityEngine;
using System.Collections;

public class BaseShip : MonoBehaviour, ShipInterface {

	protected AudioClip Explosion;

	//Hull Points
	protected int HP;
	//Shield
	protected int Shield;
	//Ship Speed
	protected float Speed;
	//Position on the ship the parastite shows up on (0,0) is upper left
	protected Vector3 AttachPoint;
	protected AudioSource source;
	protected bool isParasite = false;
	protected bool hasParasite = false;
	protected float invincibility;

	public GameObject HPbar;
	public GameObject SHbar;
	private bool pause;

	//RegisterSelf is used for tallying purposes in the (future) pause manager
	void Start()
	{
		HP = 1;
		Shield = 1;
		invincibility = 0f;
		//generic start for any future requirements

		registerSelf ();
		overrideStart ();

		//Initiates HP bar deets

		HPbar = Instantiate (Resources.Load ("health"), this.transform.position, this.transform.rotation) as GameObject;
		HPbar.transform.parent = this.transform;
		HPbar.transform.localPosition = new Vector3 (0,-1,0);
		SHbar = Instantiate (Resources.Load ("shield"), this.transform.position, this.transform.rotation) as GameObject;
		SHbar.transform.parent = this.transform;
		SHbar.transform.localPosition = new Vector3 (0,-1,-1);
		Explosion = Resources.Load ("Sounds/NESExplosion") as AudioClip;
	}
	//This is the function you override by default for your own method calls during start
	public virtual void overrideStart()
	{

	}

	void Update() {
		//Invincability code
		if (this.invincibility > 0) {
			this.GetComponent<SpriteRenderer> ().color = Color.yellow;
			this.invincibility -= Time.deltaTime;
		} else if (this.GetComponent<SpriteRenderer> ().color != Color.white && this.invincibility <= 0) {
			this.GetComponent<SpriteRenderer> ().color = Color.white;
			this.invincibility -= Time.deltaTime;
		}
		if (hasParasite) {
			this.AttatchParasite();
		}
		if (!pause)
			overrideUpdate ();
	}
	
	public virtual void overrideUpdate()
	{
	}

	public virtual void Shoot()
	{
		;
	}

	public void AttatchParasite()
	{
		GameObject go = GameObject.FindGameObjectWithTag ("FakePara");
		go.transform.SetParent(this.transform);
		go.transform.localPosition = this.AttachPoint;
		go.GetComponent<SpriteRenderer> ().enabled = true;
	}

	public void SetParasite(bool set)
	{
		this.hasParasite = set;
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
		//Special case to get rid of parasite effect.
		if (this.hasParasite) {
			this.SetParasite(false);
			this.transform.GetChild (2).GetComponent<SpriteRenderer> ().enabled = false;
			this.transform.GetChild(2).transform.parent = null;
		}
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

		if (coll.tag == "Enemy" && this.tag == "PlayerShip") {
			ShipInterface si = coll.gameObject.GetComponent(typeof(ShipInterface)) as ShipInterface;
			si.TakeDamage(1);
		}

		overrideOnTriggerEnter2D (coll);
	}

	public virtual void overrideOnTriggerEnter2D(Collider2D coll)
	{

	}

	public virtual bool TakeDamage(int val)
	{
		if (this.tag == "PlayerShip") {
			if (invincibility <= 0) {
				if (this.Shield <= 0) {
					this.Shield = 0;
					if (this.HP > 0) {
						this.HP -= val;
						this.invincibility = 1f;
					}
				} else {
					this.Shield -= val;
				}
			
				if (this.HP <= 0) {
					OnDeath ();
					return true;
				}
			}
		} else {
			if (this.Shield <= 0) {
				this.Shield = 0;
				if (this.HP > 0) {
					this.HP -= val;
				}
			} else {
				this.Shield -= val;
			}
			
			if (this.HP <= 0) {
				OnDeath ();
				return true;
			}
		}
		return false;
	}

    public virtual Vector3 getAttachPoint()
    {
        return AttachPoint;
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
		GameObject.Find ("GameManager").GetComponent<PauseManager> ().registerObject (this.gameObject);
	}

	private void onDestroy()
	{

	}

	private void setupBars()
	{

	}


	private void PauseHandler()
	{
		if (pause == false) {
			pause = true;
		}
		else {
			pause = false;
		}

	}
}
