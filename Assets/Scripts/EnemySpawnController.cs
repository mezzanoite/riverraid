using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

    public GameObject[] enemiesToSpawn;
    public float limitDireita;
    public float limiteEsquerda;
    public bool neverMove;

    private GameObject enemySpawned;
    private EnemyController enemyController;
    private SpriteRenderer spriteRenderer;


    void Start () {
    
        // Sorteio se esse spot deve spawnar um inimigo ou não
        bool shouldSpawn = (Random.value > 0.25f);
        if (shouldSpawn)
        {
            int randomEnemy = Random.Range(0, enemiesToSpawn.Length);
            enemySpawned = Instantiate(enemiesToSpawn[randomEnemy], this.transform.position, this.transform.rotation);
            enemyController = enemySpawned.GetComponent<EnemyController>();
            spriteRenderer = enemySpawned.GetComponent<SpriteRenderer>();
            enemyController.neverMove = neverMove;
        }
        
		
	}
	
	void Update () {
		
        if (enemySpawned && !neverMove)
        {
            if (enemySpawned.transform.position.x >= limitDireita || enemySpawned.transform.position.x <= limiteEsquerda)
            {
                enemyController.velocity = -enemyController.velocity;
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
        

	}
}
