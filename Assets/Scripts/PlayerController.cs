using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float velocity;
    public Transform weapon;
    public GameObject bullet;
    public int fuel = 20;
    public GameObject explosion;

    public bool didLowFuel = false;


    void Update()
    {

        float x = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * velocity * Time.deltaTime;
        transform.Translate(x, y, 0.0f);

        if (Input.GetButtonDown("Jump"))
        {
            GameObject p = Instantiate(bullet, weapon.position, weapon.rotation);
            p.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 5.0f);
        }

    }

    private void FixedUpdate()
    {
        if (!didLowFuel)
        {
            StartCoroutine(lowFuel());
        }

        if (fuel == 0)
        {
            killPlayer();
        }
    }

    private IEnumerator lowFuel()
    {
        didLowFuel = true;
        yield return new WaitForSeconds(1.0f);
        fuel -= 1;
        didLowFuel = false;
    }

    private void explode(GameObject obj) {
        Instantiate(explosion, obj.transform.position, obj.transform.rotation);
        Destroy(obj);
    }

    private void killPlayer() {
        explode(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            explode(collision.gameObject);
            killPlayer();
        }
    }
}
