using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wizard3D : MonoBehaviour
{
    public static Playerstats stats;
    private Vector3 lastDirection;
    public GameObject fireballPrefab;
    public static Wizard3D Instance;
    private float health;
    private float mana;
    private float castingCounter = 0;
    private Animator animator;
    private float speed; 



    // Start is called before the first frame update
    void Start()
    {
        Instance = this; 
        if (stats == null)
        {
            stats = new Playerstats();
        }  
        health = stats.maxHealth;
        mana = stats.maxMana;  
        animator = GetComponent<Animator>();    
        speed = stats.movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();        
        castingCounter -= Time.deltaTime;
        mana += Time.deltaTime* stats.manaRegeneration;
        if (castingCounter <= 0 && mana >= 5)
        {
            Casting();
        }
    }

    void Movement()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;
        }
        if (Input.GetKey("s"))
        {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey("d"))
        {
            movement += Vector3.right;
        }

        if (movement.magnitude > 0)
        {
            animator.SetBool("walking", true);
            lastDirection = movement;
            Rotate();
            transform.position += movement.normalized*Time.deltaTime* speed;
        }
        else
        {
            animator.SetBool("walking", false);
        }
        
    }

    void Rotate()
    {
        float angle = Vector3.Angle(Vector3.forward, lastDirection);

        if (lastDirection.x < 0)
        {
            angle = angle*-1;
        }
        transform.rotation = Quaternion.Euler(0,angle,0);
    }

    void Casting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("attacking", true);
            StartCoroutine(attackingAnimationTimer());
            GameObject obj = Instantiate(fireballPrefab, transform.position + lastDirection + Vector3.up, Quaternion.identity);
            obj.GetComponent<Fireball3D>().direction = lastDirection;
            castingCounter = stats.castingTime;
            mana -= 5;
        }
        if (Input.GetMouseButtonDown(1))
        {
            bool x_frozen = Input.GetMouseButtonDown(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    IEnumerator attackingAnimationTimer()
    {
        // nichts
        speed = 0;
        yield return new WaitForSeconds(1f);
        // nach zwei Sekunde
        animator.SetBool("attacking", false);
        speed = stats.movementSpeed;
    }

}
