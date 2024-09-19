using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy3D : MonoBehaviour
{
    public float movementSpeed = 1.5f;
    public float frost = 1; 

    public float health = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = Wizard3D.Instance.transform.position;
        Vector3 direction = playerPosition - transform.position + new Vector3(0,0.5f,0);
        transform.position += direction.normalized*Time.deltaTime * movementSpeed * frost;
        frost = 1;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Destroy(other.gameObject);
            collision.collider.GetComponent<Wizard3D>().TakeDamage(20);
        }
    }

    void OnMouseOver()
    {
        frost = 0;
        Debug.Log("Ready");
    }



}
