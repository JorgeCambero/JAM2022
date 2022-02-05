using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iniciar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D a = GetComponent<Rigidbody2D>();
        a.angularVelocity = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
