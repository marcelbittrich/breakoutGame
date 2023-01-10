using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 startVelocity;

    // Start is called before the first frame update
    void Start()
    {
        startVelocity.x = 0.0f;
        startVelocity.y = -8.0f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = startVelocity;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
