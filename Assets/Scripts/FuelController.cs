using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour {


    public int charges = 5;
    public bool playerTrigger = false;
    public bool didLowCharge = false;

    private void FixedUpdate()
    {
        if (playerTrigger && !didLowCharge) {
            StartCoroutine(chargePlayerFuel());
            print("Charging...");
        }

        if (charges == 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("Enter Fuel!!");
            playerTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("Exit Fuel!!");
            playerTrigger = false;
        }
    }

    private IEnumerator chargePlayerFuel() {
        didLowCharge = true;
        yield return new WaitForSeconds(1.0f);
        charges -= 1;
        didLowCharge = false;
    }
}
