using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float hp = 20;
    public float movementSpeed = 1.5f;
    public float damage = 20;

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        Vector3 playerPosition = Wizard.Instance.transform.position;
        Vector3 direction = playerPosition - transform.position;
        transform.position += direction.normalized*Time.deltaTime * movementSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        float x = Random.Range(5,10) * ((Random.value>0.5) ? 1: -1);
        float y = Random.Range(5,10) * ((Random.value>0.5) ? 1: -1);
        if (collision2D.gameObject.tag == "Projectille")
        {   
            Fireball fireball = collision2D.transform.GetComponent<Fireball>();
            hp -= fireball.damage;

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
     
            return;
        }
        if (collision2D.gameObject.tag == "Player")
        {            
            Wizard.Instance.TakeDamage(damage);                     
            return;
        }
    }
}
