using UnityEngine;
using System.Collections;

public class BulletBase : MonoBehaviour {
	
	public AudioClip shootSound;
	
	protected float Speed;
	protected Vector2 Direction;
	protected int Damage;
	protected AudioSource source;
	protected string Shooter;
	protected string Foe;

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
	
	}

	private void registerSelf()
	{
		
	}

	private void OnDestroy()
	{
		//dereg self
	}
}
