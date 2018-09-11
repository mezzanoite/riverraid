using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int pointsPerKill;
    public GameObject explosion;

    public void Die() {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        //ScoreController.totalPoints += pointsPerKill;
    }
}
