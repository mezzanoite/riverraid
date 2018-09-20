using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float limiteY;

    //public GameObject explosion;

    //public enum BulletType {
    //    enemy,
    //    player
    //}

    //public BulletType bulletType;


    private void Start()
    {
        //Destroy(gameObject, 5.0f);
    }

    private void Update()
    {
        if(transform.position.y > limiteY)
        {
            // Destruo o tiro assim que ele sai da tela, assim não atinge inimigos já spawnados que ainda não estão visíveis
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().Die();
            Destroy(gameObject);
        }
        if (collision.tag == "GasStation")
        {
            collision.gameObject.GetComponent<GasStationController>().Explode(); 
            Destroy(gameObject);
        }
        if (collision.tag == "Scenario")
        {
            Destroy(gameObject);
        }
    }
}
