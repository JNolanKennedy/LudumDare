using UnityEngine;
using System.Collections;

public class BasicShipAI : AI {

    float cooldown = .6f;

    // Update is called once per frame
    public override void overrideUpdate()
    {
        AdjustPosition();
        if (cooldown <= 0)
        {
            currentShip.Shoot();
            cooldown = .6f;
        }
        cooldown = cooldown - Time.deltaTime;
    }

    private void AdjustPosition()
    {
        currentShip.Move(new Vector2(-1f, 0));
    }

    public void Infect()
    {
        //do nothing
    }
}
