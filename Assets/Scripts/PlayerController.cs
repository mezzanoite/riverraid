using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float velocidade;
    public Transform arma;
    public GameObject projetil;

    void Update()
    {

        float x = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * velocidade * Time.deltaTime;
        transform.Translate(x, y, 0.0f);

        if (Input.GetButtonDown("Jump"))
        {
            GameObject p = Instantiate(projetil, arma.position, arma.rotation);
            p.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 5.0f);
        }

    }
}
