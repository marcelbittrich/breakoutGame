using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("power up triggerst something");
        if (collision.gameObject.tag == "BorderBottom")
        {
            Debug.Log("power up triggerst border bottom");
            Destroy(gameObject);
        }
    }
}
