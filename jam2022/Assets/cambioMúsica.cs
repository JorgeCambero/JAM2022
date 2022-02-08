using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioMúsica : MonoBehaviour
{
    AudioManager am;
    // Start is called before the first frame update
    void Start()
    {
        am = FindObjectOfType<AudioManager>();
        am.cambiar = true;
    }
}
