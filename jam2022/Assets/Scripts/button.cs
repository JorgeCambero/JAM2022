using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Placa encendida");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interact"))
        {
            active = true;
        }
    }
}
