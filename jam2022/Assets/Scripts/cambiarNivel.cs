using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarNivel : MonoBehaviour
{
    // Start is called before the first frame update
    public string escenaSiguiente;
    bool activo;
    public bool justOnce=false;
    public bool activable;
    public GameObject placa;
    pressurePlate plate;
    Animator animations = new Animator();
    void Start()
    {
        if (!activable)
        {
            activo = true;
        }
        else
        {
            plate = placa.GetComponent<pressurePlate>();
        }
        animations = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            animations.SetBool("encendido", true);
        }
        else 
        {
            animations.SetBool("encendido", false);
        }
        if (activable)
        {
            if (plate.active == true)
            {
                activo = true;
            }
            else if (!justOnce)
            {
                activo = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Cambiando nivel...");

        if ((collision.gameObject.layer == LayerMask.NameToLayer("Player") || collision.gameObject.layer == LayerMask.NameToLayer("PlayerW")) && activo)
        {
            SceneManager.LoadScene(escenaSiguiente);
        }
    }
}

