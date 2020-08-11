using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<PlayerController>())
        {
           
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        } 
    }
}
