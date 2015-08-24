using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class levelname : MonoBehaviour {
	Text txt;
	void Start () {

		txt = this.gameObject.GetComponent<Text> ();
		txt.text = GameObject.Find ("PersistentVarsManager").GetComponent<persistentvars>().returnLevelName();
	}
}
