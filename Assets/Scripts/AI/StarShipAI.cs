using UnityEngine;
using System.Collections;

public class StarShipAI : MonoBehaviour {

    ShipInterface currentShip;
    bool isPlayer = false;
    Transform player;

    // Use this for initialization
    void Start()
    {
        currentShip = this.GetComponent(typeof(ShipInterface)) as ShipInterface;
        if (this.transform.parent != null)
        {
            isPlayer = true;
        }
        else
        {
            this.transform.Rotate(Vector3.forward * 180);
            player = GameObject.Find("Player").transform.GetChild(0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer == false)
        {
            AdjustPosition();
        }
    }

    private void AdjustPosition()
    {
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        currentShip.Move(transform.right);
    }
}
