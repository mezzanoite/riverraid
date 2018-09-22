using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int pointsPerKill;
    public GameObject explosion;
    public float distanceStartMoving;
    public float velocity;

    [HideInInspector] // Para não mostrar no editor
    public bool neverMove;

    private GameObject target;
    private bool moving;
    private Vector3 direction;
    private bool checkDistance;

    // Components
    private SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player"); // O alvo na visão do inimigo é o próprio "Player"
        moving = false;
        checkDistance = true;
        Destroy(gameObject, 15);
    }

    void Update() 
    {

        if (target != null && checkDistance && !neverMove) 
        {
            Vector2 currentDistance = transform.position - target.transform.position;
            float currentDistanceX = Mathf.Abs(currentDistance.x);
            float currentDistanceY = Mathf.Abs(currentDistance.y);
            // Se a distância vertical for menor que o "distanceStartMoving", inimigo tem chance de se movimentar
            if (currentDistanceY <= distanceStartMoving) 
            {
                checkDistance = false;
                this.setDirectionsIfShouldMove();
            } 
        }

        if (moving)
        {
            this.move();
        }
    }

    public void Die() {
        Instantiate(explosion, transform.position, transform.rotation);
        MainController.score = MainController.score + pointsPerKill;
        Destroy(gameObject);
    }

    
    private void setDirectionsIfShouldMove() {
        // 50% de chance de começar a se mover
        bool shouldMove = (Random.value > 0.5f);
        if (shouldMove) {
            moving = true;
            if (!spriteRenderer.flipX) {
                // Sprite apontando para a direita, move para a direita.
                direction = Vector3.right;
            } else {
                // Move para a esquerda caso contrário.
                direction = Vector3.left;
            }
        }
    }

    private void move() 
    {
        transform.Translate(direction * velocity * Time.deltaTime);
    }

}
