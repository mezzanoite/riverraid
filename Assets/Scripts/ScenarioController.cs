using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour {

    public float velocity = -1.3f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 15);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        this.transform.Translate(0.0f, velocity * Time.deltaTime, 0.0f);
    }
}
