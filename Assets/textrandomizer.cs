using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class textrandomizer : MonoBehaviour {
	Text txt;
	float timer = 3f;
	string hiddentext = "";
	int num;
	bool dispb;

	// Use this for initialization
	void Start () {
		txt = this.gameObject.GetComponent<Text> ();
		num = Random.Range (1, 75);
		if (num == 1)
		{
			num = Random.Range (0, 5);
			if (num == 5)
				hiddentext = "TO DIE";
			else if (num == 4)
				hiddentext = ":^)";
			else if (num == 3)
				hiddentext = "AAAAAAAAAAAAAAAAAAAAAAAAAA";
			else if (num == 2)
				hiddentext = "DON'T LOOK BEHIND YOU";
			else if (num == 1)
				hiddentext = "WRITHE AND SQUIRM";
			else if (num == 0)
				hiddentext = "WE RISE";
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer - Time.deltaTime;

		if (timer <= 0.1f & dispb == false)
		    {
			txt.text = hiddentext;
			dispb = true;
		}
		if (timer <= 0) {
			persistentvars vars = GameObject.Find ("PersistentVarsManager").GetComponent<persistentvars>();
			vars.loadLast();
		}


	
	}
}
