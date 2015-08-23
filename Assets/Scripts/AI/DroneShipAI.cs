using UnityEngine;
using System.Collections;

public class DroneShipAI : AI {
	
	ShipInterface currentShip;
    float cooldown = 1f;
		
    // Update is called once per frame
    void Update()
    {
        AdjustPosition();
        if (cooldown <= 0)
        {
            currentShip.Shoot();
            setCooldown();
        }
        cooldown -= Time.deltaTime;

    private void AdjustPosition()
    {
        currentShip.Move(new Vector2(-1f, 0));
    }

    private void setCooldown()
    {
        cooldown = 10f;
    }

    public void Infect()
    {
        //do nothing
    }
}
