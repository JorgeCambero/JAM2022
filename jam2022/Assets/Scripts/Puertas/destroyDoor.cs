using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDoor : MonoBehaviour
{
    public GameObject placa;
    pressurePlate plate;
    // Start is called before the first frame update
    void Start()
    {
        plate = placa.GetComponent<pressurePlate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plate.active == true)
        {
           Destroy(gameObject);
        }
    }
}
