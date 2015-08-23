using UnityEngine;
using System.Collections;

public class BulletClass : MonoBehaviour
{
	public AudioClip shootSound;

	protected int Damage;
	protected AudioSource source;
	protected string Shooter;
	protected string Foe;

	public virtual void OnShoot(Vector2 direc, string shooter)
	{
		;
	}

	public virtual void OnShoot(string shooter)
	{
		;
	}
}