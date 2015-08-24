using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour {

    public GameObject instructions;
    public GameObject next;

    public void nextLevel()
    {
        Application.LoadLevel(1);
    }

    public void nextText()
    {
        instructions.GetComponentInChildren<Text>().text = "Enemy Shields are down when the bar above them is entirely red \n\n Don't run into enemies while their shields are up or you'll die \n\n If your ship is blown up you still have a chance to release your host and survive \n\n Good Luck and survive!";
        next.SetActive(false);
    }

    public void spawnInstructions()
    {
        
        instructions.SetActive(true);
		instructions.GetComponentInChildren<Text> ().text = "You are a highly-advanced lifeform created for the purpose of destroying the human race.\n\n" +
			"Move with WASD, arrow keys or control stick.\n\n" +
			"Use Spacebar or A to shoot (only while possessing a ship). Left shift or B to release your host.\n\n" +
			"ESC or Y to pause the game.\n\n" +
			"You can only infest ships when their shield is depleted.";
        next.SetActive(true);
    }

    public void despawnInstructions()
    {
        instructions.SetActive(false);
    }
}
