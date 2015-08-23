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
        player = GameObject.FindWithTag("PlayerShip");
	}
	
	// Update is called once per frame
	void Update () {
        string hp = (player.GetComponent(typeof(BaseShip)) as BaseShip).getHP().ToString();
        string shields = (player.GetComponent(typeof(BaseShip)) as BaseShip).getShields().ToString();
        gameObject.GetComponentsInChildren<Text>()[0].text = "HP : " + hp;
        gameObject.GetComponentsInChildren<Text>()[1].text = "Shields : " + shields;
	}
}
