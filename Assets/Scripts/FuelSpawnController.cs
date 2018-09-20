using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawnController : MonoBehaviour {

    public GameObject fuel;

	void Start () {
        // Sorteio se esse spot deve spawnar um posto ou não
        bool shouldSpawn = (Random.value > 0.5f);
        if (shouldSpawn)
        {
            Instantiate(fuel, this.transform.position, this.transform.rotation);
        }
    }
	
}
