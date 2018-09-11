using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour {


    public GameObject fuelIndicator;
    public GameObject player;
    public int fuelTankCharges = 18;
    public bool didLowFuel = false;
    public bool didChargeFuel = false;
    public bool playerOnGasStation = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (!didLowFuel) {
            StartCoroutine(lowPlayerFuel());
        }

        if (playerOnGasStation && !didChargeFuel)
        {
            StartCoroutine(chargePlayerFuel());
        }

        if (fuelTankCharges == 0) {
            player.GetComponent<PlayerController>().killPlayer();
        }
    }

    private IEnumerator lowPlayerFuel() {
        didLowFuel = true;
        yield return new WaitForSeconds(1.0f);
        fuelTankCharges -= 1;
        didLowFuel = false;
    }

    public IEnumerator chargePlayerFuel() {
        didChargeFuel = true;
        yield return new WaitForSeconds(1.0f);
        if (fuelTankCharges <= 15) {
            fuelTankCharges += 3;
        }
        didChargeFuel = false;
    }
}
