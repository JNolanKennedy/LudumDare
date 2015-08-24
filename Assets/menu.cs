using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour {

    public GameObject instructions;
    public GameObject next;

    void Start()
    {
        instructions.SetActive(false);
    }

    public void nextLevel()
    {
        Application.LoadLevel(1);
    }

    public void nextText()
    {
        gameObject.GetComponent<Text>().text = "Enemy Shields are down when the bar above them is entirely red \n\n Don't run into enemies while their shields are up or you'll die \n\n If your ship is blown up you still have a chance to release your host and survive \n\n Good Luck bringing death to humanity";
        next.SetActive(false);
    }

    public void spawnInstructions()
    {
        instructions.SetActive(true);
        next.SetActive(true);
    }

    public void despawnInstructions()
    {
        instructions.SetActive(false);
    }
}
