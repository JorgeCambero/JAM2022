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
            collision.GetComponent<Rigidbody2D>().drag = 50;
            collision.GetComponent<Rigidbody2D>().angularDrag = 50;
            StartCoroutine(freeze(collision));
            //collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            //collision.GetComponent<Rigidbody2D>().constraints = ;
        }
    }
    IEnumerator freeze(Collider2D collision)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null)
        {
            iunfreeze(collision);
            StartCoroutine(unfreeze(collision));
            //collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            //if(collision.gameObject.layer == LayerMask.NameToLayer("Player")) collision.GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezeRotation;
            //collision.GetComponent<Rigidbody2D>().drag = 0;
            //collision.GetComponent<Rigidbody2D>().WakeUp();
            //collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    IEnumerator unfreeze(Collider2D collision)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        collision.GetComponent<Rigidbody2D>().drag = 0;
        collision.GetComponent<Rigidbody2D>().angularDrag = 0;
        collision.GetComponent<Rigidbody2D>().WakeUp();
    }
    void iunfreeze(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        collision.GetComponent<Rigidbody2D>().drag = 0;
        collision.GetComponent<Rigidbody2D>().angularDrag = 0;
        collision.GetComponent<Rigidbody2D>().WakeUp();
    }
}

