using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float velocity;
    public Transform weapon;
    public GameObject bullet;
    public GameObject explosion;
    private Animator animator;

    void Start() 
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * velocity * Time.deltaTime;
        if ((transform.position.y < -3.5 && y < 0) || (transform.position.y > 4.4 && y > 0))
        {
            transform.Translate(x, 0.0f, 0.0f);
        }
        else if ((transform.position.x < -2.9 && x < 0) || (transform.position.x > 2.9 && x > 0))
        {
            transform.Translate(0.0f, y, 0.0f);
        }
        else {
            transform.Translate(x, y, 0.0f);
        }


        if (Input.GetButtonDown("Jump"))
        {
            GameObject p = Instantiate(bullet, weapon.position, weapon.rotation);
            p.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 5.0f);
        }

        if (x > 0.0f) 
        {
            animator.SetBool("pRight", true);
            animator.SetBool("pLeft", false);
        } else if (x < 0.0f) 
        {
            animator.SetBool("pRight", false);
            animator.SetBool("pLeft", true);
        } else {
            animator.SetBool("pRight", false);
            animator.SetBool("pLeft", false);
        }

    }

    public void killPlayer() {
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(MainController.EndGame());  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().Die();
            killPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Scenario")
        {
            killPlayer();
        }
    }
}
