using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float powerUpDropChance = 0.2f;

    public Obstacle obstaclePrefab;
    public GameObject powerUpPrefab;
    public Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        ball.ObstacleDestroyEvent += OnObstacleDestroy;
        Spawn();
    }

    void Spawn() {
        for (int i = 0; i <= 5; i++)
        {
            Obstacle obstacle = Instantiate<Obstacle>(obstaclePrefab, new Vector2(-8.0f + i * 2.0f, 4.0f), Quaternion.identity);
        }
    }

    void OnObstacleDestroy(GameObject obstacle) {
        if (Random.value < powerUpDropChance) {
            GameObject powerUp = Instantiate(powerUpPrefab, obstacle.transform.position, Quaternion.identity);
            Rigidbody2D rb = powerUp.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0.0f, -3.0f);
            Debug.Log("success! hussa!");
        }
    }
}
