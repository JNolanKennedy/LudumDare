﻿using UnityEngine;
using System.Collections;

public class BaseSpawner : MonoBehaviour {
	public GameObject prefabSpawn;
	private bool endPass = false;
	private bool pause = false;
	float timer = 0.25f;
	// Use this for initialization
	void Start () {
		GameObject.Find ("GameManager").GetComponent<PauseManager> ().registerObject (this.gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (endPass == true && timer <= 0 && pause == false) {
			Instantiate (prefabSpawn, this.transform.position, this.transform.rotation);
			Destroy (gameObject);
		} else if (endPass == true && pause == false)
			timer = timer - Time.deltaTime;
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "endwall")
		{
			endPass = true;
		}
	}
	public void OnDrawGizmos()
	{
		Gizmos.DrawIcon (transform.position, "spawnbig.png", true);
	}

	public void PauseHandler()
	{
		if (pause == false)
			pause = true;
		else
			pause = false;
	}
}
