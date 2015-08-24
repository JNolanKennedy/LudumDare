using UnityEngine;
using System.Collections;

public class levelmovement : MonoBehaviour {
	public float speed = 0.1f;
	bool pause = false;

	// Use this for initialization
	void Start () {
		GameObject.Find ("GameManager").GetComponent<PauseManager> ().registerObject (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (!pause)
			this.transform.position = new Vector3 (this.transform.position.x-speed, 0, 0);
	}

	private void PauseHandler()
	{
		if (pause == false)
			pause = true;
		else {
			pause = false;
		}
	}
}
