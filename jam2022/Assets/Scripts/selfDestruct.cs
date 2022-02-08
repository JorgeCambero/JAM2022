using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{

    public GameObject caja;
    private Vector3 spawnPos;
    void Start()
    {
        spawnPos = transform.position;
        Debug.Log(" posicion es" + spawnPos.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        //Debug.Log("rwdesdf");
        if (collision.gameObject.layer == LayerMask.NameToLayer("DestruyeCajas"))
        {
            Instantiate(caja, spawnPos, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
