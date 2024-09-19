using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball3D : MonoBehaviour
{
    public Vector3 direction = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direction * Time.deltaTime * 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // Destroy(other.gameObject);
            other.GetComponent<Enemy3D>().TakeDamage(20);
            Wizard3D.stats.GetXp(1);
        }
    }
}
