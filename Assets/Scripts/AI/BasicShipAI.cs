using UnityEngine;
using System.Collections;

public class BasicShipAI : AI {

    float cooldownTotal = .6f;
    float cooldown = 2.8f;

    // Update is called once per frame
    public override void overrideUpdate()
    {
        AdjustPosition();
        if (cooldown <= 0)
        {
            currentShip.Shoot();
            cooldown = 2.8f;
        }
        cooldown = cooldown - Time.deltaTime;
    }

    private void AdjustPosition()
    {
        currentShip.Move(new Vector2(-1f, 0));
    }

    public float getCooldown()
    {
        return cooldownTotal;
    }

    public void Infect()
    {
        //do nothing
    }
}
