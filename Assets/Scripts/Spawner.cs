using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn() {
        for (int i = 0; i <= 5; i++)
        {
            Instantiate(obstaclePrefab, new Vector2(-8.0f + i * 2.0f, 4.0f), Quaternion.identity);
        }
    }


}
