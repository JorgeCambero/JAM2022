using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarNivel : MonoBehaviour
{
    // Start is called before the first frame update
    public string escenaSiguiente;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Cambiando nivel...");

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") || collision.gameObject.layer == LayerMask.NameToLayer("PlayerW"))
        {
            SceneManager.LoadScene(escenaSiguiente);
        }
    }
}

