using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    private float delta;
    private bool doesCollideRightWall = false;
    private bool doesCollideLeftWall = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        delta = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if ((delta < 0 && !doesCollideLeftWall) || (delta > 0 && !doesCollideRightWall))
        transform.position += new Vector3(delta, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "WallRight") doesCollideRightWall = true;
        if (other.gameObject.name == "WallLeft") doesCollideLeftWall = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "WallRight") doesCollideRightWall = false;
        if (other.gameObject.name == "WallLeft") doesCollideLeftWall= false;
    }
}
