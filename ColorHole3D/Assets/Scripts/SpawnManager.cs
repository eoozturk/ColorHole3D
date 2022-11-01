using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bridgeEnemy;
    private float xPos, yPos, zPos, bound;

    // Start is called before the first frame update
    void Start()
    {
        bound = -1.15f;
        xPos = -77.57f;
        yPos = -39.61892f;
        zPos = -10.1002f;

        InvokeRepeating("GenerateEnemy", 0.0f, 0.001f);
    }

    void GenerateEnemy()
    {
        Vector3 spawnPos = new Vector3(xPos, yPos, zPos);

        if(zPos <= bound)
        {
            Instantiate(bridgeEnemy, spawnPos, bridgeEnemy.transform.rotation);          
        }

        zPos += 0.36f;
    }
}
