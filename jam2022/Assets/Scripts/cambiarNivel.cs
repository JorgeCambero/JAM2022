using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarNivel : MonoBehaviour
{
    // Start is called before the first frame update
    public string escenaSiguiente;
    public bool activo;
    Animator animations = new Animator();
    void Start()
    {
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

