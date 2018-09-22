using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour {

    public Text pressStartText;

    void Start()
    {
        StartCoroutine(blinkText());
    }


    private IEnumerator blinkText()
    {
        pressStartText.enabled = true;
        yield return new WaitForSeconds(0.3f);
        pressStartText.enabled = false;
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(blinkText());
    }
	
}
