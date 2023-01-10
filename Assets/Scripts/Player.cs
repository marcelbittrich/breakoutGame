using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float speed = 1000.0f;
    private float delta;
    private bool doesCollideRightWall = false;
    private bool doesCollideLeftWall = false;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        delta = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        // if ((delta < 0 && !doesCollideLeftWall) || (delta > 0 && !doesCollideRightWall))
        velocity = new Vector2(delta, 0);
        m_Rigidbody.MovePosition(m_Rigidbody.position + velocity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.name == "WallRight") doesCollideRightWall = true;
        // if (other.gameObject.name == "WallLeft") doesCollideLeftWall = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // if (other.gameObject.name == "WallRight") doesCollideRightWall = false;
        // if (other.gameObject.name == "WallLeft") doesCollideLeftWall= false;
    }
}
