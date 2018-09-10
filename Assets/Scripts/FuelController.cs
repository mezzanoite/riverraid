using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour {


    public int fuelLeft = 5;
    public bool playerTrigger = false;
    public bool didLowFuel = false;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (playerTrigger && !didLowFuel) {
            StartCoroutine(provideFuelToPlayer());
            print("Charging...");
        }

        if (fuelLeft == 0) {
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

    private IEnumerator provideFuelToPlayer() {
        didLowFuel = true;
        yield return new WaitForSeconds(1.0f);
        fuelLeft -= 1;
        if (player != null) {
            player.GetComponent<PlayerController>().fuel += 3;
        }
        didLowFuel = false;
    }
}
