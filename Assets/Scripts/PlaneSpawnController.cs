using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawnController : MonoBehaviour {

    public GameObject planePrefab;
    public bool flipX;
    public float velocityX;
    public float timeToWait;

    private GameObject plane;
    public bool startedCoroutine = false;

    void Start () {
        Destroy(plane, 5.0f);
    }
	
	void Update () {
        if (!startedCoroutine)
        {
            StartCoroutine(instantiatePlane());
        }
		if (plane)
        {
            plane.transform.Translate(Vector2.right * velocityX * Time.deltaTime);
        }
	}

    private IEnumerator instantiatePlane()
    {
        startedCoroutine = true;
        yield return new WaitForSeconds(timeToWait);
        // Sorteio se esse spot deve spawnar um avião ou não
        bool shouldSpawn = (Random.value > 0.5f);
        if (shouldSpawn)
        { 
            plane = Instantiate(planePrefab, this.transform.position, this.transform.rotation);
            plane.GetComponent<SpriteRenderer>().flipX = flipX;
        }
        startedCoroutine = false;
    }


}
