using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	float extent = 0;
	GameObject wall1;
	GameObject wall2;
	void Start () {
		Camera.main.orthographicSize = 8;
		extent = Camera.main.orthographicSize * Screen.width / Screen.height;
		wall1 = GameObject.Find ("boundwall4");
		wall2 = GameObject.Find ("boundwall2");

		wall1.transform.position = new Vector3 (extent+.5f, 0, 0);
		wall2.transform.position = new Vector3 (-extent-.5f, 0, 0);
	}
	float ReturnExtent (){
		return extent;
	}
}
