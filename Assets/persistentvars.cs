using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class persistentvars : MonoBehaviour {
	int lastlevel = -1;
	string stringlastlevel = "";
	string leveltext;
	int score;
	int deaths = 0;


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
	public void loadBetween(bool death)
	{
		if (death)
			deaths = deaths - 1;
		Invoke ("idontevencareanymore", 1);
	}

	private void idontevencareanymore()
	{
		Application.LoadLevel ("inbetween");
	}

	public void loadLast()
	{
		if (lastlevel != -1)
			Application.LoadLevel (lastlevel);
		else if (stringlastlevel != "")
			Application.LoadLevel (stringlastlevel);

		lastlevel = -1;
		stringlastlevel = "";
	}

	public void loadNext(int level, string levelname)
	{
		this.lastlevel = level;
		this.leveltext = levelname;
		Invoke ("idontevencareanymore", 1);
	}

	public void loadNext(string level, string levelname)
	{
		this.stringlastlevel = level;
		this.leveltext = levelname;
		Invoke ("idontevencareanymore", 1);
	}

	public string returnLevelName()
	{
		return stringlastlevel;
	}
	public int getDeaths()
	{
		return deaths;
	}
}
