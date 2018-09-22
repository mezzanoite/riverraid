using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour {

    public GameObject fuelIndicator;
    public bool isFull;
    public bool isEmpty;
    public GameObject player;
    public bool didLowFuel = false;
    public bool didChargeFuel = false;
    public static bool playerOnGasStation = false;
    public float fuelVelocity = -1.0f;
    public bool localPlayerOnGasStation = false;
    public int fuelTankCharges = 18;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        print(playerOnGasStation);
        //if  (MainController.isPlaying) {

            isFull = (fuelTankCharges > 15);
            isEmpty = (fuelTankCharges == 0);

            if (!didLowFuel)
            {
                StartCoroutine(lowPlayerFuel());
            }

            if (playerOnGasStation && !didChargeFuel && !isFull)
            {
                StartCoroutine(chargePlayerFuel());
            }

            if (isEmpty)
            {
                if (player != null)
                {
                    player.GetComponent<PlayerController>().killPlayer();
                }
            }
       //}
    }

    private void updateIndicatorX() {
        fuelIndicator.transform.Translate(fuelVelocity/10, 0.0f, 0.0f);
    }

    private IEnumerator lowPlayerFuel() {
        didLowFuel = true;
        yield return new WaitForSeconds(1.0f);
        didLowFuel = false;
        fuelVelocity = -1.0f;
        fuelTankCharges -= 1;
        updateIndicatorX();
    }

    public IEnumerator chargePlayerFuel() {
        didChargeFuel = true;
        yield return new WaitForSeconds(1.0f);
        fuelVelocity = 3.0f;
        fuelTankCharges += 3;
        updateIndicatorX();
        didChargeFuel = false;
    }
}
