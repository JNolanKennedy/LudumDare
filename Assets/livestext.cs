using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class livestext : MonoBehaviour {
	Text txt;
	int deaths;
	// Use this for initialization
	void Start () {
		txt = this.gameObject.GetComponent<Text> ();
		deaths = GameObject.Find ("PersistentVarsManager").GetComponent<persistentvars> ().getDeaths ();
		txt.text = deaths.ToString ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
