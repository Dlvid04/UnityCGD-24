using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    private float timer = 8f;
    private float spawnIntervall = 5f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            float x = Random.Range(5,10) * ((Random.value>0.5) ? 1: -1);
            float y = Random.Range(5,10) * ((Random.value>0.5) ? 1: -1);

            Instantiate(enemiesPrefabs[0], new Vector3(x,y,0), Quaternion.identity);

            timer = spawnIntervall;
        }
    }
}
