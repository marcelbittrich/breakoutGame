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
    public float ballVelocity = 8.0f;

    public delegate void OnObstacleDestroyHandler(GameObject instance);
    public event OnObstacleDestroyHandler ObstacleDestroyEvent;

    public Player myPlayer;
    private bool gameIsStarted = false;
    public float minYVelocity = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        startVelocity.x = 0;
        startVelocity.y = ballVelocity;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (!gameIsStarted)
        {
            float ballPlayerDistance = transform.localScale.y / 2 + myPlayer.transform.localScale.y / 2; 
            transform.position = myPlayer.transform.position + new Vector3(0, ballPlayerDistance, 0);
            if (Input.GetButtonDown("Jump"))
            {
                gameIsStarted = true;
                rb.velocity = startVelocity;
            }
        }
        if (Mathf.Abs(rb.velocity.y) < minYVelocity) {
            rb.velocity = rb.velocity + new Vector2(0, 4.0f) * Time.deltaTime;
            ResetVelocity();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Target") {
            GameManager.Instance.IncreaseScore();
            ObstacleDestroyEvent?.Invoke(collision.gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            HandlePlayerCollision(collision);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBottom") {
            gameIsStarted = false;
        }
    }

    private void HandlePlayerCollision(Collision2D collision)
    {
        Debug.Log("Handle player collision");
        Vector3 playerCenter = collision.gameObject.transform.position;
        float playerWidth = collision.gameObject.transform.localScale.x;

        ContactPoint2D contactPoint = collision.GetContact(0);

        float positionOnPlayerBar = (contactPoint.point.x - playerCenter.x) / (playerWidth / 2);

        rb.velocity = rb.velocity + new Vector2(positionOnPlayerBar * contactBounceStrength, 0);
        ResetVelocity();
    }

    private void ResetVelocity()
    {
        rb.velocity = rb.velocity.normalized * ballVelocity;
    }
}
