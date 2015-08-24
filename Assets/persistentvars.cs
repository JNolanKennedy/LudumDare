using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class persistentvars : MonoBehaviour {
	int lastlevel;


	// Use this for initialization
	public void Awake() {
		DontDestroyOnLoad (transform.gameObject);

		if (FindObjectsOfType (typeof(persistentvars)).Length > 1)
			Destroy (this.gameObject );
	}


	public void storeLevel(int level){
		this.lastlevel = level;
	}

	public void loadBetween ()
	{
		Invoke ("idontevencareanymore", 1);
	}

	private void idontevencareanymore()
	{
		Application.LoadLevel ("inbetween");
	}

	public void loadLast()
	{
		Application.LoadLevel (lastlevel);
	}
}
