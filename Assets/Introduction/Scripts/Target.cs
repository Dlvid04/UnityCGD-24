using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject TargetPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Projectille")
        {
            float x = 15.6f*Random.value -7.8f;
            float y = 8f*Random.value -4f;
            Instantiate(TargetPrefab, new Vector3(x,y,0), Quaternion.identity);

            Destroy(gameObject);
            Hud.score += 1;

            Wizard player = Wizard.Instance;
            Playerstats playerstats= Wizard.stats;
            playerstats.GetXp(1);

        }        
    }

}
