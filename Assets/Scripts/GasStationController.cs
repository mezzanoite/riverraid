using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStationController : MonoBehaviour
{


    public int fuelChargesLeft = 5;
    public bool playerTrigger = false;
    public bool didLowFuel = false;
    public GameObject player;
    public int pointsPerKill = 5;
    public GameObject explosion;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (playerTrigger && !didLowFuel)
        {
            StartCoroutine(provideFuelToPlayer());
            FuelController.playerOnGasStation = true;
            print("Charging...");
        }

        if (!playerTrigger) {
            FuelController.playerOnGasStation = false;
        }

        if (fuelChargesLeft == 0)
        {
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

    private IEnumerator provideFuelToPlayer()
    {
        didLowFuel = true;
        yield return new WaitForSeconds(1.0f);
        fuelChargesLeft -= 1;
        didLowFuel = false;
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        FuelController.playerOnGasStation = false;
    }
}
