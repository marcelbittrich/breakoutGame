using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float speed = 1000.0f;
    private float delta;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {  
        delta = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        velocity = new Vector2(delta, 0);
        m_Rigidbody.MovePosition(m_Rigidbody.position + velocity);
    }
}
