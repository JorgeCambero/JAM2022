using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseW : MonoBehaviour
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
        if (collision.GetComponent<Rigidbody2D>() != null)
        {

            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            //collision.GetComponent<Rigidbody2D>().constraints = ;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null)
        {
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            collision.GetComponent<Rigidbody2D>().WakeUp();
            //collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}

