using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    Text HP;
    GameObject player;

	// Use this for initialization
	void Start () {
        gameObject.GetComponentsInChildren<Text>()[0].text = "HP : ";
        gameObject.GetComponentsInChildren<Text>()[1].text = "Shields : "; 
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindWithTag("PlayerShip");
        string hp = (player.GetComponent(typeof(BaseShip)) as BaseShip).getHP().ToString();
        string shields = (player.GetComponent(typeof(BaseShip)) as BaseShip).getShields().ToString();
        gameObject.GetComponentsInChildren<Text>()[0].text = "HP : " + hp;
        gameObject.GetComponentsInChildren<Text>()[1].text = "Shields : " + shields;
	}
}
