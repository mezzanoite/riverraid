using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaSpawnController : MonoBehaviour {

    public GameObject[] telasToSpawn;
    public int numeroTelasFaceisIniciais;

    private GameObject telaSpawned;
    private int telasFaceisCount = 0;


	void Start () {

        instanciarTelaFacil();

    }
	
	void Update () {

        if (telaSpawned.transform.position.y <= 0)
        {
            if (telasFaceisCount < numeroTelasFaceisIniciais)
            {
                instanciarTelaFacil();
            } else
            {
                sortearEInstanciarTela();
            }      
        }
	}

    private void sortearEInstanciarTela()
    {
        int randomTela = Random.Range(0, telasToSpawn.Length);
        telaSpawned = Instantiate(telasToSpawn[randomTela], this.transform.position, this.transform.rotation);
    }

    private void instanciarTelaFacil()
    {
        telaSpawned = Instantiate(telasToSpawn[0], this.transform.position, this.transform.rotation);
        telasFaceisCount++;
    }

}
