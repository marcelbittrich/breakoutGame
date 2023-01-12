using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float powerUpDropChance = 0.2f;
    public GameObject powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        if (Random.value < powerUpDropChance)
            SpawnPowerUp();
        
    }

    void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
    }
}
