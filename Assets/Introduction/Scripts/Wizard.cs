using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public static Wizard Instance;
    public GameObject fireballPrefab;
    private float counter = 5;
    private Vector3 lastMovement = Vector3.zero;
    private Animator animator;

    private float invincibleCounter = 0;

    public float health = 100;
    public float mana = 50;

    public static Playerstats stats;

    // Start is called before the first frame update
    void Start()
    {
        if (stats == null)
        {
            stats = new Playerstats();
        }
        health = stats.maxHealth;
        mana =  stats.maxMana;
        Instance = this;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameManager.GoToTitle();
        }

        if (GameManager.Instance.state2 == GameManager.GameStates.paused)
        {
            return;
        }

        

        // Movement
        Vector3 movement = new Vector3(0,0,0);
        if (Input.GetKey("w"))
        {
            movement = movement + new Vector3(0f,1f,0f);
        }
        if (Input.GetKey("s"))
        {
            movement = movement + new Vector3(0f,-1f,0f);
        }
        if (Input.GetKey("a"))
        {
            movement = movement + new Vector3(-1f,0,0f);
        }
        if (Input.GetKey("d"))
        {
            movement = movement + new Vector3(1f,0,0f);
        }

        movement = movement.normalized;

        transform.position = transform.position + movement * Time.deltaTime * stats.movementSpeed;

        if (movement.y != 0 || movement.x != 0)
        {
            lastMovement=movement;
        }

        // Animation
        if (movement.y != 0 || movement.x != 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        

        //GetKomponent<Fireball>().
        // Casting
        counter += Time.deltaTime;
        if (counter > stats.castingTime && Input.GetKeyDown(KeyCode.Space) && mana >= 5)
        {
            GameObject obj = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            obj.GetComponent<Fireball>().direction = lastMovement;
            counter = 0;
            animator.SetBool("Attack", true);
            mana -= 5;
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            animator.SetBool("Attack", false);
        }

        // Mana
        mana = mana + Time.deltaTime * stats.manaRegeneration;
        if (mana > stats.maxMana)
        {
            mana = stats.maxMana;
        }

        invincibleCounter -= Time.deltaTime;
        
    }

    public void TakeDamage(float damage) 
    {
        if (invincibleCounter <= 0)
        {
            health -= damage;
            invincibleCounter = 1f;
        }
    }
}
