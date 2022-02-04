using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2000f * Time.deltaTime, 0));
            if (rb.velocity.x <= -15) { rb.velocity = new Vector2(-15f, rb.velocity.y); }
        }
        //right
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2000f * Time.deltaTime, 0));
            if (rb.velocity.x >= 15) { rb.velocity = new Vector2(15f, rb.velocity.y); }
        }
    }
}
