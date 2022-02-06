using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject placa;
    public Transform posFinal;
    Vector3 posInicio;
    pressurePlate plate;
    // Start is called before the first frame update
    void Start()
    {
        posInicio = transform.position;
        plate = placa.GetComponent<pressurePlate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plate.active == true)
        {
            gameObject.transform.position = posFinal.position;
        } else {
            gameObject.transform.position = posInicio;
        }
    }
}
