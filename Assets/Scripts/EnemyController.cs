using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject bullet;
    public Transform[] weapons;

    private void Start()
    {
        StartCoroutine(startRandomAttack());
    }

    private IEnumerator startRandomAttack() {
        int randomAttack = Random.Range(0, 3);

        switch (randomAttack) {
            case 0:
                return comboAttack0();

            case 1:
                return comboAttack1();

            case 2:
                return comboAttack2();

            default:
                return comboAttack0();
        }
    }

    private IEnumerator comboAttack0()
    {
        yield return new WaitForSeconds(0.5f);
        fire(weapons);
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(startRandomAttack());
    }

    private IEnumerator comboAttack1() {
        yield return new WaitForSeconds(0.5f);
        fire(weapons);
        yield return new WaitForSeconds(1.0f);
        fire(weapons);
        yield return new WaitForSeconds(0.15f);
        fire(weapons);
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(startRandomAttack());
    }

    private IEnumerator comboAttack2()
    {
        yield return new WaitForSeconds(0.5f);
        fire(weapons);
        yield return new WaitForSeconds(0.15f);
        fire(weapons);
        yield return new WaitForSeconds(0.15f);
        fire(weapons);
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(startRandomAttack());
    }

    void fire(Transform[] weapon) {
        for (int i = 0; i < weapons.Length; i++) {
            GameObject p = Instantiate(bullet, weapon[i].position, weapon[i].rotation);
            p.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -5.0f);
        }
    }

}
