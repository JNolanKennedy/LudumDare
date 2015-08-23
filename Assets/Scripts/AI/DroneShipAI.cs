using UnityEngine;
using System.Collections;

public class DroneShipAI : MonoBehaviour, AI {

    ShipInterface currentShip;
    float cooldown = 1f;

    // Use this for initialization
    void Start()
    {
        currentShip = this.GetComponent(typeof(ShipInterface)) as ShipInterface;
    }

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
    }

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
