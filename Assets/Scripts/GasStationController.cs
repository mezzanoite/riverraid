﻿using System.Collections;
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

    private AudioSource audioSource;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (playerTrigger)
        {

            if (!didLowFuel)
            {
                StartCoroutine(provideFuelToPlayer());
            }
            print("Charging...");
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
            audioSource.Play();
            print("Enter Fuel!!");
            playerTrigger = true;
            FuelController.playerOnGasStation = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource.Stop();
            print("Exit Fuel!!");
            playerTrigger = false;
            FuelController.playerOnGasStation = false;
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
        if (playerTrigger) {
            FuelController.playerOnGasStation = false;
        }
        playerTrigger = false;
    }
}
