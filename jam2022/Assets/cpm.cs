using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cpm : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform tp_pos;
    Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.layer == LayerMask.NameToLayer("TP"))
        {
            rb.AddForce(new Vector2(0.4f * Time.deltaTime, 0));
            gameObject.transform.position = tp_pos.position;
        }
    }
}
