using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour {

	void Start () {
        StartCoroutine(explodir());
	}

    private IEnumerator explodir()
    {
        // Somente para dar tempo do som da explosão finalizar
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
	
}
