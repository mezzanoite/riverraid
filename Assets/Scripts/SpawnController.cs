using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    public GameObject[] scenariosToSpawn;
    public GameObject[] enemiesToSpawn;
    public GameObject gasStation;

    public bool didInstantiateScenario = false;
    public bool didInstantiateEnemy = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (!didInstantiateScenario) {
            StartCoroutine(instantiateScenario());
        }

        if (!didInstantiateEnemy)
        {
            StartCoroutine(instantiateEnemy());
        }
    }

    private IEnumerator instantiateScenario()
    {
        didInstantiateScenario = true;
        yield return new WaitForSeconds(5.0f);
        int randomScenario = Random.Range(0, scenariosToSpawn.Length);
        GameObject p = Instantiate(scenariosToSpawn[randomScenario], this.transform.position, this.transform.rotation);
        didInstantiateScenario = false;
    }

    public LayerMask collisionTest;

    private IEnumerator instantiateEnemy()
    {
        didInstantiateEnemy = true;
        yield return new WaitForSeconds(2.0f);
        int randomEnemy = Random.Range(0, enemiesToSpawn.Length);
        Vector2 randomPosition = new Vector2(Random.Range(-3, 3), this.transform.position.y);
        GameObject p = Instantiate(enemiesToSpawn[randomEnemy], randomPosition, this.transform.rotation);
        didInstantiateEnemy = false;
    }

}
