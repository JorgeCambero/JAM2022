using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCreator : MonoBehaviour
{
    public GameObject caja;
    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        while (true)
        {
            //Rotate 90 deg
            Instantiate(caja, pos.position, Quaternion.identity);

            //Wait for 4 seconds
            yield return new WaitForSecondsRealtime(5);
        }
    }
}
