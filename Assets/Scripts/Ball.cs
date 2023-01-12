using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 startVelocity;
    public float contactBounceStrength = 5f;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Target") {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            HandlePlayerCollision(collision);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = Vector3.zero;
    }

    private void HandlePlayerCollision(Collision2D collision)
    {
        Vector3 playerCenter = collision.gameObject.transform.position;
        float playerWidth = collision.gameObject.transform.localScale.x;

        ContactPoint2D contactPoint = collision.GetContact(0);

        float positionOnPlayerBar = (contactPoint.point.x - playerCenter.x) / (playerWidth / 2);
        float ballVelocity = rb.velocity.magnitude;

        Vector2 newBallDirection = rb.velocity + new Vector2(positionOnPlayerBar * contactBounceStrength, 0);
        rb.velocity = newBallDirection.normalized * ballVelocity;
    }
}
