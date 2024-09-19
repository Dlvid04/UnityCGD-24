using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text manaText;
    public TMP_Text levelText;
    public Image manaImage;
    public Image healthImage;
    public Image xpImage;

    public static int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Wizard player = Wizard.Instance;
        int health = (int) player.health;
        int mana = (int) player.mana;
        Playerstats playerstats= Wizard.stats;

        float maxHealth = playerstats.maxHealth;
        float maxMana = playerstats.maxMana;
        int level = playerstats.level;


        scoreText.text ="Score: " +score;
        healthText.text ="Health: " + health + "/" + maxHealth;
        manaText.text ="Mana: " + mana + "/" + maxMana;
        levelText.text = "Level:" + level;


        float manaPercentage = mana / maxMana;
        manaImage.transform.localScale = new Vector3(manaPercentage, 1, 1);

        float healthPercentage = health / maxHealth;
        healthImage.transform.localScale = new Vector3(healthPercentage, 1, 1);

        float xpPercentage = playerstats.xp / (level *2.5f);
        xpImage.transform.localScale = new Vector3(xpPercentage, 1, 1);

    }
}
