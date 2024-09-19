
using UnityEngine;

public class Playerstats
{
    public float movementSpeed = 2;
    public float maxMana = 50;
    public float maxHealth = 100;
    public float castingTime = 1.5f;
    public float manaRegeneration = 2;

    public int level = 1;
    public float xp = 0;
    public int skillPoints = 0;

    public void GetXp(float newXp) {
        xp += newXp;

        if (xp >= level*2.5f)
        {
            xp -= level*2.5f;
            LevelUp();
        }
    }

    public void LevelUp() {
        level++;
        skillPoints++;
        AssignSkillPoint();

        movementSpeed += 0.25f;
        maxHealth += 10;
        maxMana += 5;
        castingTime -= 0.1f;
        manaRegeneration += 0.1f;
    }

    public void AssignSkillPoint() {
        switch (Random.Range(0, 2)) {
            case 0:
                skillPoints--;
                movementSpeed += 0.5f;
                break;
            case 1:
                skillPoints--;
                castingTime -= 0.3f;
                break;
            case 2:
                skillPoints--;
                maxMana += 10;
                break;
        }
    }
}
