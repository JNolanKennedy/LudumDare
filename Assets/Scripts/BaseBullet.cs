using UnityEngine;
using System.Collections;

public class BaseBullet : MonoBehaviour {
	
	public AudioClip shootSound;
	
	protected float Speed;
	protected Vector2 Direction;
	protected int Damage;
	protected AudioSource source;
	protected string Shooter;
	protected string Foe;
	private bool pause;

	// Use this for initialization
	//RegisterSelf is used for tallying purposes in the (future) pause manager
	void Start () {
		registerSelf ();
		overrideStart ();
	
	}
	//This is the function you override by default for your own method calls during start
	public virtual void overrideStart()
	{

	}
	
	// Update is called once per frame
	void Update () {
		if (!pause)
			overrideUpdate ();
	
	}

	public virtual void overrideUpdate()
	{

	}

	private void registerSelf()
	{
		GameObject.Find ("GameManager").GetComponent<PauseManager> ().registerObject (this.gameObject);
	}

	public void OnDestroy()
	{

	}
	private void PauseHandler()
	{
		if (pause == false)
			pause = true;
		else {
			pause = false;
			this.GetComponent<Rigidbody2D>().AddForce(this.Direction * this.Speed);
		}
	}

	public virtual void OnShoot(Vector2 direc, string shooter)
	{
		;
	}
	
	public virtual void OnShoot(string shooter)
	{
		;
	}
}
