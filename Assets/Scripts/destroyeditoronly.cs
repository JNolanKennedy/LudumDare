using UnityEngine;
using System.Collections;

public class destroyeditoronly : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("EditorOnly")) Destroy(go);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
