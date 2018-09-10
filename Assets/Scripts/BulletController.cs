using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject explosion;

    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DestroyBulletAndObject(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fuel")
        {
            DestroyBulletAndObject(collision.gameObject);
        }
    }

    public void DestroyBulletAndObject(GameObject obj) {
        Instantiate(explosion, obj.transform.position, obj.transform.rotation);
        Destroy(obj);
        Destroy(gameObject);
    }
}
