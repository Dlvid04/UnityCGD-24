using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fireball : MonoBehaviour
{
    public Vector3 direction = Vector3.up;
    public float damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);

        // Rotate the fireball 
        float angle = Vector3.Angle(Vector3.right, direction);

        if (direction.y < 0)
        {
            angle = angle*-1;
        }


        transform.Rotate(new Vector3(0,0,angle));
        transform.position = transform.position + direction*2;

        /*
        if (direction.y > 0)
        {
            transform.Rotate(new Vector3(0,0,90));
        }
        if (direction.y < 0)
        {
            transform.Rotate(new Vector3(0,0,-90));
        }
        if (direction.x < 0)
        {
            transform.Rotate(new Vector3(0,0,180));
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direction * Time.deltaTime * 4;
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            return;
        }
        Destroy(gameObject);
    }

}
