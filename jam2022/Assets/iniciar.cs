using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iniciar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        r.angularVelocity = -150;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
